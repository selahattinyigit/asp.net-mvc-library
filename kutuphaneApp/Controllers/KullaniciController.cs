using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class KullaniciController : Controller
    {
        Model1 ent = new Model1();
        // GET: Kullanici
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(tb_kullanıcılar kullanici)
        {
            TempData["mesaj"] = null;
            if (ModelState.IsValid)
            {
                var kk = ent.tb_kullanıcılar.Where(x => x.kullanici_adi == kullanici.kullanici_adi).SingleOrDefault();
                if (kk!=null)
                {
                    TempData["mesaj"] = "Kullanıcı Adı Kullanılıyor";
                    return RedirectToAction("Create");
                }
                tb_kullanıcılar k = new tb_kullanıcılar();
                k.ad_soyad = kullanici.ad_soyad;
                k.kullanici_adi = kullanici.kullanici_adi;
                k.parola = kullanici.parola;


                ent.tb_kullanıcılar.Add(k);





                ent.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(kullanici);
        }
        public ActionResult Edit()
        {
            string id = Session["id"].ToString();
            var k = ent.tb_kullanıcılar.Where(x => x.id.ToString() == id).SingleOrDefault();
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_kullanıcılar kullanici)
        {
            if (ModelState.IsValid)
            {
                var k = ent.tb_kullanıcılar.Where(x => x.id == id).SingleOrDefault();
                var kk = ent.tb_kullanıcılar.Where(x => x.kullanici_adi == kullanici.kullanici_adi).SingleOrDefault();
                if (kk != null && k.id!=kullanici.id)
                {
                    TempData["mesaj"] = "Kullanıcı Adı Kullanılıyor";
                    return RedirectToAction("Edit");
                }
                
                k.ad_soyad = kullanici.ad_soyad;
                k.kullanici_adi = kullanici.kullanici_adi;
                k.parola = kullanici.parola;


                ent.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View();
        }
    }
}