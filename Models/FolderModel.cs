using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FileStorage.Models
{
    [Table("Folder")]
    public class FolderModel
    {
        public int FolderModelId { get; set; }
        public string Name { get; set; }    
        public string? FolderParentNameId { get; set; }
        [JsonIgnore]
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
