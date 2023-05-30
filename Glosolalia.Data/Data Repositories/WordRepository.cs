using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Data;

using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
	[Export(typeof(IWordRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WordRepository : DataRepositoryBase<Word>, IWordRepository
    {
        protected override Word AddEntity(GlosolaliaContext entityContext, Word entity)
        {

            var dbSet = _getDbSetFromContext(entityContext);
            var tmp = entityContext.Words.FirstOrDefault(e => (e.LanguageId == entity.LanguageId) && (e.Value == entity.Value));
            if (tmp != null) { return tmp; }
            return entityContext.Words.Add(entity).Entity;
        }

    }

}
