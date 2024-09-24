using FileStorage.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.Models.Services
{
    public class FolderService
    {
        private readonly Context _db;


        public FolderService(Context db)
        {
            _db = db;
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
            FolderModel? folder = await _db.Folders.FirstOrDefaultAsync(f => f.FolderId == id);
            if (folder != null)
            {
                _db.Folders.Remove(folder);
                await _db.SaveChangesAsync();
            }
            return folder; //допускает null
        }

    }
}
