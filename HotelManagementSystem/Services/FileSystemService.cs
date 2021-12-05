
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class FileSystemService : IFileSystemService
    {
        public FileSystemService()
        {
        }

        public void DeleteFile(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public async Task UploadFile(IFormFile file, string fileName)
        {
            if (file != null && file.Length > 0)
            {
              

                using Stream fileStream = new FileStream(fileName, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
