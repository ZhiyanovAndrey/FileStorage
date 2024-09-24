using FileStorage.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.Models.Services
{
    public class FileService
    {



        private readonly Context _db;


        public FileService(Context db)
        {
            _db = db;
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
            FileModel? file = await _db.Files.FirstOrDefaultAsync(f => f.FileId == id);
            if (file != null)
            {
                _db.Files.Remove(file);
                await _db.SaveChangesAsync();
            }
            return file; //допускает null
        }

        public async Task<FileModel?> RenameFileAsync(int id, string Name)
        {
            FileModel? renamedFile = await _db.Files.FirstOrDefaultAsync(f => f.FileId == id);
            if (renamedFile != null)
            {
                renamedFile.Name = Name;
                _db.Files.Update(renamedFile);
                await _db.SaveChangesAsync();
            }
            return renamedFile;
        }









    }
}
