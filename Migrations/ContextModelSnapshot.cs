﻿// <auto-generated />
using System;
using FileStorage.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FileStorage.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FileStorage.Models.FileExtentionModel", b =>
                {
                    b.Property<int>("FileExtentionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FileExtentionId"));

                    b.Property<byte?>("Foto")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("FileExtentionId");

                    b.ToTable("FileExtention");
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

                    b.Property<int>("FileExtentionId")
                        .HasColumnType("integer");

                    b.Property<int?>("FileExtentionModelFileExtentionId")
                        .HasColumnType("integer");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<int?>("FolderModelFolderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("FileId");

                    b.HasIndex("FileExtentionModelFileExtentionId");

                    b.HasIndex("FolderModelFolderId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("FileStorage.Models.FolderModel", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FolderId"));

                    b.Property<string>("FolderParentNameId")
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.HasKey("FolderId");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("FileStorage.Models.FileModel", b =>
                {
                    b.HasOne("FileStorage.Models.FileExtentionModel", "FileExtentionModel")
                        .WithMany("FileModel")
                        .HasForeignKey("FileExtentionModelFileExtentionId");

                    b.HasOne("FileStorage.Models.FolderModel", "FolderModel")
                        .WithMany("Files")
                        .HasForeignKey("FolderModelFolderId");

                    b.Navigation("FileExtentionModel");

                    b.Navigation("FolderModel");
                });

            modelBuilder.Entity("FileStorage.Models.FileExtentionModel", b =>
                {
                    b.Navigation("FileModel");
                });

            modelBuilder.Entity("FileStorage.Models.FolderModel", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
