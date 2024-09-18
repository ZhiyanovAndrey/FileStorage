using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileStorage.Models
{
    public class Context : DbContext
    {
        public DbSet<Folders> DbSetFolders { get; set; }
        public DbSet<Files> DbSetFiles { get; set; }
        public DbSet<FileExtention> DbSetFileExtentions { get; set; }

        public Context() { }


        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql();
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FileExtention>(b => { b.HasKey(m => m.ExtentionId); });
            modelBuilder.Entity<Files>(b => { b.HasKey(m => m.FileId); });
            modelBuilder.Entity<Folders>(b => { b.HasKey(m => m.FolderId); });
            //modelbuilder.Property(u => u.Login)
        }
    }
}
