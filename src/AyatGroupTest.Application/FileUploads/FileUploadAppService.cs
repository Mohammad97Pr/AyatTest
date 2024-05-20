using Abp.Application.Services;
using Abp.UI;
using AyatGroupTest.Authorization.Accounts.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyatGroupTest.FileUploads
{
    public class FileUploadAppService : IApplicationService
    {
        private static readonly string ImagesFolder = Path.Combine("Uploads", "Images");
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadAppService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<UploadedImageInfo> SaveImageAsync(IFormFile file)
        {
            try
            {
                var fileInfo = new UploadedImageInfo { Type = GetAndCheckImageFileType(file) };

                var fileName = GenerateUniqueImageFileName(file.FileName);
                var pathToSave = GetPathToSaveImage(fileName);
                using (var stream = new FileStream(pathToSave, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                fileInfo.PathToSave = pathToSave;
                fileInfo.RelativePath = GetImageRelativePath(fileName);
                return fileInfo;
            }
            catch (Exception ex) { throw; }
        }

        private ImageType GetAndCheckImageFileType(IFormFile file)
        {
            foreach (ImageType type in Enum.GetValues(typeof(ImageType)))
            {
                if (file.ContentType.Contains(type.ToString().ToLower()))
                    return type;
            }

            throw new UserFriendlyException("UploadedImageFileTypeIsNotAcceptable", $"FileName: {file.FileName}");
        }
        private string GetPathToSaveImage(string fileName)
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, ImagesFolder, fileName);
        }
        public string GetImageRelativePath(string fileName)
        {
            return Path.Combine(ImagesFolder, fileName);
        }
        private string GenerateUniqueImageFileName(string fileName)
        {
            return $"ItemImage-{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        }

    }
}
