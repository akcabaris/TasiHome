using Microsoft.AspNetCore.Mvc;
using ServiceETW.Classes;
using ServiceETW.Models;
using ServiceETW.ViewModels;

namespace EsyaTasimaWeb.Controllers
{
    public class IlanController : Base
    {
        private UserService userService;
        private IlanService ilanService;


        public IlanController()
        {
            userService = new UserService();
            ilanService = new IlanService();
        }
        public IActionResult Index()
        {
            var list = ilanService.GetIlans();
            return View(list);
        }


        public IActionResult Mine()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            var list = ilanService.GetIlansWhoLogin(loggedUserId.Value);
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(IlanVM vm)
        {
            int userId = 1;
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            userId = loggedUserId.Value;
            ilanService.AddIlan(vm, userId);
            return RedirectToAction("Mine", "Ilan");
        }

        public IActionResult Edit(int id)
        {
            var vm = ilanService.GetEditIlan(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(IlanVM vm)
        {
            ilanService.EditIlan(vm);
            return RedirectToAction("Mine", "Ilan");
        }

        public IActionResult Delete(int id)
        {
            var result = ilanService.DeleteIlan(id);

            if (result == false)
            {
                TempData["message"] = "Silme İşlemi Tamamlanamadı";
            }
            else
                TempData["message"] = "Silme İşlemi Tamamlandı";



            return RedirectToAction("Mine", "Ilan");
        }
    }
}
