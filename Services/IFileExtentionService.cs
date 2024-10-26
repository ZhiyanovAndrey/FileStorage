using FileStorage.Models;

namespace FileStorage.Services
{
    public interface IFileExtentionService
    {
        Task<FileExtentionModel> CreateFileExtentionAsync(FileExtentionModel file);
        Task<FileExtentionModel?> DeleteFileExtentionAsync(int id);
        Task<List<FileExtentionModel>> GetAllFileExtentionsFileAsync();
    }
}