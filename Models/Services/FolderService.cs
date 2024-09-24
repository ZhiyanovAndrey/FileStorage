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
            FolderModel? Folder = await _db.Folders.FirstOrDefaultAsync(f => f.FolderId == id);
            if (Folder != null)
            {
                _db.Folders.Remove(Folder);
                await _db.SaveChangesAsync();
            }
            return Folder; //допускает null
        }

    }
}
