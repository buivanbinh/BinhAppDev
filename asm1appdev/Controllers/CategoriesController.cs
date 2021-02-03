using asm1appdev.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var categories = _context.Categories.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                categories = _context.Categories
                    .Where(t => t.Name.Contains(searchString))
                    .ToList();
            }
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newCategory = new Category();


            newCategory.Name = category.Name;
            newCategory.Description = category.Description;

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var taskinDb = _context.Categories.SingleOrDefault(t => t.Id == id); 
            if (taskinDb == null) return HttpNotFound();
            return View(taskinDb);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var taskInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);

            taskInDb.Name = category.Name;
            taskInDb.Description = category.Description;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);

            if (categoryInDb == null) return HttpNotFound();

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}