namespace FileStorage.Models
{
    public class Folder
    {
        public int FolderId { get; set; }
        public string Name { get; set; }    
        public string FolderParentNameId { get; set; }

       

        // папка принадлежит файлу
        public int FileId { get; set; }
        public FileModel? files { get; set; }

       

    }
}
