using System;
namespace WTechCoreSample.Models.VM
{
    public class ProductVM
    {
        public string Ad { get; set; }

        public bool StokDurum { get; set; }

        public decimal Fiyat { get; set; }

        public decimal KDVFiyat { get; set; }

        public string Renk { get; set; }
    }
}
