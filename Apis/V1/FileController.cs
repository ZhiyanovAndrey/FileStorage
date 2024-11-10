using Asp.Versioning;
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

        // GET api/<FileController>/5/folder
        [HttpGet("{folderId}/folder")]
        public async Task<IEnumerable<FileModel>> GetFilesFromFolder(int folderId)
        {
            return await _fileService.GetFilesFromFolderAsync(folderId);

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

        [HttpPut("{id}/move")]
        public async Task<IActionResult> Move(int id, [FromBody] string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new RequaeredParameterMeetingExeption(nameof(value));
            }


            if (!int.TryParse(value, out int newId))
            {
                throw new DomainException($"Необходимо ввести целое число {nameof(value)}");
            }

            FileModel? file;
            try
            {
                file = await _fileService.MoveFileInFoldersByIdAsync(id, newId);

            }
            catch (FileDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }

            catch (FolderDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(file);

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
