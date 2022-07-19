using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechCoreSample.Models.ORM;

namespace WTechCoreSample.Controllers
{
    public class AdminFoodController : AdminBaseController
    {
        WTechContext wTechContext;

        public AdminFoodController()
        {
            wTechContext = new WTechContext();
        }
       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddFood(Food food)
        {
            wTechContext.Foods.Add(food);
            wTechContext.SaveChanges();

            return Json(food);

        }


        public IActionResult GetFoods()
        {
            List<Food> foods = wTechContext.Foods.Where(q => q.IsDeleted == false).ToList();

            return Json(foods);
        }


        public IActionResult DeleteFood(int id)
        {

            Food food = wTechContext.Foods.FirstOrDefault(q => q.Id == id);
            food.IsDeleted = true;
            wTechContext.SaveChanges();

            return Json("Ok");

        }



    }
}
