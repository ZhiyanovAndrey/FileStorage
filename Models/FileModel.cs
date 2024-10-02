using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorage.Models
{
    [Table("File")]
    public class FileModel
    {

        public int FileModelId { get; set; }     
        public string Name { get; set; }    
        public string? Description { get; set; }
        public string? Content { get; set; }

        //Foreign key for FileExtentionId
       
        public int FileExtentionModelId { get; set; }
        public virtual FileExtentionModel? FileExtentionModel { get; set; } = null!; // одному расширению принадлежит много файлов          

        public int FolderModelId { get; set; }
        public virtual FolderModel? FolderModel { get; set; } = null!; // файл принадлежит одной папке


        public FileModel()
        {
                
        }
        //string Name, string? Description, int ExtentionId, int? FolderId, string? Content
        public FileModel(FileModel fileModel)
        {
            Name= fileModel.Name;
            Description= fileModel.Description;
            FileExtentionModelId = fileModel.FileExtentionModelId;
            FolderModelId = fileModel.FolderModelId; 
            Content= fileModel.Content;   
                
        }
    }
}
