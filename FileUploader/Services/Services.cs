using FileUploader.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace FileUploader.Services
{
    public class Services : IServices
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Services(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    if (file.Length > Convert.ToInt64(filesize.MaxFileSize))
                    {
                        return "File size exceeds the maximum limit";
                    }

                    var result = await FilterFile(file);
                    return result;
                }
                else
                {
                    return "File is null or empty";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> FilterFile(IFormFile file)
        {
            var fileType = FileTypeMapper.GetFileType(file.ContentType);

            if (FileTypeMapper.IsValidEnumValue<FileType>(fileType.ToString()))
            {
                var directory = GetDirectoryForFileType(fileType);
                var result = await SavingFile(file, directory);
                return result;
            }
            else
            {
                return "Invalid file type";
            }
        }

        private string GetDirectoryForFileType(FileType fileType)
        {
            return fileType switch
            {
                FileType.Image => "uploads/images",
                FileType.Audio => "uploads/audios",
                FileType.Video => "uploads/videos",
                FileType.Document => "uploads/documents",
                FileType.Archive => "uploads/archives",
                FileType.Executable => "uploads/executables",
                _ => "uploads/others"
            };
        }

        private async Task<string> SavingFile(IFormFile file, string path)
        {
            try
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string relativeImagePath = Path.Combine(path, fileName);
                string imagePath = Path.Combine(_hostingEnvironment.ContentRootPath, relativeImagePath);

                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.ContentRootPath, path));

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}