﻿// <auto-generated />
using System;
using Glosolalia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    [DbContext(typeof(GlosolaliaContext))]
    partial class GlosolaliaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Glosolalia.Buisness.Entities.EnWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastInput")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartOfSpeechId")
                        .HasColumnType("int");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("EnWords");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.EnWordPlWord", b =>
                {
                    b.Property<int>("IdEnWord")
                        .HasColumnType("int");

                    b.Property<int>("IdPlWord")
                        .HasColumnType("int");

                    b.Property<int?>("EnWordId")
                        .HasColumnType("int");

                    b.Property<int?>("PlWordId")
                        .HasColumnType("int");

                    b.HasKey("IdEnWord", "IdPlWord");

                    b.HasIndex("EnWordId");

                    b.HasIndex("PlWordId");

                    b.ToTable("EnWordPlWord");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.PartOfSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PartsOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.PlWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastInput")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartOfSpeechId")
                        .HasColumnType("int");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("PlWords");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.EnWord", b =>
                {
                    b.HasOne("Glosolalia.Buisness.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Buisness.Entities.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.EnWordPlWord", b =>
                {
                    b.HasOne("Glosolalia.Buisness.Entities.EnWord", null)
                        .WithMany("PlTranslation")
                        .HasForeignKey("EnWordId");

                    b.HasOne("Glosolalia.Buisness.Entities.PlWord", null)
                        .WithMany("EnTranslation")
                        .HasForeignKey("PlWordId");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.PlWord", b =>
                {
                    b.HasOne("Glosolalia.Buisness.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Glosolalia.Buisness.Entities.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.EnWord", b =>
                {
                    b.Navigation("PlTranslation");
                });

            modelBuilder.Entity("Glosolalia.Buisness.Entities.PlWord", b =>
                {
                    b.Navigation("EnTranslation");
                });
#pragma warning restore 612, 618
        }
    }
}
