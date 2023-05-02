using System.ComponentModel.Composition;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Business.Bootstrapper;
using Glosolalia.Business.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Glosolalia.Data.Test
{
    [TestClass]
    public class DataLayerTestskc
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }


        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();

            IEnumerable<PartOfSpeech> partOfSpeech = repositoryTest.GetPartOfSpeech();

            Assert.IsTrue(partOfSpeech != null);
        }


        [TestMethod]
        public void test_repository_factory_usage()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

            IEnumerable<PartOfSpeech> PartOfSpeechs = factoryTest.GetPartOfSpeechs();

            Assert.IsTrue(PartOfSpeechs != null);
        }

        [TestMethod]
        public void test_repository_mocking()
        {
            List<PartOfSpeech> partsOfSpeech = new List<PartOfSpeech>()
            {
                new PartOfSpeech() {Value = "dupa" },
                new PartOfSpeech() {Value = "dupsko" },
            };

            Mock<IPartOfSpeechRepository> mockPartOfSpeech = new Mock<IPartOfSpeechRepository>();
            mockPartOfSpeech.Setup(obj => obj.GetAll()).Returns(partsOfSpeech);

            RepositoryTestClass repositoryTest = new RepositoryTestClass(mockPartOfSpeech.Object);

            IEnumerable<PartOfSpeech> ret = repositoryTest.GetPartOfSpeech();

            Assert.IsTrue(ret == partsOfSpeech);
        }


        [TestMethod]
        public void test_factory_mocking1()
        {
            List<PartOfSpeech> PartOfSpeechs = new List<PartOfSpeech>()
                {
                new PartOfSpeech() {Value = "dupa" },
                new PartOfSpeech() {Value = "dupsko" }
                };

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IPartOfSpeechRepository>().GetAll()).Returns(PartOfSpeechs);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<PartOfSpeech> ret = factoryTest.GetPartOfSpeechs();

            Assert.IsTrue(ret == PartOfSpeechs);
        }

        [TestMethod]
        public void test_factory_mocking2()
        {
            List<PartOfSpeech> PartOfSpeechs = new List<PartOfSpeech>()
            {
                new PartOfSpeech() { Value = "dupa" },
                new PartOfSpeech() { Value = "dupsko" }
            };

            Mock<IPartOfSpeechRepository> mockPartOfSpeechRepository = new Mock<IPartOfSpeechRepository>();
            mockPartOfSpeechRepository.Setup(obj => obj.GetAll()).Returns(PartOfSpeechs);

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IPartOfSpeechRepository>()).Returns(mockPartOfSpeechRepository.Object);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<PartOfSpeech> ret = factoryTest.GetPartOfSpeechs();

            Assert.IsTrue(ret == PartOfSpeechs);
        }


        public class RepositoryTestClass
        {
            public RepositoryTestClass()
            {
                ObjectBase.Container.SatisfyImportsOnce(this);
            }

            public RepositoryTestClass(IPartOfSpeechRepository partsOfSpeechRepository)
            {
                _PartOfSpeechRepository = partsOfSpeechRepository;
            }

            [Import]
            IPartOfSpeechRepository _PartOfSpeechRepository;

            public IEnumerable<PartOfSpeech> GetPartOfSpeech()
            {
                IEnumerable<PartOfSpeech> partsOfSpeech = _PartOfSpeechRepository.GetAll();

                return partsOfSpeech;
            }
        }

        public class RepositoryFactoryTestClass
        {
            public RepositoryFactoryTestClass()
            {
                ObjectBase.Container.SatisfyImportsOnce(this);
            }

            public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
            {
                _DataRepositoryFactory = dataRepositoryFactory;
            }

            [Import]
            IDataRepositoryFactory _DataRepositoryFactory;

            public IEnumerable<PartOfSpeech> GetPartOfSpeechs()
            {
                IPartOfSpeechRepository PartOfSpeechRepository = _DataRepositoryFactory.GetDataRepository<IPartOfSpeechRepository>();

                IEnumerable<PartOfSpeech> PartOfSpeechs = PartOfSpeechRepository.GetAll();

                return PartOfSpeechs;
            }
        }
    }
}