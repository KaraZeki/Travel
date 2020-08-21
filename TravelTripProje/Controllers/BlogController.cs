using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
using Context = TravelTripProje.Models.Siniflar.Context;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context context = new Context();
        BlogYorum blogYorum = new BlogYorum();
        public ActionResult Index()
        {
            // var bloglar = context.Blogs.ToList();
            blogYorum.Deger1 = context.Blogs.ToList();//farklı sınıflardan değer çekileceği için bu yöntem kullanılıyor.
            blogYorum.Deger2 = context.Yorumlars.Take(3).ToList();
            blogYorum.Deger3 = context.Blogs.Take(4).ToList();

            return View(blogYorum);
        }


        public ActionResult BlogDetay(int id)
        {

            //var blogdetay = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger2 = context.Yorumlars.Where(x => x.BLOGID == id).ToList();

            return View(blogYorum);

        }
        public PartialViewResult PartialYorum()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult PartialYorum(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialYorum(Yorumlar y)
        {
                
                context.Yorumlars.Add(y);
                context.SaveChanges();
                return PartialView();

        }
      
    }
}