using EsyaTasimaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceETW.Classes;
using ServiceETW.ViewModels;

namespace EsyaTasimaWeb.Controllers
{
    public class LoginController : Controller
    {
        private UserService userService;

        public LoginController()
        {
            userService = new UserService();
        }


        public IActionResult Index()
        {
            var list = userService.GetUsers();
            ViewBag.Title = "Hoşgeldiniz";
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var list = userService.GetUsers();
            int userId = 1;

            if (list.Any(user => user.Email == username && user.Password == password))
            {
                userId = list.First(user => user.Email == username && user.Password == password).Id;
                // ...
                userService.GetUsersWhoLogin(userId);
                ViewBag.Mesaj = "Giriş Başarılı";
                HttpContext.Session.SetString("UserSession", "1");
                HttpContext.Session.SetInt32("LoggedUserId", userId);
                return RedirectToAction("Index", "Home");
                // veya anasayfaya yönlendirme
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Mesaj"] = "Hatalı Email ya da Şifre girildi";
            }

            return View();
        }




    }
}

