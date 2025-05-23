using FileUploadApp.Dtos;
using FileUploadApp.Models;

namespace FileUploadApp.Services
{
    public interface IAuthService
    {
        Task<string> Register(UserRegisterDto request);
        Task<string> Login(UserLoginDto request);
        string CreateToken(User user);
    }
}
