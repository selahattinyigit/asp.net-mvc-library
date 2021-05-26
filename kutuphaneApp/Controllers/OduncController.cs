using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            List<SelectListItem> kitap = new List<SelectListItem>();
            foreach (var item in ent.tb_kitaplar.Where(x=>x.durum==false).ToList())
            {
                kitap.Add(new SelectListItem { Text = item.isbn_no, Value = item.id.ToString() });
            }

            ViewBag.kitap = kitap;

            List<SelectListItem> uye = new List<SelectListItem>();
            foreach (var item in ent.tb_uyeler.ToList())
            {
                uye.Add(new SelectListItem { Text = item.telefon, Value = item.id.ToString() });
            }

            ViewBag.uye = uye;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Index(tb_kitap_odunc odunc,int sure)
        {
         
            if (ModelState.IsValid)
            {
                string id = Session["id"].ToString();
                tb_kitap_odunc k = new tb_kitap_odunc();
                k.kitap_id = odunc.kitap_id;
                k.uye_id = odunc.uye_id;
                k.kullanici_id =int.Parse(id);
                k.baslangic_tarih = DateTime.Now;
                k.bitis_tarih = DateTime.Now.AddDays(sure);
                tb_kitaplar ktp = ent.tb_kitaplar.Where(x => x.id == k.kitap_id).SingleOrDefault();
                ktp.durum = true;
                
                ent.tb_kitap_odunc.Add(k);





                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odunc);
        }
    }
}