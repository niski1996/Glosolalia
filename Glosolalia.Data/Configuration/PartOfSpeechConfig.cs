using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glosolalia.Data.Configuration
{
    public class PartOfSpeechConfig : IEntityTypeConfiguration<PartOfSpeech>
    {
        public void Configure(EntityTypeBuilder<PartOfSpeech> builder)
        {
        }
    }
}
