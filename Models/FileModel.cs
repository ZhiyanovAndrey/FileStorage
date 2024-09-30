namespace FileStorage.Models
{
    public class FileModel
    {
        public int FileId { get; set; }     
        public string Name { get; set; }    
        public string? Description { get; set; }
        public int ExtentionId { get; set; }
        public int? FolderId { get; set; }
        public string? Content { get; set; }
        public FileExtentionModel FileExtentionModel { get; set; } // одному расширению принадлежит много файлов

        public ICollection <FolderModel?> Folders  { get; set; } // одной папке принадлежит много файлов

        //public ICollection <FileExtentionModel> fileExtention { get; set; } // многие ко многим

        public FileModel()
        {
                
        }
        //string Name, string? Description, int ExtentionId, int? FolderId, string? Content
        public FileModel(FileModel fileModel)
        {
            Name= fileModel.Name;
            Description= fileModel.Description;
            ExtentionId= fileModel.ExtentionId;
            FolderId= fileModel.FolderId; 
            Content= fileModel.Content;   
                
        }
    }
}
