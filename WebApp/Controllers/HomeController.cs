using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.Models.DB;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User user = new User();
            return View(user.getAllUsers());
        }

        [HttpGet]
        public IActionResult newUser()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult newUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.saveUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult editUser(int idUser)
        {
            User user = new User();
            user = user.getUserById(idUser);
            if (user != null)
            {
                return View("newUser", user);
            }
            else
            {
                ViewData["userNotFound"] = true;
                return View("Index", user.getAllUsers());
            }
        }

        [HttpPost]
        public IActionResult editUser(User user)
        {
            user = user.updateUser(user);
            if (user != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["userNotFound"] = true;
                return View("Index", user.getAllUsers());
            }
        }

        [HttpGet]
        public IActionResult deleteUser(int idUser)
        {
            User user = new User();
            user.deleteUser(idUser);

            return RedirectToAction("Index");
        }

        public IActionResult Other()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}