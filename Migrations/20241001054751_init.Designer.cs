﻿// <auto-generated />
using System;
using FileStorage.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FileStorage.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241001054751_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FileStorage.Models.FileExtentionModel", b =>
                {
                    b.Property<int>("ExtentionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExtentionId"));

                    b.Property<byte?>("Foto")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("ExtentionId");

                    b.ToTable("FileExtentions");
                });

            modelBuilder.Entity("FileStorage.Models.FileModel", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FileId"));

                    b.Property<string>("Content")
                        .HasColumnType("character varying");

                    b.Property<string>("Description")
                        .HasColumnType("character varying");

                    b.Property<int>("ExtentionId")
                        .HasColumnType("integer");

                    b.Property<int>("FileExtentionModelExtentionId")
                        .HasColumnType("integer");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("FileId");

                    b.HasIndex("FileExtentionModelExtentionId");

                    b.HasIndex("FolderId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("FileStorage.Models.FolderModel", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FolderId"));

                    b.Property<string>("FolderParentNameId")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("FolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("FileStorage.Models.FileModel", b =>
                {
                    b.HasOne("FileStorage.Models.FileExtentionModel", "FileExtentionModel")
                        .WithMany("files")
                        .HasForeignKey("FileExtentionModelExtentionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileStorage.Models.FolderModel", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileExtentionModel");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("FileStorage.Models.FileExtentionModel", b =>
                {
                    b.Navigation("files");
                });

            modelBuilder.Entity("FileStorage.Models.FolderModel", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
