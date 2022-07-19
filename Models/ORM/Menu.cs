using System;
namespace WTechCoreSample.Models.ORM
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public int SortNumber { get; set; }
    }
}
