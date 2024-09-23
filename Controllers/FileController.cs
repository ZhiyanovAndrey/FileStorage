﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Controllers
{
    public class FileController : Controller
    {
        // GET: FileController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // API POST: FileController/Create
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel userModel) // UserModel получаем из тела запроса
        {
            if (userModel != null)
            {
                // получим User из фронта UserModel
                bool result = _usersService.Create(userModel);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        // POST: FileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
