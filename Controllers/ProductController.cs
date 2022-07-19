using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;
using WTechCoreSample.Models.VM;

namespace WTechCoreSample.Controllers
{
    public class ProductController : Controller
    {
        WTechContext wTechContext;
        public ProductController()
        {
            wTechContext = new WTechContext();
        }

        public IActionResult Index()
        {
            //DB ye kayıt işlemi

            //Product product = new Product();
            //product.Name = "IPhone";
            //product.UnitPrice = 3000;
            //product.UnitsInStock = 20;
            //product.StockStatus = false;
            //product.Description = "Apples product";

            //wTechContext.Products.Add(product);
            //wTechContext.SaveChanges();

            //DB den id si 33 olan ürünü yakala

            //1. yol
            Product product = wTechContext.Products.Find(33);

            //2. yol
            Product product1 = wTechContext.Products.FirstOrDefault(q => q.Id == 33);

            //3. yol
            Product product2 = wTechContext.Products.First(q => q.Id == 33);


            //DB den id si 33 olan ürünü yakala ismini IPhone yap! UPDATE

            //Product product3 = wTechContext.Products.FirstOrDefault(q => q.Id == 33);
            //product3.Name = "IPhone";

            //wTechContext.SaveChanges();

            //DB den id si 43 olan ürünü yakala ve IsDeleted True yap! UPDATE
            //Product product4 = wTechContext.Products.Find(43);
            //product4.IsDeleted = true;

            //wTechContext.SaveChanges();


            //DB den id si 39 olan ürünü SİL
            //Product product5 = wTechContext.Products.Find(39);

            //wTechContext.Products.Remove(product5);
            //wTechContext.SaveChanges();


            //IsDeleted False olan ürünleri bana ver
            List<Product> products = wTechContext.Products.Where(q => q.IsDeleted == false).ToList();

            //IsDeleted False olan 10 adet ürünü bana ver
            List<Product> products1 = wTechContext.Products.Where(q => q.IsDeleted == false).Take(10).ToList();

            //IsDeleted False olan VE fiyatı 100 den büyük olan 10 ürünü bana ver
            List<Product> products2 = wTechContext.Products.
                Where(q => q.IsDeleted == false && q.UnitPrice > 100)
                .Take(10)
                .ToList();

            //IsDeleted False olan VE ( fiyatı 200 den büyükEşit VEYA Stok durumu true olan) ürünleri bana ver

            List<Product> products3 = wTechContext.Products
                .Where(q => q.IsDeleted == false && (q.UnitPrice >= 200 || q.StockStatus == true))
                .ToList();

            //Ürün adı a harfi ile başlayan VE stokta olanlar
            List<Product> products4 = wTechContext.Products
                .Where(q => q.Name.StartsWith("a") && q.StockStatus == true)
                .ToList();

            //Ürün adı a harfi ile başlayan ( büyük veya küçük a farketmex) VE stokta olanlar
            List<Product> products5 = wTechContext.Products
                .Where(q => q.Name.ToLower().StartsWith("a"))
                .ToList();


            //IsDeleted false olan ürünleri ada göre sırala

            List<Product> products6 = wTechContext.Products.Where(q => q.IsDeleted == false)
                .OrderBy(q => q.Name)
                .ToList();

            //IsDeleted false olan ürünleri ada göre Tersten sırala

            List<Product> products7 = wTechContext.Products.Where(q => q.IsDeleted == false)
                .OrderByDescending(q => q.Name)
                .ToList();

            //Fiyat aralığı 100-200 arasında olan ürünleri bana ver. Ada göre sıralı olsun
            List<Product> products8 = wTechContext.Products
                .Where(q => q.UnitPrice >= 100 && q.UnitPrice <= 200)
                .OrderBy(q => q.Name)
                .ToList();

            //ürün adında "ta" geçenleri bana ver
            List<Product> products9 = wTechContext.Products
                .Where(q => q.Name.Contains("ta"))
                .ToList();


            //Kaç adet ürün var?
            int pCount = wTechContext.Products.Count();

            //Adı t harfi ile başlayan kaç adet ürün var
            int pCount2 = wTechContext.Products.Where(q => q.Name.StartsWith("t")).Count();


            //Ürün fiyatı 200 den büyük ürün var Mı?
            bool pStatus = wTechContext.Products.Any(q => q.UnitPrice > 200);

            //String Metotlar

            string name = "Çağatay";

            //Ürünlerin toplam fiyatı
            decimal totalPrice = wTechContext.Products.Sum(q => q.UnitPrice);



            // Stokta bulunan ürünlerin toplam fiyatı
            decimal totalPrice2 = wTechContext.Products.Where(q => q.StockStatus == true).Sum(q => q.UnitPrice);

            //Ürünlerin ortalama fiyatı
            decimal avgPrice = wTechContext.Products.Average(q => q.UnitPrice);

            //name ç harfi ile başlıyor MU?



            ////Tüm harfleri büyüt bana ver

            //string upperName = name.ToUpper();
            //string lowerName = name.ToLower();

            //string trimResult = name.Trim();
            //string trimStartResult = name.TrimStart();


            List<ProductVM> model = wTechContext.Products.Select(q => new ProductVM()
            {
                Ad = q.Name,
                Fiyat = q.UnitPrice,
                StokDurum = q.StockStatus,
                KDVFiyat = q.UnitPrice * 1.18M,
                Renk = q.UnitPrice > 200 ? "Pahalı" : "Ucuz"
            }).ToList();

            return Json(model);
        }
    }
}
