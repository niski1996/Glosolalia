﻿using System.ComponentModel.Composition;
using Glosolalia.Business.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.Data
{
    [Export(typeof(IPartOfSpeechRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PartOfSpeechRepository : DataRepositoryBase<PartOfSpeech>, IPartOfSpeechRepository
    {
    }

}
