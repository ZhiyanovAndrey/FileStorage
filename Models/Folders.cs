namespace FileStorage.Models
{
    public class Folders
    {
        public int FolderId { get; set; }
        public string Name { get; set; }    
        public string FolderParentNameId { get; set; }

        virtual public Files? files { get; set; } // многие ко многим
    }
}
