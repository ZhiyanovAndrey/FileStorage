using FileStorage.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Controllers
{
    public class FolderController : Controller
    {

        private readonly Context _db;
        public FolderController(Context db)
        {
            _db = db;
         
        }
        // тестовый запрос строка
        [AllowAnonymous] // не требует авторизации
        [HttpGet("test")]
        public IActionResult Test()
        {
            string t = $"";
            return Ok($"Привет! Сервер запущен {DateTime.Now.ToString("D")} в {DateTime.Now.ToString("t")}");
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



