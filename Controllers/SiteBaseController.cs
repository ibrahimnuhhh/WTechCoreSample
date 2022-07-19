using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WTechCoreSample.Models.ORM;

namespace WTechCoreSample.Controllers
{
    public class SiteBaseController : Controller
    {
        public WTechContext wTechContext;

        public SiteBaseController()
        {
            wTechContext = new WTechContext();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Menus = wTechContext.Menus.Where(q => q.IsDeleted == false).OrderBy(q => q.SortNumber).ToList();

        }

    }
}
