using FileStorage.Models;
using FileStorage.Models.Data;
using FileStorage.Models.Services;
using Microsoft.AspNetCore.Mvc;


namespace FileStorage.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileController(Context db)
        {
            _fileService = new FileService(db);

        }

        // GET: api/<FileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var customer = _fileService.GetFileByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        //[HttpGet("customers/{phone}")]
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        //public IActionResult GetCustomerByPhone(string phone)
        //{
        //}

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
