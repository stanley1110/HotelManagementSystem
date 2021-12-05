
using AutoWrapper.Wrappers;
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


        private readonly int MAX_IMAGE_BYTESIZE = MAX_IMAGE_BYTESIZE_IN_MB * 1048576;
        private readonly string[] ACCEPTED_IMAGE_FILE_TYPES = new string[] { ".jpeg", ".jpg", ".png" };
        private readonly string API_BASE_ENDPOINT;
        private readonly string IMAGE_FOLDER_NAME;

        public DocumentController(IConfiguration config, IFileSystemService fileSystemService, IWebHostEnvironment hostingEnvironment)
        {
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _fileSystemService = fileSystemService;

            API_BASE_ENDPOINT = _config.GetValue<string>("ApiBaseEndPoint");
            IMAGE_FOLDER_NAME = _config.GetValue<string>("DocumentSettings:ImageFolder");
        }

        [HttpPost("file-upload")]
        public async Task<ApiResponse> UploadImage(IFormCollection files)
        {
            if (Request.Form.Files.Count < 1)
            {
                throw new ApiException("You did not upload any file.");
            }

            var formFile = Request.Form.Files[0];

            if (formFile.Length > MAX_IMAGE_BYTESIZE)
            {
                throw new ApiException($"You have uploaded a file size greater than {MAX_IMAGE_BYTESIZE_IN_MB}MB");
            }

            if (!ACCEPTED_IMAGE_FILE_TYPES.Any(s => s == Path.GetExtension(formFile.FileName).ToLower()))
            {
                throw new ApiException($"You have submitted an invalid file type, please upload only ({string.Join(",", ACCEPTED_IMAGE_FILE_TYPES)})");
            }

            try
            {
                string fn = $"{Guid.NewGuid()}_{formFile.FileName}";
                var tempFilename = Path.Combine(_hostingEnvironment.WebRootPath, IMAGE_FOLDER_NAME, fn);

                await _fileSystemService.UploadFile(formFile, tempFilename);
                return new ApiResponse("Image uploaded successfully.", result: $"{API_BASE_ENDPOINT}/{IMAGE_FOLDER_NAME}/{fn}", 200);
            }
            catch (Exception x)
            {
                throw new ApiException($"Error encountered while uploading image.\n{x.Message}");
            }
        }
    }
}
