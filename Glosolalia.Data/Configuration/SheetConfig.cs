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
    public class SheetConfig : IEntityTypeConfiguration<Sheet>
    {
        public void Configure(EntityTypeBuilder<Sheet> builder)
        {
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Navigation(e => e.LanguageTwo);
            builder.HasOne(e => e.LanguageOne)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.LanguageTwo)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
