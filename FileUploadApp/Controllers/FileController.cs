using FileUploadApp.Data;
using FileUploadApp.Dtos;
using FileUploadApp.Models;
using FileUploadApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileUploadApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Giriş yapmış kullanıcılar erişebilsin
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadFileDto dto)
        {
            try
            {
                var username = User.Identity?.Name;
                var file = await _fileService.UploadAsync(dto, username);
                return Ok(new { message = "Dosya yüklendi", file });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var files = await _fileService.GetAllAsync();
            return Ok(files);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var username = User.Identity?.Name;

            var result = await _fileService.DeleteAsync(id, username);
            if (result == null)
                return NotFound("Dosya bulunamadı.");
            if (result == false)
                return Forbid("Bu dosyayı silme yetkiniz yok.");

            return Ok("Dosya silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var file = await _fileService.GetByIdAsyn(id);

            if (file == null)
                return NotFound();


            return Ok(file);
        }
        [HttpGet("myfiles")]
        public async Task<IActionResult> GetMyFiles()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var files = await _fileService.GetByUsernameAsync(username);
            return Ok(files);
        }


    }
}

    

