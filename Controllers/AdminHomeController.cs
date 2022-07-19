using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;

namespace WTechCoreSample.Controllers
{
    [Authorize]
    public class AdminHomeController : AdminBaseController
    {

        WTechContext wTechContext;

        public AdminHomeController()
        {
            wTechContext = new WTechContext();
        }
       
        public IActionResult Index()
        {
            ViewBag.BlogPostCount = wTechContext.BlogPosts.Where(q => q.IsDeleted == false).Count();

            ViewBag.MenuCount = wTechContext.Menus.Where(q => q.IsDeleted == false).Count();
            ViewBag.WebUserCount = wTechContext.WebUsers.Where(q => q.IsDeleted == false).Count();

            ViewData["CommentCount"] = wTechContext.Comments.Where(q => q.IsDeleted == false).Count();

            ViewData["Status"] = false;


            return View();
        }
    }
}
