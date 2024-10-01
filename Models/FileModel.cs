﻿namespace FileStorage.Models
{
    public class FileModel
    {
        public int FileId { get; set; }     
        public string Name { get; set; }    
        public string? Description { get; set; }
        public string? Content { get; set; }

        public int ExtentionId { get; set; }
        public FileExtentionModel FileExtentionModel { get; set; } // одному расширению принадлежит много файлов          
        
        public int FolderId { get; set; }
        public FolderModel? Folder { get; set; } // файл принадлежит одной папке


        public FileModel()
        {
                
        }
        //string Name, string? Description, int ExtentionId, int? FolderId, string? Content
        public FileModel(FileModel fileModel)
        {
            Name= fileModel.Name;
            Description= fileModel.Description;
            ExtentionId= fileModel.ExtentionId;
            FolderId= fileModel.FolderId; 
            Content= fileModel.Content;   
                
        }
    }
}
