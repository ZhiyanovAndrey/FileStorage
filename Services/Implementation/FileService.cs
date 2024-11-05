using FileStorage.Data;
using FileStorage.Domain.Exceptions;
using FileStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FileStorage.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly Context _db;

        public FileService(Context db)
        {
            _db = db;
        }

        public async Task<FileModel?> GetFileByIdAsync(int id)
        {
            return await _db.Files.FirstOrDefaultAsync(c => c.FileModelId == id);
        }

        public async Task<List<FileModel>> GetAllFileAsync()
        {
            //throw new DomainException("Пошло не так");
            return await _db.Files.ToListAsync();
        }

        public async Task<FileModel> CreateFileAsync(FileModel file)
        {

            FileModel newFile = new FileModel(file);
            await _db.Files.AddAsync(newFile);
            await _db.SaveChangesAsync();

            return newFile;


        }

        public async Task<FileModel?> DeleteFileAsync(int id)
        {
            FileModel? file = await _db.Files.FirstOrDefaultAsync(f => f.FileModelId == id);
            if (file != null)
            {
                _db.Files.Remove(file);
                await _db.SaveChangesAsync();
            }
            return file; //допускает null
        }

        public async Task<FileModel?> RenameFileAsync(int id, string Name)
        {
            FileModel? renamedFile = await _db.Files.FirstOrDefaultAsync(f => f.FileModelId == id);
            if (renamedFile != null)
            {
                renamedFile.Name = Name;
                _db.Files.Update(renamedFile);
                await _db.SaveChangesAsync();
            }
            return renamedFile;
        }


        // перемещение файлов из папки в папку
        public async Task<FileModel?> MoveFileInFoldersByIdAsync(int id, int numberOfFolderToMove)
        {
            var movedFile = await _db.Files.FirstOrDefaultAsync(c => c.FileModelId == id);
            if (movedFile != null)
            {
                movedFile.FolderModelId = numberOfFolderToMove;

                _db.Files.Update(movedFile);
                await _db.SaveChangesAsync();
            }
            return movedFile;

        }

        // сделать выборку файлов в папке





    }
}
