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
        public async Task<IEnumerable<FileModel>> Get()
        {
            return await _fileExtentionService.GetAllFileExtentionsFileAsync();

        }



        // POST api/<FileController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FileModel fileModel)
        {
            if (fileModel != null)
            {
                try
                {
                    var result = await _fileExtentionService.CreateFileAsync(fileModel);
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
