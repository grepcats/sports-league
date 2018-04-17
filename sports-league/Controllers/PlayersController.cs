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
    public class PlayersController : Controller
    {
        private SportsDbContext db = new SportsDbContext();
        public IActionResult Index()
        {
            return View(db.Players.Include(players => players.Team).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(Players => Players.PlayerId == id);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View(thisPlayer);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(Players => Players.PlayerId == id);
            return View(thisPlayer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(Players => Players.PlayerId == id);
            db.Players.Remove(thisPlayer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
