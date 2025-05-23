using FileUploadApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileUploadApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FileModel> FileModels{ get; set; }
        
    }
}
