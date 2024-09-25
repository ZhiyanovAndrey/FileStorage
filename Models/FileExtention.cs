using Microsoft.EntityFrameworkCore;

namespace FileStorage.Models
{
    public class FileExtention
    {

        public int ExtentionId { get; set; }
        public string Name { get; set; }
        public byte? Foto { get; set; }


        public ICollection<FileModel> files { get; set; } // многие ко многим


        public FileExtention() { }


        public FileExtention(FileExtention fileExtentionModel)
        {
            ExtentionId = fileExtentionModel.ExtentionId;
            Name = fileExtentionModel.Name;
            Foto = fileExtentionModel.Foto;
        }
    }
}
