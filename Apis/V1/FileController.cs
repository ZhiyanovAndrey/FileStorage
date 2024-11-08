using Asp.Versioning;
using FileStorage.Data;
using FileStorage.Domain.Exceptions;
using FileStorage.Models;
using FileStorage.Services;
using Microsoft.AspNetCore.Mvc;


namespace FileStorage.Apis.V1
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));

        }

        // GET: api/<FileController>
        [HttpGet]
        public async Task<IEnumerable<FileModel>> GetFiles()
        {
            return await _fileService.GetAllFileAsync();

        }



        // GET api/<FileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            return file == null ? NotFound() : Ok(file); // 2 теста нашелся или нет
        }

        //[HttpGet("folder/{id}")]
        //public async Task<IEnumerable<FileModel>> GetFilesFromFolder(int folderId)
        //{
        //    //var file = await _fileService //.GetFileByIdAsync(folderId);
        //    return file == null ? NotFound() : Ok(file);

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
        [HttpPut("{id}/rename")]
        public async Task<IActionResult> Rename(int id, [FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name)) // если строка пустая или одни пробелы
            {
                throw new RequaeredParameterMeetingExeption(nameof(name));
            }

            var file = await _fileService.RenameFileAsync(id, name);
            return file == null ? NotFound() : Ok(file);
                       
        }

        public async Task<IActionResult> Put(int id, [FromBody] FileModel value)
        {
            if (string.IsNullOrWhiteSpace(value.Name))
            {
                throw new RequaeredParameterMeetingExeption(nameof(value));
            }




            //if (value != null)
            //{
            //    var result = _fileService.MoveFileInFoldersByIdAsync();
            //return result ? Ok() : NotFound();
            //}
            return Ok();
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
