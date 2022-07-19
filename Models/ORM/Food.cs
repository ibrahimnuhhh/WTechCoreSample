using System;
namespace WTechCoreSample.Models.ORM
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public decimal Price  { get; set; }
    }
}
