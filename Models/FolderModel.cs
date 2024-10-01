using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorage.Models
{
    [Table("Folder")]
    public class FolderModel
    {
        public int FolderId { get; set; }
        public string Name { get; set; }    
        public string? FolderParentNameId { get; set; }

        public virtual ICollection<FileModel> Files { get; set; } = new List<FileModel>();   // одному расширению принадлежит много файлов



        public FolderModel() { }

        public FolderModel (FolderModel folder) 
        { 
            FolderId=folder.FolderId;   
            Name=folder.Name;
            FolderParentNameId=folder.FolderParentNameId;
        } 

       

    }
}
