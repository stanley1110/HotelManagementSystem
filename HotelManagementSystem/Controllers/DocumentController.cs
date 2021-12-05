
using AutoWrapper.Wrappers;
using HotelManagementSystem.Data;
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Route("api/document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private const int MAX_IMAGE_BYTESIZE_IN_MB = 10;
        private readonly IConfiguration _config;
        private readonly IFileSystemService _fileSystemService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataContext context;

        private readonly int MAX_IMAGE_BYTESIZE = MAX_IMAGE_BYTESIZE_IN_MB * 1048576;
        private readonly string[] ACCEPTED_IMAGE_FILE_TYPES = new string[] { ".jpeg", ".jpg", ".png" };
        private readonly string API_BASE_ENDPOINT;
        private readonly string IMAGE_FOLDER_NAME;
        private readonly string BaseImagePath;

        public DocumentController(IConfiguration config, IFileSystemService fileSystemService, IWebHostEnvironment hostingEnvironment, DataContext context)
        {
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _fileSystemService = fileSystemService;

            API_BASE_ENDPOINT = _config.GetValue<string>("ApiBaseEndPoint");
            IMAGE_FOLDER_NAME = _config.GetValue<string>("DocumentSettings:ImageFolder");
            BaseImagePath = _config.GetValue<string>("BaseImagePath");
            this.context = context;
        }

        [HttpPost("file")]
        public async Task<ApiResponse> UploadImage(IFormCollection files)
        {
            ApiResponse result = new ApiResponse();
            if (Request.Form.Files.Count < 1)
            {
                throw new ApiException("You did not upload any file.");
            }

            var formFile = Request.Form.Files;
            foreach (var f in formFile)
            {
                if (f.Length > MAX_IMAGE_BYTESIZE)
                {
                    throw new ApiException($"You have uploaded a file size greater than {MAX_IMAGE_BYTESIZE_IN_MB}MB");
                }

                if (!ACCEPTED_IMAGE_FILE_TYPES.Any(s => s == Path.GetExtension(f.FileName).ToLower()))
                {
                    throw new ApiException($"You have submitted an invalid file type, please upload only ({string.Join(",", ACCEPTED_IMAGE_FILE_TYPES)})");
                }

                try
                {
                    string fn = $"{Guid.NewGuid()}_{f.FileName}";
                    var tempFilename = Path.Combine(_hostingEnvironment.WebRootPath, IMAGE_FOLDER_NAME, fn);

                    await _fileSystemService.UploadFile(f, tempFilename);
                   
                     result =  new ApiResponse("Image uploaded successfully.", result: $"{BaseImagePath}/{IMAGE_FOLDER_NAME}/{fn}", 200);
                }
                catch (Exception x)
                {
                    throw new ApiException($"Error encountered while uploading image.\n{x.Message}");
                }
            }

            return result;
         }
        [HttpGet("file")]
        public async Task<ApiResponse> GetImageAsync(string imagepath)
        {
            
            if (!string.IsNullOrEmpty(imagepath))
            {
                ApiResponse result = new ApiResponse();
                Byte[] b = System.IO.File.ReadAllBytes(imagepath);
                return new ApiResponse(await Task.Run(() => File(b, "image/png")));
            }
            else
            {
                return new ApiResponse("image path is null or not valid");
            }
        }




    }
}
