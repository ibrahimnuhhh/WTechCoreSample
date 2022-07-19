using System;
using System.ComponentModel.DataAnnotations;

namespace WTechCoreSample.Models.VM
{
    public class ContactVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string EMail { get; set; }
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
