using System;
using System.ComponentModel.DataAnnotations;

namespace WTechCoreSample.Models.VM
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
    }
}
