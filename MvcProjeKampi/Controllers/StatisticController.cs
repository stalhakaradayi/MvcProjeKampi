using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var qCategoryCount = context.Categories.Count().ToString();
            ViewBag.qCategoryCount = qCategoryCount;

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var qSoftwareCategoryTitleCount = context.Headings.Count(x => x.CategoryID==17);
            ViewBag.qSoftwareCategoryTitleCount = qSoftwareCategoryTitleCount;

            // Yazar adında 'a' harfi geçen yazar sayısı 
            var qAwriterCount = context.Writers.Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
            ViewBag.qAwriterCount = qAwriterCount;

            //En fazla başlığa sahip kategori adı
            var qHasMoreTitle = context.Categories.Where(x => x.CategoryID == context.Headings.GroupBy(p =>p.CategoryID).OrderByDescending(p => p.Count())
              .Select(p => p.Key).FirstOrDefault()).Select(p => p.CategoryName).FirstOrDefault();
            ViewBag.qHasMoreTitle = qHasMoreTitle;


            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark

            var variationTrueBtwFalse = context.Categories.Where(x => x.CategoryStatus == true).Count() - context.Categories.Where(x => x.CategoryStatus == false).Count();
            ViewBag.variationTrueBtwFalse = variationTrueBtwFalse;



            return View();
        }
    }
}