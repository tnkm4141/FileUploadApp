using FileUploadApp.Data;
using FileUploadApp.Dtos;
using FileUploadApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileUploadApp.Services
{
    public class FileService : IFileService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FileService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<FileModel> UploadAsync(UploadFileDto dto, string uploadedBy)
        {
            if (dto.File == null || dto.File.Length == 0)
                throw new Exception("Dosya geçersiz.");

            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.File.FileName);
            var filePath = Path.Combine(uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            var file = new FileModel
            {
                FileName = fileName,
                FilePath = "/uploads/" + fileName,
                UploadDate = DateTime.Now,
                UploadedBy = uploadedBy
            };

            _context.FileModels.Add(file);
            await _context.SaveChangesAsync();

            return file;
        }
        public async Task<List<FileModel>> GetByIdAsyn(int id)
        {
            return await _context.FileModels
                .Where(f => f.Id == id)
                .ToListAsync();
        }


        public async Task<List<FileModel>> GetAllAsync()
        {
            return await Task.FromResult(_context.FileModels.ToList());
        }

        public async Task<bool?> DeleteAsync(int id, string username)
        {
            var file = await _context.FileModels.FirstOrDefaultAsync(f => f.Id == id);

            if (file == null)
                return null;

            if (file.UploadedBy != username)
                return false;

            // Fiziksel dosya silme
            var fullPath = Path.Combine(_env.WebRootPath, file.FilePath);
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);

            _context.FileModels.Remove(file);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<FileModel>> GetByUsernameAsync(string username)
        {
            return await _context.FileModels
                .Where(f => f.UploadedBy == username)
                .ToListAsync();
        }

    }
}
