using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
using Context = TravelTripProje.Models.Siniflar.Context;

namespace TravelTripProje.Controllers
{


    public class IletisimController : Controller
    {
        // GET: Iletisim
        Context context = new Context();
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bildirim(FormCollection collection)
        {
            return View("Contact");
        }

        [HttpPost]
        public ActionResult Gonder(FormCollection collection)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage mail = new MailMessage();


            mail.IsBodyHtml = true;
            mail.From = new MailAddress("infoshayazilim@gmail.com"); //maili gönderen adres 
            string adsoyad = "İsim Soyism : " + collection["name"] + "<br/>";
            string eposta = collection["email"];
            string telefon = collection["telefon"];

            string konu = "Konu";
            string mesaj = collection["message"];
            string Body = mesaj;
            mail.Subject = konu;
            //mail.To.Add("karamehmetzeki506@gmail.com"); //mail gönderilen adres 
            mail.To.Add("karamehmetzeki506@gmail.com"); //mail gönderilen adres 

            mail.Body = Body;

            smtp.Host = "smtp.gmail.com"; //mail serverının host bilgisi 
            smtp.Port = 587; //mail serverının portu 
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("infoshayazilim@gmail.com", "Laz.1453"); //mail serverının kullanıcı bilgileri


            try
            {
                smtp.Send(mail);
                ViewBag.data = "Gönderildi..!";
                return View("Contact");
            }
            catch (Exception)
            {

                ViewBag.data = "Mail Gönderilemedi..!";
                return View("Iletisim");
            }
        }

        public PartialViewResult PartialAdres()
        {
            var degerler = context.Adresses.ToList();
            return PartialView(degerler);
        }


    }
}
