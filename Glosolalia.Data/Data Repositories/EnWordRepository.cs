using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Data;
using Glosolalia.Business.Entities.Words;
using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
    [Export(typeof(IEnWordRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EnWordRepository : DataRepositoryBase<EnWord>, IEnWordRepository
    {
    }

}
