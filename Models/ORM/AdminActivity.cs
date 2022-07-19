using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTechCoreSample.Models.ORM
{
    public class AdminActivity : BaseEntity
    {
        public int AdminUserId { get; set; }

        [ForeignKey("AdminUserId")]
        public AdminUser AdminUser { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ActivityCategory { get; set; }

    }
}
