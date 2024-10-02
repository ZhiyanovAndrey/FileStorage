using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileStorage.Models.Data
{
    public class Context : DbContext
    {
        public DbSet<FolderModel> Folders { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<FileExtentionModel> FileExtentions { get; set; }

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

            modelBuilder.Entity<FileExtentionModel>(b => { b.HasKey(m => m.FileExtentionModelId); });
            modelBuilder.Entity<FileModel>(b => { b.HasKey(m => m.FileModelId); });
            modelBuilder.Entity<FolderModel>(b => { b.HasKey(m => m.FolderModelId); });
            modelBuilder.Entity<FolderModel>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<FolderModel>().Property(m => m.FolderParentNameId).HasColumnType("character varying");
            modelBuilder.Entity<FileExtentionModel>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<FileModel>().Property(m => m.Name).HasColumnType("character varying");
            modelBuilder.Entity<FileModel>().Property(m => m.Description).HasColumnType("character varying");
            modelBuilder.Entity<FileModel>().Property(m => m.Content).HasColumnType("character varying");


        }
    }
}
