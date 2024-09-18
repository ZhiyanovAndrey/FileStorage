namespace FileStorage.Models
{
    public class Files
    {
        public int FileId { get; set; }     
        public string Name { get; set; }    
        public string? Description { get; set; }
        public string ExtentionId { get; set; }
        public int? FolderId { get; set; }
        public string? Content { get; set; }

        public ICollection <Folders?> Folders  { get; set; } // одной папке принадлежит много файлов

        public ICollection <FileExtention> fileExtention { get; set; } // многие ко многим

    }
}
