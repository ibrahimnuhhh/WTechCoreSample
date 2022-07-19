using System;
namespace WTechCoreSample.Models.ORM
{
    public class AdminUser : BaseEntity
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EMail { get; set; }

        public string Password { get; set; }

        public string EMailCode { get; set; }

        public DateTime LastLoginDate { get; set; }
    }
}
