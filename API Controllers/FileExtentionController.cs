using FileStorage.Models.Data;
using FileStorage.Models.Services;
using FileStorage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileExtentionController : ControllerBase
    {
        private readonly FileExtentionService _fileExtentionService;

        public FileExtentionController(Context db)
        {
            _fileExtentionService = new FileExtentionService(db);

        }

        [HttpGet]
        public async Task<IEnumerable<FileExtentionModel>> Get()
        {
            return await _fileExtentionService.GetAllFileExtentionsFileAsync();

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FileExtentionModel fileExtentionModel)
        {
            if (fileExtentionModel != null)
            {
                try
                {
                    var result = await _fileExtentionService.CreateFileExtentionAsync(fileExtentionModel);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }
    }
}
