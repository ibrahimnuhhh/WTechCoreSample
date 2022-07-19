using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.Helper;
using WTechCoreSample.Models.ORM;
using WTechCoreSample.Models.VM;
using WTechCoreSample.Service;

namespace WTechCoreSample.Controllers
{
    public class AdminLoginController : Controller
    {
        WTechContext wTechContext;

        private readonly IMailService mailService;


        public AdminLoginController(IMailService mailService)
        {
            wTechContext = new WTechContext();
             this.mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.EMail == model.EMail && q.Password == model.Password && q.IsDeleted == false);

           


            if (adminUser != null)
            {


                adminUser.LastLoginDate = DateTime.Now;
                wTechContext.SaveChanges();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, adminUser.EMail),
                    new Claim(ClaimTypes.Name, adminUser.Id.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);


                AdminActivity adminActivity = new AdminActivity();
                adminActivity.AdminUserId = adminUser.Id;
                adminActivity.ActivityCategory = EnumActivityCategory.LoginSuccess.ToString();
                adminActivity.Title = AdminActivityList.LoginSuccess;
                adminActivity.Content = "On numara login";


                wTechContext.AdminActivities.Add(adminActivity);
                wTechContext.SaveChanges();


                return RedirectToAction("Index", "AdminHome");

            }

            return RedirectToAction("Index", "AdminLogin");
        }


        public async Task<IActionResult> Logout()
        {

           await HttpContext.SignOutAsync();

           return RedirectToAction("Index", "AdminLogin");

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {

            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();

                AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.EMail == model.EMail);
                adminUser.EMailCode = guid;

                wTechContext.SaveChanges();


                MailRequest mailRequest = new MailRequest();
                mailRequest.Subject = "Şifre Yenileme!!";
                mailRequest.ToEmail = model.EMail;
                mailRequest.Body = "Lütfen aşağıdaki linki tıklayınız.. <a href='https://localhost:5001/AdminLogin/NewPassword/" + guid + "'> Link</a>";


                await mailService.SendEmailAsync(mailRequest);



            }

         



            return View();
        }


        public IActionResult NewPassword(string id)
        {

            AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.EMailCode == id);

            if(adminUser != null)
            {
                AdminUserNewPassword adminUserNewPassword = new AdminUserNewPassword();
                adminUserNewPassword.AdminUserId = adminUser.Id;

                return View(adminUserNewPassword);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult NewPassword(AdminUserNewPassword model)
        {

            if (ModelState.IsValid)
            {
                AdminUser adminUser = wTechContext.AdminUsers.FirstOrDefault(q => q.Id == model.AdminUserId);

                adminUser.Password = model.Password;

                wTechContext.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

          


        }

    }
}
