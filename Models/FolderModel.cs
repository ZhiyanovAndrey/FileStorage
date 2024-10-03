using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorage.Models
{
    [Table("Folder")]
    public class FolderModel
    {
        public int FolderModelId { get; set; }
        public string Name { get; set; }    
        public string? FolderParentNameId { get; set; }

        public virtual ICollection<FileModel> Files { get; set; } = new List<FileModel>();   // одной папке принадлежит много файлов



        public FolderModel() { }

        public FolderModel (FolderModel folder) 
        { 
            FolderModelId=folder.FolderModelId;   
            Name=folder.Name;
            FolderParentNameId=folder.FolderParentNameId;
        } 

       

    }
}
