namespace FileStorage.Models
{
    public class FolderModel
    {
        public int FolderId { get; set; }
        public string Name { get; set; }    
        public string FolderParentNameId { get; set; }

        public ICollection<FileModel?> Files { get; set; } // одной папке принадлежит много файлов



        public FolderModel() { }

        public FolderModel (FolderModel folder) 
        { 
            FolderId=folder.FolderId;   
            Name=folder.Name;
            FolderParentNameId=folder.FolderParentNameId;
        } 

       

    }
}
