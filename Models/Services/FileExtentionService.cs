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

        //public async Task<FileExtentionModel?> GetFileExtentionByIdAsync(int id)
        //{
        //    return await _db.FileExtentions.FirstOrDefaultAsync(c => c.FileId == id);
        //}

        //public async Task<List<FileExtentionModel>> GetAllFileAsync()
        //{
        //    return await _db.FileExtentions.ToListAsync();
        //}

        //public async Task<FileExtentionModel> CreateFileAsync(FileExtentionModel file)
        //{

        //    FileExtentionModel newFile = new FileExtentionModel(file);
        //    await _db.FileExtentions.AddAsync(newFile);
        //    await _db.SaveChangesAsync();

        //    return newFile;


        //}

        //public async Task<FileExtentionModel?> DeleteFileAsync(int id)
        //{
        //    FileExtentionModel? file = await _db.FileExtentions.FirstOrDefaultAsync(f => f.FileId == id);
        //    if (file != null)
        //    {
        //        _db.FileExtentions.Remove(file);
        //        await _db.SaveChangesAsync();
        //    }
        //    return file; //допускает null
        //}
    }
}
