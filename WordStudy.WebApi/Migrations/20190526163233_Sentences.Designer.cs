﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WordStudy.Data;

namespace WordStudy.WebApi.Migrations
{
    [DbContext(typeof(EWSDbContext))]
    [Migration("20190526163233_Sentences")]
    partial class Sentences
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WordStudy.Data.Model.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("Serial");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsMain");

                    b.Property<string>("Url");

                    b.Property<int?>("UsrId");

                    b.HasKey("Id");

                    b.HasIndex("UsrId");

                    b.ToTable("Photos","EWSDB");
                });

            modelBuilder.Entity("WordStudy.Data.Model.Sentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("Serial");

                    b.Property<string>("Body");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mean");

                    b.HasKey("Id");

                    b.ToTable("Sentences","EWSDB");
                });

            modelBuilder.Entity("WordStudy.Data.Model.Usr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("Serial");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Gender");

                    b.Property<string>("Interests");

                    b.Property<string>("Introduction");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Knowns");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("LookingFor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Usr","EWSDB");
                });

            modelBuilder.Entity("WordStudy.Data.Model.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("Serial");

                    b.Property<int>("AddType");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mean")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Word","EWSDB");
                });

            modelBuilder.Entity("WordStudy.Data.Model.WordOfList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("Serial");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("WordId");

                    b.Property<int?>("WrdListId");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.HasIndex("WrdListId");

                    b.ToTable("WordOfList","EWSDB");
                });

            modelBuilder.Entity("WordStudy.Data.Model.WrdList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("Serial");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ListName");

                    b.Property<int?>("UsrId");

                    b.HasKey("Id");

                    b.HasIndex("UsrId");

                    b.ToTable("WrdList","EWSDB");
                });

            modelBuilder.Entity("WordStudy.Data.Model.Photo", b =>
                {
                    b.HasOne("WordStudy.Data.Model.Usr", "Usr")
                        .WithMany("Photos")
                        .HasForeignKey("UsrId");
                });

            modelBuilder.Entity("WordStudy.Data.Model.WordOfList", b =>
                {
                    b.HasOne("WordStudy.Data.Model.Word", "Word")
                        .WithMany("WordOfLists")
                        .HasForeignKey("WordId");

                    b.HasOne("WordStudy.Data.Model.WrdList", "WrdList")
                        .WithMany("WordOfLists")
                        .HasForeignKey("WrdListId");
                });

            modelBuilder.Entity("WordStudy.Data.Model.WrdList", b =>
                {
                    b.HasOne("WordStudy.Data.Model.Usr", "Usr")
                        .WithMany("WrdLists")
                        .HasForeignKey("UsrId");
                });
#pragma warning restore 612, 618
        }
    }
}
