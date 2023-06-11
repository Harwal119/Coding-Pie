using CodingPie.Models;
using CodingPie.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingPie.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieService _pieService;
        public PieController(IPieService pieService)
        {
            _pieService = pieService;
        }
        //this action method to return all pies


        
        public IActionResult Pies()
        {
            var pies = _pieService.GetAllPies();
            //ViewData["name"] = HttpContext.Session.GetString("email");
            return View(pies);

            //return Json(new {name="Ade", age=25, email="a@gmail.com", price=500});
        }

        [HttpGet]
        public IActionResult Pie(int id)
        {
            var pie = _pieService.GetPie(id);
            return View(pie);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreatePieViewModel model)
        {
            /*Pie pie = new Pie();
            Request.Form[""]
            var id = int.Parse(formCollection["Id"]); 
            var name = formCollection["Name"]; 
            var price = decimal.Parse(formCollection["Price"]); 
            var description = formCollection["Description"];
            pie.Id = id;
            pie.Name = name;
            pie.Price = price;
            pie.Description = description;*/
            
            var pieReturned = _pieService.AddPie(model);
            if(pieReturned is not null)
            {
                TempData["successfull"] = "Pie added successfully";
            }
            return RedirectToAction("Pies");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var pie = _pieService.GetPie(id);
            return View(pie);
        }

        [HttpPost]
        public IActionResult Update(Pie pie)
        {
            _pieService.UpdatePie(pie);
            return RedirectToAction("Pies");
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(HttpContext.Session.GetString("email") is not null)
            {
                var pie = _pieService.GetPie(id);
                return View(pie);
            }
            return RedirectToAction("Login" , "User");
            
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(int id)
        {
            /*if(HttpContext.Session.GetString("email") is not null)
            {
                _pieService.DeletePie(id);
                return RedirectToAction("Pies");

            }*/
           
            return RedirectToAction("Login" , "User");
        }

    }
}
