using Microsoft.AspNetCore.Mvc;

namespace FileUploader.Services
{
    public interface IServices
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
