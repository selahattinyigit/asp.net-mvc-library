using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            return View(ent.tb_yazarlar.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(tb_yazarlar yazar)
        {
            if (ModelState.IsValid)
            {
                tb_yazarlar y = new tb_yazarlar();
                y.ad_soyad = yazar.ad_soyad;
                ent.tb_yazarlar.Add(y);

               


               
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yazar);
        }
        public ActionResult Edit(int id)
        {
            var yzr = ent.tb_yazarlar.Where(x => x.id == id).SingleOrDefault();
            return View(yzr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_yazarlar yzr)
        {
            if (ModelState.IsValid)
            {
                var t = ent.tb_yazarlar.Where(x => x.id == id).SingleOrDefault();


                t.ad_soyad = yzr.ad_soyad;
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yzr);
        }
        public ActionResult Delete(int id)
        {

            var yzr = ent.tb_yazarlar.Where(x => x.id == id).SingleOrDefault();
            return View(yzr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Delete(int id, tb_yazarlar yzr)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var b = ent.tb_yazarlar.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            ent.tb_yazarlar.Remove(b);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }
    }

}