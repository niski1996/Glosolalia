using System.ComponentModel.Composition;
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


        //    [TestMethod]
        //    public void test_repository_factory_usage()
        //    {
        //        RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

        //        IEnumerable<Car> cars = factoryTest.GetCars();

        //        Assert.IsTrue(cars != null);
        //    }

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
    }
    //    }

        //    [TestMethod]
        //    public void test_factory_mocking1()
        //    {
        //        List<Car> cars = new List<Car>()
        //        {
        //            new Car() { CarId = 1, Description = "Mustang" },
        //            new Car() { CarId = 2, Description = "Corvette" }
        //        };

        //        Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
        //        mockDataRepository.Setup(obj => obj.GetDataRepository<ICarRepository>().Get()).Returns(cars);

        //        RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

        //        IEnumerable<Car> ret = factoryTest.GetCars();

        //        Assert.IsTrue(ret == cars);
        //    }

        //    [TestMethod]
        //    public void test_factory_mocking2()
        //    {
        //        List<Car> cars = new List<Car>()
        //        {
        //            new Car() { CarId = 1, Description = "Mustang" },
        //            new Car() { CarId = 2, Description = "Corvette" }
        //        };

        //        Mock<ICarRepository> mockCarRepository = new Mock<ICarRepository>();
        //        mockCarRepository.Setup(obj => obj.Get()).Returns(cars);

        //        Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
        //        mockDataRepository.Setup(obj => obj.GetDataRepository<ICarRepository>()).Returns(mockCarRepository.Object);

        //        RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

        //        IEnumerable<Car> ret = factoryTest.GetCars();

        //        Assert.IsTrue(ret == cars);
        //    }
        //}

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
}

//    public class RepositoryFactoryTestClass
//    {
//        public RepositoryFactoryTestClass()
//        {
//            ObjectBase.Container.SatisfyImportsOnce(this);
//        }

//        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
//        {
//            _DataRepositoryFactory = dataRepositoryFactory;
//        }

//        [Import]
//        IDataRepositoryFactory _DataRepositoryFactory;

//        public IEnumerable<Car> GetCars()
//        {
//            ICarRepository carRepository = _DataRepositoryFactory.GetDataRepository<ICarRepository>();

//            IEnumerable<Car> cars = carRepository.Get();

//            return cars;
//        }
//    }
//}