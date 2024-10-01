using Microsoft.EntityFrameworkCore;

namespace FileStorage.Models
{
    public class FileExtentionModel
    {

        public int ExtentionId { get; set; }
        public string Name { get; set; }
        public byte? Foto { get; set; }


        public virtual ICollection<FileModel> FileModel { get; set; } = new List<FileModel>(); // одному расширению принадлежит много файлов


        public FileExtentionModel() { }


        public FileExtentionModel(FileExtentionModel fileExtentionModel) 
        {
            ExtentionId = fileExtentionModel.ExtentionId;
            Name = fileExtentionModel.Name;
            Foto = fileExtentionModel.Foto;
        }
    }
}
