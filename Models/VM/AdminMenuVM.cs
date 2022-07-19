using System;
using System.ComponentModel.DataAnnotations;

namespace WTechCoreSample.Models.VM
{
    public class AdminMenuVM
    {
        [Required(ErrorMessage ="Name is required!")]
        [MaxLength(10, ErrorMessage = "Max 10 character !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Link is required!")]
        public string Link { get; set; }
    }
}
