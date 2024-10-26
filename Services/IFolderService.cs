using FileStorage.Models;

namespace FileStorage.Services
{
    public interface IFolderService
    {
        Task<FolderModel> CreateFolderAsync(FolderModel folder);
        Task<FolderModel?> DeleteFolderAsync(int id);
        Task<List<FolderModel>> GetAllFolderAsync();
        Task<FolderModel?> GetFolderByIdAsync(int id);
    }
}