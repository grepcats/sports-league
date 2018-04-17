using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsLeague.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsLeague.Controllers
{
    public class DivisionController : Controller
    {
        private SportsDbContext db = new SportsDbContext();
        public IActionResult Index()
        {
            List<Division> model = db.Divisions.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Division division)
        {
            db.Divisions.Add(division);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
