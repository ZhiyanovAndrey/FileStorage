using Microsoft.EntityFrameworkCore;

namespace FileStorage.Models
{
    public class FileExtentionModel
    {

        public int ExtentionId { get; set; }
        public string Name { get; set; }
        public byte? Foto { get; set; }


        public ICollection<FileModel> files { get; set; } // многие ко многим


        public FileExtentionModel() { }


        public FileExtentionModel(FileExtentionModel fileExtentionModel)
        {
            ExtentionId = fileExtentionModel.ExtentionId;
            Name = fileExtentionModel.Name;
            Foto = fileExtentionModel.Foto;
        }
    }
}
