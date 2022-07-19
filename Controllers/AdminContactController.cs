using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WTechCoreSample.Controllers
{
    [Authorize]
    public class AdminContactController : AdminBaseController
    {
        WTechContext wTechContext;
        public AdminContactController()
        {
            wTechContext = new WTechContext();
        }

        public IActionResult Index()
        {
            List<Contact> contacts = wTechContext.Contacts.Where(q => q.IsDeleted == false).ToList();

            return View(contacts);
        }

        public IActionResult Detail(int id)
        {
            Contact contact = wTechContext.Contacts.FirstOrDefault(q => q.IsDeleted == false && q.Id == id);

            return Json(contact);
        }


        public IActionResult Delete(int id)
        {
            Contact contact = wTechContext.Contacts.FirstOrDefault(q => q.Id == id);
            contact.IsDeleted = true;

            wTechContext.SaveChanges();

            return RedirectToAction("Index", "AdminContact");
        }
    }
}
