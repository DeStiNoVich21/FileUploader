using FileUploader.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FileUploader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IServices services;

        public FileController(IServices services)
        {
            this.services = services;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile file)
        {
            try
            {
                var result = await services.UploadFileAsync(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
