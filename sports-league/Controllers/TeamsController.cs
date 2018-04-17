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
    public class TeamsController : Controller
    {
        private SportsDbContext db = new SportsDbContext();
        public IActionResult Index()
        {
            return View(db.Teams.Include(teams => teams.Division).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(Teams => Teams.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(Teams => Teams.TeamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(Teams => Teams.TeamId == id);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.Include(teams => teams.Division).FirstOrDefault(Teams => Teams.TeamId == id);
            return View(thisTeam);
        }

    }


}
