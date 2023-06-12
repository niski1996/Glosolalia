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
    internal class TranslationConfig : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Navigation(e => e.WordSet).AutoInclude();
        }
    }
}
