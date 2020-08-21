using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;
namespace TravelTripProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var kullanıcı = context.Admins.FirstOrDefault(x=>x.Kullanici==admin.Kullanici && x.Sifre==admin.Sifre);


            if (kullanıcı != null)
            {
                FormsAuthentication.SetAuthCookie(kullanıcı.Kullanici, false);//2. parametre araştırılacak
                Session["Kullanici"] = kullanıcı.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}