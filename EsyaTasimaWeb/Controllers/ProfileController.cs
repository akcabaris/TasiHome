using Microsoft.AspNetCore.Mvc;
using ServiceETW.Classes;
using ServiceETW.ViewModels;
using ServiceETW.Models;
using System.Collections.Generic;

namespace EsyaTasimaWeb.Controllers
{
    public class ProfileController : Base
    {


        private UserService userService;


        public ProfileController()
        {
            userService = new UserService();
        }
        public IActionResult Index()
        {
            var list = userService.GetUsers();
            return View(list);
        }
        public IActionResult Profile()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");

            var list = new List<UserVM>();
            if (loggedUserId != null)
            {

                var list2 = userService.GetUsersWhoLogin(loggedUserId.Value);
                ViewBag.Title = "Hoşgeldiniz";
                list = list2;

            }
            return View(list);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Edit(int id)
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            id = loggedUserId.Value;
            var vm = userService.GetEditUser(id);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(UserVM vm)
        {
            userService.EditUser(vm);
            return RedirectToAction("Profile", "Login");
        }
    }
}
