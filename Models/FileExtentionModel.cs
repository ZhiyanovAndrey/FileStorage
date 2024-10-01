using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorage.Models
{
    [Table("FileExtention")]
    public class FileExtentionModel
    {

        public int FileExtentionId { get; set; }
        public string Name { get; set; }
        public byte? Foto { get; set; }


        public virtual ICollection<FileModel> FileModel { get; set; } = new List<FileModel>(); // одному расширению принадлежит много файлов


        public FileExtentionModel() { }


        public FileExtentionModel(FileExtentionModel fileExtentionModel) 
        {
            FileExtentionId = fileExtentionModel.FileExtentionId;
            Name = fileExtentionModel.Name;
            Foto = fileExtentionModel.Foto;
        }
    }
}
