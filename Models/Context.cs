using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileStorage.Models
{
    public class Context : DbContext
    {
        public DbSet<Folders> DbSetFolders { get; set; }
        public DbSet<Files> DbSetFiles { get; set; }
        public DbSet<FileExtention> DbSetFileExtentions { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
