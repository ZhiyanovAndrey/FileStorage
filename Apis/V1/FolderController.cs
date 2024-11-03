using FileStorage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileStorage.Data;
using FileStorage.Services.Implementation;
using FileStorage.Services;
using Asp.Versioning;

namespace FileStorage.Apis.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService ?? throw new ArgumentNullException(nameof(folderService));

        }
        // тестовый запрос строка


        [HttpGet]
        public async Task<IEnumerable<FolderModel>> Get()
        {
            return await _folderService.GetAllFolderAsync();

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FolderModel folderModel)
        {

            if (folderModel != null)
            {
                try
                {
                    var result = await _folderService.CreateFolderAsync(folderModel);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }



        //// запрос на создание User 
        //[HttpPost]
        //public IActionResult CreateUser([FromBody] UserModel userModel) // UserModel получаем из тела запроса
        //{
        //    if (userModel != null)
        //    {
        //        // получим User из фронта UserModel
        //        bool result = _usersService.Create(userModel);
        //        return result ? Ok() : NotFound();
        //    }
        //    return BadRequest();
        //}

        //// получаем id User из URL
        //[HttpPatch("{id}")]
        //// запрос на изменение User 
        //public IActionResult UpdateUser(int id, [FromBody] UserModel userModel)
        //{
        //    if (userModel != null)
        //    {
        //        // обращение к БД вынесли в UserService, проверку на null можно вынести или оставить
        //        bool result = _usersService.Update(id, userModel);
        //        return result ? Ok() : NotFound();
        //    }
        //    return BadRequest();
        //}

        //// получаем id User из URL
        //[HttpDelete("{id}")]
        //// запрос на удаление User 
        //public IActionResult DeleteUser(int id) // может не принимать модель, а только id
        //{
        //    // обращение к БД вынесли в UserService, а сдесь обращаемся к _userService
        //    bool result = _usersService.Delete(id);
        //    return result ? Ok() : NotFound();

        //}
    }

}
