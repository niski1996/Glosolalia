﻿// <auto-generated />
using System;
using Glosolalia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    [DbContext(typeof(GlosolaliaContext))]
    [Migration("20230607171820_trial")]
    partial class trial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Glosolalia.Common.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("LanguageSet");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.PartOfSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PartsOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Sheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SheetSet");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastInput")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PartOfSpeechId")
                        .HasColumnType("int");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("TranslationSet");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId", "Value")
                        .IsUnique();

                    b.ToTable("Words");
                });

            modelBuilder.Entity("SheetTranslation", b =>
                {
                    b.Property<int>("SheetSetId")
                        .HasColumnType("int");

                    b.Property<int>("TranslationSetId")
                        .HasColumnType("int");

                    b.HasKey("SheetSetId", "TranslationSetId");

                    b.HasIndex("TranslationSetId");

                    b.ToTable("SheetTranslation");
                });

            modelBuilder.Entity("TagTranslation", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("TranslationSetId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "TranslationSetId");

                    b.HasIndex("TranslationSetId");

                    b.ToTable("TagTranslation");
                });

            modelBuilder.Entity("TranslationWord", b =>
                {
                    b.Property<int>("TranslationSetId")
                        .HasColumnType("int");

                    b.Property<int>("WordSetId")
                        .HasColumnType("int");

                    b.HasKey("TranslationSetId", "WordSetId");

                    b.HasIndex("WordSetId");

                    b.ToTable("TranslationWord");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Translation", b =>
                {
                    b.HasOne("Glosolalia.Common.Entities.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Word", b =>
                {
                    b.HasOne("Glosolalia.Common.Entities.Language", "Language")
                        .WithMany("WordSet")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("SheetTranslation", b =>
                {
                    b.HasOne("Glosolalia.Common.Entities.Sheet", null)
                        .WithMany()
                        .HasForeignKey("SheetSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Common.Entities.Translation", null)
                        .WithMany()
                        .HasForeignKey("TranslationSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TagTranslation", b =>
                {
                    b.HasOne("Glosolalia.Common.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Common.Entities.Translation", null)
                        .WithMany()
                        .HasForeignKey("TranslationSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TranslationWord", b =>
                {
                    b.HasOne("Glosolalia.Common.Entities.Translation", null)
                        .WithMany()
                        .HasForeignKey("TranslationSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Common.Entities.Word", null)
                        .WithMany()
                        .HasForeignKey("WordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Glosolalia.Common.Entities.Language", b =>
                {
                    b.Navigation("WordSet");
                });
#pragma warning restore 612, 618
        }
    }
}
