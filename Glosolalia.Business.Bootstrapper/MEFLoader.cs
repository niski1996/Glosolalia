using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using Glosolalia.Data;
using Glosolalia.Data.Repository_Interface;

namespace Glosolalia.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(PartOfSpeechRepository).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
