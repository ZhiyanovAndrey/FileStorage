namespace FileStorage.Models
{
    public class Folders
    {
        public int FolderId { get; set; }
        public string Name { get; set; }    
        public string FolderParentNameId { get; set; }

       

        // папка принадлежит файлу, покажем БД что это ключ на Files ниже
        public int FileId { get; set; }
        public Files? files { get; set; }

       

    }
}
