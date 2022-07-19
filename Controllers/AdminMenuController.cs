using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;
using WTechCoreSample.Models.VM;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WTechCoreSample.Controllers
{
    [Authorize]
    public class AdminMenuController : AdminBaseController
    {
        WTechContext wTechContext;

        public AdminMenuController()
        {
            wTechContext = new WTechContext();
        }
 
        public IActionResult Index()
        {
            List<Menu> menus = wTechContext.Menus.Where(q => q.IsDeleted == false).ToList();
            return View(menus);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminMenuVM adminMenuVM)
        {
            if (ModelState.IsValid)
            {
                Menu menu = new Menu();
                menu.Name = adminMenuVM.Name;
                menu.Link = adminMenuVM.Link;

                wTechContext.Menus.Add(menu);
                wTechContext.SaveChanges();

                return RedirectToAction("Index", "AdminMenu");
            }

            return View();
        }


        [HttpPost]
        public IActionResult AddNewMenu(Menu menu)
        {

            wTechContext.Menus.Add(menu);
            wTechContext.SaveChanges();

            return Json("");
        }


        public IActionResult Delete(int id)
        {
            Menu menu = wTechContext.Menus.FirstOrDefault(q => q.Id == id);
            menu.IsDeleted = true;
            wTechContext.SaveChanges();

            return RedirectToAction("Index", "AdminMenu");

        }


       

    }
}
