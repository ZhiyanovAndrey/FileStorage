using FileStorage.Models;

namespace FileStorage.Services
{
    public interface IFileService
    {
        Task<FileModel> CreateFileAsync(FileModel file);
        Task<FileModel?> DeleteFileAsync(int id);
        Task<List<FileModel>> GetAllFileAsync();
        Task<FileModel?> GetFileByIdAsync(int id);
        Task<FileModel?> RenameFileAsync(int id, string Name);
        Task<FileModel?> MoveFileInFoldersByIdAsync(int id, int numberOfFolderToMove);
    }
}