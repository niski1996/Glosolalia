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
    [Migration("20230509221437_db 3lang + sheet ver 1.0")]
    partial class db3langsheetver10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnSentenceEnWord", b =>
                {
                    b.Property<int>("EnSentenceSetId")
                        .HasColumnType("int");

                    b.Property<int>("EnWordSetId")
                        .HasColumnType("int");

                    b.HasKey("EnSentenceSetId", "EnWordSetId");

                    b.HasIndex("EnWordSetId");

                    b.ToTable("EnSentenceEnWord");
                });

            modelBuilder.Entity("EnSentenceSheet", b =>
                {
                    b.Property<int>("EnSentenceSetId")
                        .HasColumnType("int");

                    b.Property<int>("SheetSetId")
                        .HasColumnType("int");

                    b.HasKey("EnSentenceSetId", "SheetSetId");

                    b.HasIndex("SheetSetId");

                    b.ToTable("EnSentenceSheet");
                });

            modelBuilder.Entity("EnWordPlWord", b =>
                {
                    b.Property<int>("EnWordsId")
                        .HasColumnType("int");

                    b.Property<int>("PlWordSetId")
                        .HasColumnType("int");

                    b.HasKey("EnWordsId", "PlWordSetId");

                    b.HasIndex("PlWordSetId");

                    b.ToTable("EnWordPlWord");
                });

            modelBuilder.Entity("EnWordSheet", b =>
                {
                    b.Property<int>("EnWordSetId")
                        .HasColumnType("int");

                    b.Property<int>("SheetSetId")
                        .HasColumnType("int");

                    b.HasKey("EnWordSetId", "SheetSetId");

                    b.HasIndex("SheetSetId");

                    b.ToTable("EnWordSheet");
                });

            modelBuilder.Entity("EsSentenceEsWord", b =>
                {
                    b.Property<int>("EsWordSetId")
                        .HasColumnType("int");

                    b.Property<int>("SentenceSetId")
                        .HasColumnType("int");

                    b.HasKey("EsWordSetId", "SentenceSetId");

                    b.HasIndex("SentenceSetId");

                    b.ToTable("EsSentenceEsWord");
                });

            modelBuilder.Entity("EsSentenceSheet", b =>
                {
                    b.Property<int>("EsSentenceSetId")
                        .HasColumnType("int");

                    b.Property<int>("SheetSetId")
                        .HasColumnType("int");

                    b.HasKey("EsSentenceSetId", "SheetSetId");

                    b.HasIndex("SheetSetId");

                    b.ToTable("EsSentenceSheet");
                });

            modelBuilder.Entity("EsWordPlWord", b =>
                {
                    b.Property<int>("EsWordsId")
                        .HasColumnType("int");

                    b.Property<int>("PlWordSetId")
                        .HasColumnType("int");

                    b.HasKey("EsWordsId", "PlWordSetId");

                    b.HasIndex("PlWordSetId");

                    b.ToTable("EsWordPlWord");
                });

            modelBuilder.Entity("EsWordSheet", b =>
                {
                    b.Property<int>("EsWordSetId")
                        .HasColumnType("int");

                    b.Property<int>("SheetSetId")
                        .HasColumnType("int");

                    b.HasKey("EsWordSetId", "SheetSetId");

                    b.HasIndex("SheetSetId");

                    b.ToTable("EsWordSheet");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.PartOfSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("PartsOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.EnSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastInput")
                        .HasColumnType("datetime2");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("plTranslationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LastInput");

                    b.HasIndex("Progress");

                    b.HasIndex("plTranslationId")
                        .IsUnique();

                    b.ToTable("EnSentenceSet");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.EsSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastInput")
                        .HasColumnType("datetime2");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("plTranslationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LastInput");

                    b.HasIndex("Progress");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.HasIndex("plTranslationId")
                        .IsUnique();

                    b.ToTable("EsSentenceSet");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.PlSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastInput")
                        .HasColumnType("datetime2");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LastInput");

                    b.HasIndex("Progress");

                    b.ToTable("PlSentenceSet");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SheetSet");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EnSentenceId")
                        .HasColumnType("int");

                    b.Property<int?>("EnWordId")
                        .HasColumnType("int");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int?>("EsSentenceId")
                        .HasColumnType("int");

                    b.Property<int?>("EsWordId")
                        .HasColumnType("int");

                    b.Property<int?>("PlSentenceId")
                        .HasColumnType("int");

                    b.Property<int?>("PlWordId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EnSentenceId");

                    b.HasIndex("EnWordId");

                    b.HasIndex("EsSentenceId");

                    b.HasIndex("EsWordId");

                    b.HasIndex("PlSentenceId");

                    b.HasIndex("PlWordId");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.EnWord", b =>
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

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LastInput");

                    b.HasIndex("PartOfSpeechId");

                    b.HasIndex("Progress");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("EnWords");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.EsWord", b =>
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

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LastInput");

                    b.HasIndex("PartOfSpeechId");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("EsWords");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.PlWord", b =>
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

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LastInput");

                    b.HasIndex("PartOfSpeechId");

                    b.HasIndex("Progress");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("PlWords");
                });

            modelBuilder.Entity("PlSentencePlWord", b =>
                {
                    b.Property<int>("PlWordSetId")
                        .HasColumnType("int");

                    b.Property<int>("SentenceSetId")
                        .HasColumnType("int");

                    b.HasKey("PlWordSetId", "SentenceSetId");

                    b.HasIndex("SentenceSetId");

                    b.ToTable("PlSentencePlWord");
                });

            modelBuilder.Entity("EnSentenceEnWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Sentences.EnSentence", null)
                        .WithMany()
                        .HasForeignKey("EnSentenceSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Words.EnWord", null)
                        .WithMany()
                        .HasForeignKey("EnWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnSentenceSheet", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Sentences.EnSentence", null)
                        .WithMany()
                        .HasForeignKey("EnSentenceSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Sheet", null)
                        .WithMany()
                        .HasForeignKey("SheetSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnWordPlWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Words.EnWord", null)
                        .WithMany()
                        .HasForeignKey("EnWordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Words.PlWord", null)
                        .WithMany()
                        .HasForeignKey("PlWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnWordSheet", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Words.EnWord", null)
                        .WithMany()
                        .HasForeignKey("EnWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Sheet", null)
                        .WithMany()
                        .HasForeignKey("SheetSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EsSentenceEsWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Words.EsWord", null)
                        .WithMany()
                        .HasForeignKey("EsWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Sentences.EsSentence", null)
                        .WithMany()
                        .HasForeignKey("SentenceSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EsSentenceSheet", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Sentences.EsSentence", null)
                        .WithMany()
                        .HasForeignKey("EsSentenceSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Sheet", null)
                        .WithMany()
                        .HasForeignKey("SheetSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EsWordPlWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Words.EsWord", null)
                        .WithMany()
                        .HasForeignKey("EsWordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Words.PlWord", null)
                        .WithMany()
                        .HasForeignKey("PlWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EsWordSheet", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Words.EsWord", null)
                        .WithMany()
                        .HasForeignKey("EsWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Sheet", null)
                        .WithMany()
                        .HasForeignKey("SheetSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.EnSentence", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Sentences.PlSentence", "plTranslation")
                        .WithOne("EnTranslation")
                        .HasForeignKey("Glosolalia.Business.Entities.Sentences.EnSentence", "plTranslationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plTranslation");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.EsSentence", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Sentences.PlSentence", "plTranslation")
                        .WithOne("EsTranslation")
                        .HasForeignKey("Glosolalia.Business.Entities.Sentences.EsSentence", "plTranslationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plTranslation");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Tag", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Sentences.EnSentence", null)
                        .WithMany("Tags")
                        .HasForeignKey("EnSentenceId");

                    b.HasOne("Glosolalia.Business.Entities.Words.EnWord", null)
                        .WithMany("Tags")
                        .HasForeignKey("EnWordId");

                    b.HasOne("Glosolalia.Business.Entities.Sentences.EsSentence", null)
                        .WithMany("Tags")
                        .HasForeignKey("EsSentenceId");

                    b.HasOne("Glosolalia.Business.Entities.Words.EsWord", null)
                        .WithMany("Tags")
                        .HasForeignKey("EsWordId");

                    b.HasOne("Glosolalia.Business.Entities.Sentences.PlSentence", null)
                        .WithMany("Tags")
                        .HasForeignKey("PlSentenceId");

                    b.HasOne("Glosolalia.Business.Entities.Words.PlWord", null)
                        .WithMany("Tags")
                        .HasForeignKey("PlWordId");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.EnWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.EsWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.PlWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("PlSentencePlWord", b =>
                {
                    b.HasOne("Glosolalia.Business.Entities.Words.PlWord", null)
                        .WithMany()
                        .HasForeignKey("PlWordSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Business.Entities.Sentences.PlSentence", null)
                        .WithMany()
                        .HasForeignKey("SentenceSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.EnSentence", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.EsSentence", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Sentences.PlSentence", b =>
                {
                    b.Navigation("EnTranslation")
                        .IsRequired();

                    b.Navigation("EsTranslation")
                        .IsRequired();

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.EnWord", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.EsWord", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Glosolalia.Business.Entities.Words.PlWord", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
