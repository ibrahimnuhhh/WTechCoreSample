using System;
namespace WTechCoreSample.Models.ORM
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public bool StockStatus { get; set; }
    }
}
