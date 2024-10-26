using FileStorage.Data;
using FileStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.Services.Implementation
{
    public class FolderService : IFolderService
    {
        private readonly Context _db;


        public FolderService(Context db)
        {
            _db = db;
        }


        public async Task<FolderModel?> GetFolderByIdAsync(int id)
        {
            return await _db.Folders.FirstOrDefaultAsync(c => c.FolderModelId == id);
        }

        public async Task<List<FolderModel>> GetAllFolderAsync()
        {
            return await _db.Folders.ToListAsync();
        }

        public async Task<FolderModel> CreateFolderAsync(FolderModel folder)
        {

            FolderModel newFolder = new FolderModel(folder);
            await _db.Folders.AddAsync(newFolder);
            await _db.SaveChangesAsync();

            return newFolder;


        }

        public async Task<FolderModel?> DeleteFolderAsync(int id)
        {
            FolderModel? folder = await _db.Folders.FirstOrDefaultAsync(f => f.FolderModelId == id);
            if (folder != null)
            {
                _db.Folders.Remove(folder);
                await _db.SaveChangesAsync();
            }
            return folder; //допускает null
        }

    }
}
