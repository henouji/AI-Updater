using AI_Updater.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AI_Updater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IBlobService _blobService;
        public UpdateController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string fileName = file.FileName;
            using var stream = file.OpenReadStream();
            var result = await _blobService.UploadFileAsync(stream, file.FileName);
            return Ok("File uploaded");
        }

    }
}
