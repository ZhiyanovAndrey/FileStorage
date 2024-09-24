﻿namespace FileStorage.Models
{
    public class FileModel
    {
        public int FileId { get; set; }     
        public string Name { get; set; }    
        public string? Description { get; set; }
        public int ExtentionId { get; set; }
        public int? FolderId { get; set; }
        public string? Content { get; set; }

        public ICollection <Folder?> Folders  { get; set; } // одной папке принадлежит много файлов

        public ICollection <FileExtention> fileExtention { get; set; } // многие ко многим

        public FileModel(FileModel file)
        {
                
        }

        public FileModel(string Name, string? Description, int ExtentionId, int? FolderId, string? Content)
        {
            Name=this.Name;
            Description=this.Description;
            ExtentionId=this.ExtentionId;
            FolderId=this.FolderId; 
            Content=this.Content;   
                
        }
    }
}