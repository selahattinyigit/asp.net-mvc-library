using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            return View(ent.tb_uyeler.ToList());
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(tb_uyeler uye)
        {
            if (ModelState.IsValid)
            {
                tb_uyeler u = new tb_uyeler();
                u.ad_soyad = uye.ad_soyad;
                u.telefon = uye.telefon;
                u.adres = uye.adres;


                ent.tb_uyeler.Add(u);





                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public ActionResult Edit(int id)
        {
            var uye = ent.tb_uyeler.Where(x => x.id == id).SingleOrDefault();
            return View(uye);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_uyeler uye)
        {
            if (ModelState.IsValid)
            {
                var u = ent.tb_uyeler.Where(x => x.id == id).SingleOrDefault();

                u.ad_soyad = uye.ad_soyad;
                u.telefon = uye.telefon;
                u.adres = uye.adres;

                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public ActionResult Delete(int id)
        {

            var uye = ent.tb_uyeler.Where(x => x.id == id).SingleOrDefault();
            return View(uye);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Delete(int id, tb_uyeler uye)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var b = ent.tb_uyeler.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            ent.tb_uyeler.Remove(b);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}