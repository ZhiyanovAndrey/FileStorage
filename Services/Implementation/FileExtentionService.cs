using FileStorage.Data;
using FileStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.Services.Implementation
{
    public class FileExtentionService : IFileExtentionService
    {
        private readonly Context _db;

        public FileExtentionService(Context db)
        {
            _db = db;
        }


        public async Task<List<FileExtentionModel>> GetAllFileExtentionsFileAsync()
        {
            return await _db.FileExtentions.ToListAsync();
        }

        public async Task<FileExtentionModel> CreateFileExtentionAsync(FileExtentionModel file)
        {

            FileExtentionModel newFile = new FileExtentionModel(file);
            await _db.FileExtentions.AddAsync(newFile);
            await _db.SaveChangesAsync();

            return newFile;


        }

        public async Task<FileExtentionModel?> DeleteFileExtentionAsync(int id)
        {
            FileExtentionModel? file = await _db.FileExtentions.FirstOrDefaultAsync(f => f.FileExtentionModelId == id);
            if (file != null)
            {
                _db.FileExtentions.Remove(file);
                await _db.SaveChangesAsync();
            }
            return file; //допускает null
        }
    }
}
