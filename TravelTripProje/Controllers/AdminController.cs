using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTripProje.Models.Siniflar;
using System.Web.Mvc;
using System.Text;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var bloglar = context.Blogs.ToList();
            return View(bloglar);
        }

        public ActionResult SIL(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var blog = context.Blogs.Find(id);

            return View(blog);
        }

        public ActionResult Guncelle(Blog p)
        {
            var blog = context.Blogs.Find(p.ID);

            blog.Baslik = p.Baslik;
            blog.Tarih = p.Tarih;
            blog.Aciklama = p.Aciklama;
            blog.BlogImage = p.BlogImage;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult BlogEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BlogEkle(Blog p)
        {
            context.Blogs.Add(p);
            context.SaveChanges();
               
            return View();
        }

        public ActionResult Iletisim()
        {
            var adres = context.Adresses.ToList();
            return View(adres);
        }

        
        [HttpGet]
        public ActionResult AdresGetir(int id)
        {
            var adres = context.Adresses.Find(id);

            return View(adres);
        }


        public ActionResult AdresGuncelle(Adress p)
        {
            var adress = context.Adresses.Find(p.ID);

            adress.AcikAdres = p.AcikAdres;
            adress.Telefon = p.Telefon;
            adress.Fax = p.Fax;
            adress.Mail = p.Mail;
            context.SaveChanges();

            return RedirectToAction("AdresGetir");
        }
    }
}