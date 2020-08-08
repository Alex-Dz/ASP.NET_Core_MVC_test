using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            List<Usuario> allUsers = new List<Usuario>();
            using (var DB = new webapptestdbContext())
            {
                allUsers = DB.Usuario.ToList();
            }

            return View(allUsers);
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
                using (var db = new webapptestdbContext())
                {
                    Usuario userDB = new Usuario()
                    {
                        Name = user.Name
                    };
                    db.Usuario.Add(userDB);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(user);
        }
        
        [HttpGet]
        public IActionResult delete(int idUser)
        {
            using (var DB = new webapptestdbContext())
            {
                Usuario userDB = new Usuario();
                userDB = DB.Usuario.Find(idUser);
                if (userDB != null)
                {
                    DB.Remove(userDB);
                    DB.SaveChanges();
                }
            }

            return Redirect("/");
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