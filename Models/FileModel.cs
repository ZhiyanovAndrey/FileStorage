﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorage.Models
{
    [Table("File")]
    public class FileModel
    {
        public int FileId { get; set; }     
        public string Name { get; set; }    
        public string? Description { get; set; }
        public string? Content { get; set; }

        public int FileExtentionId { get; set; }
        public virtual FileExtentionModel FileExtentionModel { get; set; } = null!; // одному расширению принадлежит много файлов          

        public int FolderId { get; set; }
        public virtual FolderModel? FolderModel { get; set; } = null!; // файл принадлежит одной папке


        public FileModel()
        {
                
        }
        //string Name, string? Description, int ExtentionId, int? FolderId, string? Content
        public FileModel(FileModel fileModel)
        {
            Name= fileModel.Name;
            Description= fileModel.Description;
            FileExtentionId = fileModel.FileExtentionId;
            FolderId= fileModel.FolderId; 
            Content= fileModel.Content;   
                
        }
    }
}
