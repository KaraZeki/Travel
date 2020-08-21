using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Blogs.Take(4).ToList();
             
            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Destination()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        
        public PartialViewResult partial1()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID >=10).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult partial2()
        {
            var deger = context.Blogs.Where(x => x.ID ==1).ToList();

            return PartialView(deger);
        }

        public PartialViewResult partial3()
        {
            var bloglar = context.Blogs.Take(10).ToList();
            return PartialView(bloglar);
        }

        public PartialViewResult partial4_1()
        {
            var blog = context.Blogs.Where(m=> m.ID >= 6).Take(3).ToList();
           

            return PartialView(blog);

        }
        public PartialViewResult partial4_2()
        {
            var blog = context.Blogs.Where(m => m.ID < 6).Take(3).ToList();
            return PartialView(blog);
        }

    }
}