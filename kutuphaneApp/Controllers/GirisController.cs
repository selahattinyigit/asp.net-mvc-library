using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class GirisController : Controller
    {
        Model1 ent =new Model1();
        // GET: Giris
        public ActionResult Index()
        {
            Session["kulanici_adi"] = null;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index([Bind(Include = "kullanici_adi,parola")] tb_kullanıcılar course)
        {
            TempData["mesaj"] = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (course.kullanici_adi == null || course.parola == null)
                    {
                        TempData["mesaj"] = "Lütfen Boş alanları doldurun";
                        return RedirectToAction("/Index");
                    }
                    else
                    {
                        var k = ent.tb_kullanıcılar.Where(x => x.kullanici_adi == course.kullanici_adi && x.parola == course.parola).SingleOrDefault();
                        if (k != null)
                        {
                            Session.Add("kulanici_adi", k.kullanici_adi);
                            Session.Add("id", k.id);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["mesaj"] = "Kullanıcı Adı veya Şifre hatalı";
                            return RedirectToAction("/Index");
                        }
                    }
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View();
        }
    }
}