using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Superhero_Creator.Data;
using Superhero_Creator.Models;

namespace Superhero_Creator.Controllers
{
    public class Superheros : Controller
    {
        private ApplicationDbContext _context;
        public Superheros(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superheros
        public ActionResult Index()
        {
            var heroes = _context.Superheros.ToList();
            return View(heroes);
        }

        // GET: Superheros/Details/5
        public ActionResult Details(int id)
        {
            Superhero heroDetails = _context.Superheros.Find(id);
            return View(heroDetails);
        }

        // GET: Superheros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superheros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheros.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero changesMade = _context.Superheros.Find(id);
            return View(changesMade);
        }

        // POST: Superheros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                _context.Superheros.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero deletedSuperhero = _context.Superheros.Find(id);
            return View(deletedSuperhero);
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Superheros.RemoveRange(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
