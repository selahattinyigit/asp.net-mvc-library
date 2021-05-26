using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            return View(ent.tb_kitaplar.ToList()) ;
        }
        public ActionResult Create()
        {
            List<SelectListItem> yayin = new List<SelectListItem>();
            foreach (var item in ent.tb_yayin_evleri.ToList())
            {  
                yayin.Add(new SelectListItem { Text = item.ad, Value = item.id.ToString() });
            }
          
            ViewBag.yayin = yayin;

            List<SelectListItem> yazar = new List<SelectListItem>();
            foreach (var item in ent.tb_yazarlar.ToList())
            {
                yazar.Add(new SelectListItem { Text = item.ad_soyad, Value = item.id.ToString() });
            }

            ViewBag.yazar = yazar;

            List<SelectListItem> tur = new List<SelectListItem>();
            foreach (var item in ent.tb_turler.ToList())
            {
                tur.Add(new SelectListItem { Text = item.tur, Value = item.id.ToString() });
            }

            ViewBag.tur = tur;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(tb_kitaplar kitap)
        {
            if (ModelState.IsValid)
            {
                tb_kitaplar k = new tb_kitaplar();
                k.isbn_no = kitap.isbn_no;
                k.adi = kitap.adi;
                k.yayin_evi_id = kitap.yayin_evi_id;
                k.sayfa_sayisi = kitap.sayfa_sayisi;
                k.tur_id = kitap.tur_id;
                k.yazar_id = kitap.yazar_id;
                k.basim_yili = kitap.basim_yili;
                k.durum = false;
                ent.tb_kitaplar.Add(k);





                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitap);
        }
        public ActionResult Edit(int id)
        {
            List<SelectListItem> yayin = new List<SelectListItem>();
            foreach (var item in ent.tb_yayin_evleri.ToList())
            {
                yayin.Add(new SelectListItem { Text = item.ad, Value = item.id.ToString() });
            }

            ViewBag.yayin = yayin;

            List<SelectListItem> yazar = new List<SelectListItem>();
            foreach (var item in ent.tb_yazarlar.ToList())
            {
                yazar.Add(new SelectListItem { Text = item.ad_soyad, Value = item.id.ToString() });
            }

            ViewBag.yazar = yazar;

            List<SelectListItem> tur = new List<SelectListItem>();
            foreach (var item in ent.tb_turler.ToList())
            {
                tur.Add(new SelectListItem { Text = item.tur, Value = item.id.ToString() });
            }

            ViewBag.tur = tur;
            var ktp = ent.tb_kitaplar.Where(x => x.id == id).SingleOrDefault();
            return View(ktp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_kitaplar kitap)
        {
            if (ModelState.IsValid)
            {
                var k = ent.tb_kitaplar.Where(x => x.id == id).SingleOrDefault();
                k.isbn_no = kitap.isbn_no;
                k.adi = kitap.adi;
                k.yayin_evi_id = kitap.yayin_evi_id;
                k.sayfa_sayisi = kitap.sayfa_sayisi;
                k.tur_id = kitap.tur_id;
                k.yazar_id = kitap.yazar_id;
                k.basim_yili = kitap.basim_yili;


                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitap);
        }
        public ActionResult Delete(int id)
        {

            var k = ent.tb_kitaplar.Where(x => x.id == id).SingleOrDefault();
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Delete(int id, tb_kitaplar kitap)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var b = ent.tb_kitaplar.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            ent.tb_kitaplar.Remove(b);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}