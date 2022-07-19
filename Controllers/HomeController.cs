using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;
using System.Linq;
using WTechCoreSample.Models.VM;
using System.Threading.Tasks;
using WTechCoreSample.Service;
using WTechCoreSample.Models.Helper;

namespace WTechCoreSample.Controllers
{
    public class HomeController : SiteBaseController
    {

        private readonly IMailService mailService;


        public HomeController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        public ActionResult Index()
        {
            List<BlogPost> blogPosts = wTechContext.BlogPosts
                .OrderByDescending(x => x.AddDate).Where(q => q.IsDeleted == false).Take(3).ToList();


           

            return View(blogPosts);
        }


        public IActionResult Posts()
        {
            List<BlogPost> blogPosts = wTechContext.BlogPosts
               .OrderByDescending(x => x.AddDate).Where(q => q.IsDeleted == false).ToList();

            return View(blogPosts);
        }


        public ActionResult Detail(int id)
        {

            BlogPost blogPost = wTechContext.BlogPosts.FirstOrDefault(q => q.Id == id);
            blogPost.ViewCount = blogPost.ViewCount + 1;

            wTechContext.SaveChanges();


            BlogDetailVM blogDetailVM = new BlogDetailVM();
            blogDetailVM.Id = blogPost.Id;
            blogDetailVM.Title = blogPost.Title;
            blogDetailVM.Content = blogPost.Content;
            blogDetailVM.AddDate = blogPost.AddDate;



            List<Comment> blogPostComments = wTechContext.Comments.Where(q => q.BlogPostId == id).ToList();

            blogDetailVM.Comments = blogPostComments;

            return View(blogDetailVM);

        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.Name = model.Name;
                contact.EMail = model.EMail;
                contact.Message = model.Message;
                contact.Phone = model.Phone;

                wTechContext.Contacts.Add(contact);
                wTechContext.SaveChanges();

                MailRequest mailRequest = new MailRequest();
                mailRequest.Subject = "İletişim Mesajı!!";
                mailRequest.ToEmail = "yildiz.cagatay@hotmail.com";
                mailRequest.Body = model.Message;


                await mailService.SendEmailAsync(mailRequest);

                ViewBag.Status = "Success";

            }
            else
            {
                ViewBag.Status = "Error";
            }
            return View();
        }
    }
}
