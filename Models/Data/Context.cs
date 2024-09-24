﻿using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileStorage.Models.Data
{
    public class Context : DbContext
    {
        public DbSet<Folder> Folders { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<FileExtention> FileExtentions { get; set; }

        //public Context() { }


        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FileExtention>(b => { b.HasKey(m => m.ExtentionId); });
            modelBuilder.Entity<FileModel>(b => { b.HasKey(m => m.FileId); });
            modelBuilder.Entity<Folder>(b => { b.HasKey(m => m.FolderId); });
            modelBuilder.Entity<Folder>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<Folder>().Property(m => m.FolderParentNameId).HasColumnType("character varying");
            modelBuilder.Entity<FileExtention>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<FileModel>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<FileModel>().Property(m => m.Description).HasColumnType("character varying");
            modelBuilder.Entity<FileModel>().Property(m => m.Content).HasColumnType("character varying");


        }
    }
}