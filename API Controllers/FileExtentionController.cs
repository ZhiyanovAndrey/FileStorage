﻿using FileStorage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileStorage.Data;
using FileStorage.Services.Implementation;
using FileStorage.Services;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileExtentionController : ControllerBase
    {
        private readonly IFileExtentionService _fileExtentionService;

        public FileExtentionController(IFileExtentionService fileExtentionService)
        {
            _fileExtentionService = fileExtentionService ??throw new ArgumentNullException(nameof(fileExtentionService));

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
