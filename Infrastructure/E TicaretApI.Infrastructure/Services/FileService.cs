using E_TicaretApI.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_TicaretApI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            foreach (IFormFile file in files)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string fullPath = Path.Combine(uploadPath, fileName);

                await using FileStream fileStream = new(
                    fullPath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    1024 * 1024,
                    useAsync: true);

                await file.CopyToAsync(fileStream);
            }
        }
    }
}
