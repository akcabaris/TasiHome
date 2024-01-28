using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EsyaTasimaWeb.Controllers
{
    public class Base : Controller
    {
        public bool IsSessionLive()
        {
            var value = HttpContext.Session.GetString("UserSession");
            if (value == null)
            {
                return false;
            }
            else
            { return true; }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsSessionLive() == false)
            {
                TempData["error"] = "Sayfaları Görüntüleyebilmek İçin Giriş Yapmanız Gerekmektedir.";
                filterContext.Result = RedirectToAction("Index", "Login");
                return;
            }
        }
    }
}
