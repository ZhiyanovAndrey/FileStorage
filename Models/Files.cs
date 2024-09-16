namespace FileStorage.Models
{
    public class Files
    {
        public int Id { get; set; }     
        public string Name { get; set; }    
        public string Description { get; set; }
        public string ExtentionId { get; set; }
        public int FolderId { get; set; }
        public string Content { get; set; }

        public Folders Folders  { get; set; } // одной папке принадлежит много файлов

        virtual public FileExtention? fileExtention { get; set; } // многие ко многим

    }
}
