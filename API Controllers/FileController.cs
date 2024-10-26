using FileStorage.Data;
using FileStorage.Models;
using FileStorage.Services;
using Microsoft.AspNetCore.Mvc;


namespace FileStorage.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService ??throw new ArgumentNullException(nameof(fileService));

        }

        // GET: api/<FileController>
        [HttpGet]
        public async Task<IEnumerable<FileModel>> GetFiles()
        {
            return await _fileService.GetAllFileAsync();
           
        }


        // GET api/<FileController>/5
        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            return file == null ? NotFound() : Ok(file);
        }


        // POST api/<FileController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FileModel fileModel)
        {
            if (fileModel != null)
            {
                try
                {
                    var result = await _fileService.CreateFileAsync(fileModel);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _fileService.DeleteFileAsync(id);
            return result == null ? NotFound() : Ok();
        }



    }
}
