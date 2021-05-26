using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using kutuphaneApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Rotativa;
namespace kutuphaneApp.Controllers
{
    public class HomeController : Controller
    {
        Model1 ent = new Model1();
        public ActionResult Index()
        {
            string s = ent.tb_kitaplar.Count().ToString();
            ViewBag.kitap_sayisi = s;
            string u = ent.tb_uyeler.Count().ToString();
            ViewBag.uye_sayisi=u;
            string o = ent.tb_kitap_odunc.Count().ToString();
            ViewBag.odunc_sayisi=o;

          
            

            return View();
        }
        public class ktp
        {
            public string ad { get; set; }
            public double value { get; set; }
        }
       
        public ActionResult GrafikOlustur()
        {
           
             
                  int sayac = 0;

            var GrafikCiz = new Chart(350, 350);

            GrafikCiz.AddTitle("En fazla ödünç verilen kitaplar");
            GrafikCiz.AddLegend("isbn no");

            var sorgu = from kt in ent.tb_kitaplar
                        join ko in ent.tb_kitap_odunc on kt.id equals ko.kitap_id
                        group ko.kitap_id by new
                        {
                            kt.isbn_no

                        } into plk

                        orderby plk.Count() descending
                        select new { kitap = plk.Key.isbn_no, sayi = plk.Count() };
           
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                   
                    sayac++;
                }

            }
            string[] d =new string[5];
            int[] t =new int[5];
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    d[sayac] = item.kitap;
                    t[sayac] = item.sayi;
                    sayac++;
                }

            }
            GrafikCiz.AddSeries(chartType: "column",
                      xValue: d,
                      yValues: t)
                   .Write();


            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult GrafikOlustur2()
        {


            int sayac = 0;

            var GrafikCiz = new Chart(350, 350);

            GrafikCiz.AddTitle("En fazla ödünç kitap alan üyeler");
            GrafikCiz.AddLegend("Üye");

            var sorgu = from kt in ent.tb_uyeler
                        join ko in ent.tb_kitap_odunc on kt.id equals ko.uye_id
                        group ko.uye_id by new
                        {
                            kt.ad_soyad

                        } into plk

                        orderby plk.Count() descending
                        select new { kitap = plk.Key.ad_soyad, sayi = plk.Count() };

            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {

                    sayac++;
                }

            }
            string[] d = new string[5];
            int[] t = new int[5];
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    d[sayac] = item.kitap;
                    t[sayac] = item.sayi;
                    sayac++;
                }

            }
            GrafikCiz.AddSeries(chartType: "column",
                      xValue: d,
                      yValues: t)
                   .Write();


            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult GrafikOlustur3()
        {


            int sayac = 0;

            var GrafikCiz = new Chart(350, 350);

            GrafikCiz.AddTitle("En fazla kitabı olan yazarlar");
            GrafikCiz.AddLegend("Yazar");

            var sorgu = from kt in ent.tb_kitaplar
                        join ko in ent.tb_yazarlar on kt.id equals ko.id
                        group kt.yazar_id by new
                        {
                            ko.ad_soyad

                        } into plk

                        orderby plk.Count() descending
                        select new { kitap = plk.Key.ad_soyad, sayi = plk.Count() };

            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {

                    sayac++;
                }

            }
            string[] d = new string[5];
            int[] t = new int[5];
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    d[sayac] = item.kitap;
                    t[sayac] = item.sayi;
                    sayac++;
                }

            }
            GrafikCiz.AddSeries(chartType: "column",
                      xValue: d,
                      yValues: t)
                   .Write();


            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult GrafikOlustur4()
        {


            int sayac = 0;

            var GrafikCiz = new Chart(350, 350);

            GrafikCiz.AddTitle("En fazla kitabı olan yayın evleri");
            GrafikCiz.AddLegend("Yayın evi");

            var sorgu = from kt in ent.tb_kitaplar
                        join ko in ent.tb_yayin_evleri on kt.yayin_evi_id equals ko.id
                        group kt.yayin_evi_id by new
                        {
                            ko.ad

                        } into plk

                        orderby plk.Count() descending
                        select new { kitap = plk.Key.ad, sayi = plk.Count() };

            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {

                    sayac++;
                }

            }
            string[] d = new string[5];
            int[] t = new int[5];
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    d[sayac] = item.kitap;
                    t[sayac] = item.sayi;
                    sayac++;
                }

            }
            GrafikCiz.AddSeries(chartType: "column",
                      xValue: d,
                      yValues: t)
                   .Write();


            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult GrafikOlustur5()
        {


            int sayac = 0;

            var GrafikCiz = new Chart(350, 350);

            GrafikCiz.AddTitle("En fazla ödünç kitap veren kullanıcılar");
            GrafikCiz.AddLegend("Kullanıcı Adı");

            var sorgu = from kt in ent.tb_kullanıcılar
                        join ko in ent.tb_kitap_odunc on kt.id equals ko.kullanici_id
                        group ko.kullanici_id by new
                        {
                            kt.kullanici_adi

                        } into plk

                        orderby plk.Count() descending
                        select new { kitap = plk.Key.kullanici_adi, sayi = plk.Count() };

            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {

                    sayac++;
                }

            }
            string[] d = new string[5];
            int[] t = new int[5];
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    d[sayac] = item.kitap;
                    t[sayac] = item.sayi;
                    sayac++;
                }

            }
            GrafikCiz.AddSeries(chartType: "pie",
                      xValue: d,
                      yValues: t)
                   .Write();


            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult GrafikOlustur6()
        {


            int sayac = 0;

            var GrafikCiz = new Chart(350, 350);

            GrafikCiz.AddTitle("En fazla tercih edilen kitap türleri");
            GrafikCiz.AddLegend("Kullanıcı Adı");

            var sorgu = from kt in ent.tb_turler
                        join ko in ent.tb_kitaplar on kt.id equals ko.tur_id
                        join tt in ent.tb_kitap_odunc on ko.id equals tt.kitap_id
                        group tt.kitap_id by new
                        {
                            kt.tur

                        } into plk

                        orderby plk.Count() descending
                        select new { kitap = plk.Key.tur, sayi = plk.Count() };

            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {

                    sayac++;
                }

            }
            string[] d = new string[5];
            int[] t = new int[5];
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    d[sayac] = item.kitap;
                    t[sayac] = item.sayi;
                    sayac++;
                }

            }
            GrafikCiz.AddSeries(chartType: "pie",
                      xValue: d,
                      yValues: t)
                   .Write();


            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult PrintAllReport()
        {
            var report = new ViewAsPdf("Index", "Home");
            return report;

        }
    }
}