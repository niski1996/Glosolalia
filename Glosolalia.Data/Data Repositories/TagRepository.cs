﻿using System.ComponentModel.Composition;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;

namespace Glosolalia.Data
{
    [Export(typeof(ITagRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TagRepository : DataRepositoryBase<Tag>, ITagRepository
    {
    }

}
