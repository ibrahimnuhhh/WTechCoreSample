using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;

namespace WTechCoreSample.Controllers
{
    public class AdminActivityController : Controller
    {

        WTechContext wTechContext;

        public AdminActivityController()
        {
            wTechContext = new WTechContext();
        }

        public IActionResult Index()
        {
            List<AdminActivity> adminActivities = wTechContext.AdminActivities.Where(q => q.IsDeleted == false).ToList();



            return View(adminActivities);
        }
    }
}
