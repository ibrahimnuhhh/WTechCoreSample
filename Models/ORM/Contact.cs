using System;
namespace WTechCoreSample.Models.ORM
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

    }
}
