using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Data;

using Glosolalia.Common.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
	[Export(typeof(IWordRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WordRepository : DataRepositoryBase<Word>, IWordRepository
    {
    }

}
