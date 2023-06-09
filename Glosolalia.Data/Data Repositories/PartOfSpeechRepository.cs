﻿using System.ComponentModel.Composition;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;

namespace Glosolalia.Data
{
    [Export(typeof(IPartOfSpeechRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PartOfSpeechRepository : DataRepositoryBase<PartOfSpeech>, IPartOfSpeechRepository
    {
    }

}
