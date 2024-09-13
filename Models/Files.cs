namespace FileStorage.Models
{
    public class Files
    {
        public int Id { get; set; }     
        public string Name { get; set; }    
        public string Description { get; set; }
        public string IdTypeOfFile { get; set; }
        public int FolderId { get; set; }
        public string Content { get; set; }

    }
}
