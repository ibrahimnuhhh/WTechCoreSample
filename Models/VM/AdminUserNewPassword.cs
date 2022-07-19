using System;
using System.ComponentModel.DataAnnotations;

namespace WTechCoreSample.Models.VM
{
    public class AdminUserNewPassword
    {
        public int AdminUserId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string NewPassword { get; set; }
    }
}
