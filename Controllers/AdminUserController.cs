using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;

namespace WTechCoreSample.Controllers
{
    public class AdminUserController : AdminBaseController
    {
        WTechContext wTechContext;

        public AdminUserController()
        {
            wTechContext = new WTechContext();
        }
   
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetAdminUsers()
        {
            List<AdminUser> adminUsers = wTechContext.AdminUsers.Where(q => q.IsDeleted == false).ToList();

            return Json(adminUsers);
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddAdminUser(AdminUser adminUser)
        {
            wTechContext.AdminUsers.Add(adminUser);
            wTechContext.SaveChanges();

            return Json("Ok!");
        }
    }
}
