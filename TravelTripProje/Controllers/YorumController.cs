using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTripProje.Models.Siniflar;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Context = TravelTripProje.Models.Siniflar.Context;

namespace TravelTripProje.Controllers
{
    public class YorumController : Controller
    {
        // GET: Yorum

        Context context = new Context();
        public ActionResult Index()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult SIL(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(yorum);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
     
      
       
        public ActionResult YorumGetir(int id)
        {
            var yrm = context.Yorumlars.Find(id);
            return View("YorumGetir",yrm);

        }

       [HttpPost]
        public ActionResult Guncelle(Yorumlar y)
        {
            var yrm = context.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;

            context.SaveChanges();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult YorumEkle()
        {
            List<SelectListItem> degerler = (from i in context.Blogs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Baslik,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YorumEkle(Yorumlar yr)
        {
            var yrm = context.Yorumlars.Where(m => m.BLOGID == yr.Blog.ID).FirstOrDefault();
           
            context.Yorumlars.Add(yrm);
            context.SaveChanges();
            
            return View();
        }


    }
}