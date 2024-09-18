using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileStorage.Models
{
    public class Context : DbContext
    {
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileExtention> FileExtentions { get; set; }

        public Context() { }


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
            modelBuilder.Entity<File>(b => { b.HasKey(m => m.FileId); });
            modelBuilder.Entity<Folder>(b => { b.HasKey(m => m.FolderId); });
            modelBuilder.Entity<Folder>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<Folder>().Property(m => m.FolderParentNameId).HasColumnType("character varying");
            modelBuilder.Entity<FileExtention>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<File>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<File>().Property(m => m.Description).HasColumnType("character varying");
            modelBuilder.Entity<File>().Property(m => m.Content).HasColumnType("character varying");


        }
    }
}
