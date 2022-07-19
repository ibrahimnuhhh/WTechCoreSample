using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;
using WTechCoreSample.Models.VM;

namespace WTechCoreSample.Controllers
{
    [Authorize]
    public class AdminBlogCategoryController : AdminBaseController
    {

        WTechContext wTechContext;

        public AdminBlogCategoryController()
        {
            wTechContext = new WTechContext();
        }


        public IActionResult Index()
        {

            List<AdminBlogCategoryVM> model = new List<AdminBlogCategoryVM>();

            List<BlogCategory> blogCategories = wTechContext.BlogCategories.Where(q => q.IsDeleted == false).ToList();

            foreach (var item in blogCategories)
            {
                AdminBlogCategoryVM adminBlogCategoryVM = new AdminBlogCategoryVM();
                adminBlogCategoryVM.Name = item.Name;
                adminBlogCategoryVM.Id = item.Id;

                model.Add(adminBlogCategoryVM);
            }


            return View(model);

        }


        public IActionResult AddBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlogCategory(AdminBlogCategoryVM model)
        {

            if (ModelState.IsValid)
            {
                //DB işlemlerini yap

                BlogCategory blogCategory = new BlogCategory();
                blogCategory.Name = model.Name;

                wTechContext.Add(blogCategory);
                wTechContext.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            BlogCategory blogCategory = wTechContext.BlogCategories.FirstOrDefault(q => q.Id == id && q.IsDeleted == false);

            blogCategory.IsDeleted = true;

            wTechContext.SaveChanges();

            return RedirectToAction("Index","AdminBlogCategory");

        }
    }
}
