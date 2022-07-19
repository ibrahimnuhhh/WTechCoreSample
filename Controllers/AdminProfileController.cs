using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;
using WTechCoreSample.Models.VM;

namespace WTechCoreSample.Controllers
{
    public class AdminProfileController : AdminBaseController
    {
        WTechContext wTechContext;

        public AdminProfileController()
        {
            wTechContext = new WTechContext();
        }


        public IActionResult Index()
        {
            //Login olan adminuser ın Id bilgisini Claim üzerinden çekiyorum.
            var userClaim = User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Name);
            int adminUserId = Convert.ToInt32(userClaim.Value);


            //Öncelikle parolası güncellenecek kullanıcı db den bulunur.
            AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.Id == adminUserId);


            return View(adminUser);
        }

        [HttpPost]
        public IActionResult Index(AdminUser model)
        {
            AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.Id == model.Id);

            adminUser.Name = model.Name;
            adminUser.Surname = model.Surname;

            wTechContext.SaveChanges();

            return RedirectToAction("Index", "AdminHome");


        }

        public IActionResult UpdatePassword()
        {
            return View();
        }


        [HttpPost]
        public IActionResult UpdatePassword(AdminUserUpdatePasswordVM model)
        {

            if (ModelState.IsValid)
            {
                //Login olan adminuser ın Id bilgisini Claim üzerinden çekiyorum.
                var userClaim = User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Name);
                int adminUserId = Convert.ToInt32(userClaim.Value);


                //Öncelikle parolası güncellenecek kullanıcı db den bulunur.
                AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.Id == adminUserId);

                adminUser.Password = model.NewPassword;

                wTechContext.SaveChanges();

                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                return View();
            }
      
           
        }



    }
}
