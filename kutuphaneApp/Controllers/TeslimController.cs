using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kutuphaneApp.Models;
namespace kutuphaneApp.Controllers
{
    public class TeslimController : Controller
    {
        // GET: Teslim
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            return View(ent.tb_kitap_odunc.ToList());
        }
        public ActionResult Al(int id)
        {
            return View(ent.tb_kitap_odunc.Where(x=>x.id==id).SingleOrDefault());
        }
    }
}