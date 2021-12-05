using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interface
{ 
    public interface IFileSystemService
    {
        Task UploadFile(IFormFile file, string fileName);
        void DeleteFile(string fileName);
    }
}
