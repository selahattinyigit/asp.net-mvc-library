using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class YayinEvleriController : Controller
    {
        // GET: YayinEvleri
        Model1 ent = new Model1();
        public ActionResult Index()
        {

            return View(ent.tb_yayin_evleri.ToList()) ;
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(tb_yayin_evleri yayin)
        {
            if (ModelState.IsValid)
            {
                tb_yayin_evleri y = new tb_yayin_evleri();
                y.ad = yayin.ad;
                ent.tb_yayin_evleri.Add(y);





                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yayin);
        }
        public ActionResult Edit(int id)
        {
            var yyn = ent.tb_yayin_evleri.Where(x => x.id == id).SingleOrDefault();
            return View(yyn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_yayin_evleri yyn)
        {
            if (ModelState.IsValid)
            {
                var t = ent.tb_yayin_evleri.Where(x => x.id == id).SingleOrDefault();


                t.ad = yyn.ad;
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yyn);
        }
        public ActionResult Delete(int id)
        {

            var yzr = ent.tb_yayin_evleri.Where(x => x.id == id).SingleOrDefault();
            return View(yzr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Delete(int id, tb_yayin_evleri yyn)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var b = ent.tb_yayin_evleri.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            ent.tb_yayin_evleri.Remove(b);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}