using Microsoft.AspNetCore.Http;

namespace FileUploadApp.Dtos
{
    public class UploadFileDto
    {
        public IFormFile File { get; set; }
    }
}
