using FileUploadApp.Dtos;
using FileUploadApp.Models;

namespace FileUploadApp.Services
{
    public interface IFileService
    {
        Task<FileModel> UploadAsync(UploadFileDto dto, string uplodedBy);
        Task<List<FileModel>> GetAllAsync();
        Task<bool?> DeleteAsync(int id, string username);
        Task<List<FileModel>> GetByIdAsyn(int id);
        Task<IEnumerable<FileModel>> GetByUsernameAsync(string username);

    }
}