using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Controllers
{
    public class FolderController : Controller
    {

        // тестовый запрос
        [HttpGet("test")]
        public async Task Test()
        {
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync($"Привет! Сервер запущен {DateTime.Now.ToString("D")} в {DateTime.Now.ToString("t")}");
            string t = $"";
            //return Ok($"Привет! Сервер запущен {DateTime.Now.ToString("D")} в {DateTime.Now.ToString("t")}");
        }

    }
}
