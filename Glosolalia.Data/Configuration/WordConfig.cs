using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glosolalia.Data.Configuration
{
    public class WordConfig : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Navigation(w => w.Language).IsRequired();
            builder.Property(w => w.Value).IsRequired();
            builder.HasIndex(w => new { w.LanguageId, w.Value }).IsUnique();
            //builder.Navigation(w => w.Language).AutoInclude();//Bug włącza WSZYSTKIE LANGUAGE autoincludy, absurdalnie głęboko przez co w sheetach mi sie jsony wykurwiją.
        }
    }
}
