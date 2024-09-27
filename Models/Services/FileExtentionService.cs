using FileStorage.Models.Data;

namespace FileStorage.Models.Services
{
    public class FileExtentionService
    {
        private readonly Context _db;

        public FileExtentionService(Context db)
        {
            _db = db;
        }

        public async Task<FileModel?> GetFileByIdAsync(int id)
        {
            return await _db.Files.FirstOrDefaultAsync(c => c.FileId == id);
        }

        public async Task<List<FileModel>> GetAllFileAsync()
        {
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
            FileModel? file = await _db.Files.FirstOrDefaultAsync(f => f.FileId == id);
            if (file != null)
            {
                _db.Files.Remove(file);
                await _db.SaveChangesAsync();
            }
            return file; //допускает null
        }
    }
}
