using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class TurlerController : Controller
    {
        // GET: Turler
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            return View(ent.tb_turler.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(tb_turler tur)
        {
            if (ModelState.IsValid)
            {
                tb_turler t = new tb_turler();
                t.tur = tur.tur;
                ent.tb_turler.Add(t);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tur);
        }
        public ActionResult Edit(int id)
        {
            var tur = ent.tb_turler.Where(x => x.id == id).SingleOrDefault();
            return View(tur);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_turler tur)
        {
            if (ModelState.IsValid)
            {
                var t = ent.tb_turler.Where(x => x.id == id).SingleOrDefault();


                t.tur = tur.tur;
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tur);
        }
        public ActionResult Delete(int id)
        {
            var tur = ent.tb_turler.Where(x => x.id == id).SingleOrDefault();
            return View(tur);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Delete(int id, tb_turler tur)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var b = ent.tb_turler.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            ent.tb_turler.Remove(b);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}