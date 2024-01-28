using Microsoft.AspNetCore.Mvc;
using ServiceETW.Classes;
using ServiceETW.Models;
using ServiceETW.ViewModels;
using System.Collections.Generic;

namespace EsyaTasimaWeb.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;


        public UserController()
        {
            userService = new UserService();
        }
        public IActionResult Index()
        {
            var list = userService.GetUsers();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserVM vm)
        {
            userService.AddUser(vm);
            return RedirectToAction("Index", "Login");
        }


    }
}
