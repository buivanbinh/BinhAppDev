using asm1appdev.Models;
using asm1appdev.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var courses = _context.Courses.Include(t => t.Category).ToList();

            if (!searchString.IsNullOrWhiteSpace())
            {
                courses = _context.Courses
                    .Where(t => t.Name.Contains(searchString))
                    .Include(t => t.Category)
                    .ToList();
            }
            return View(courses);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseCategoriesViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newCourse = new Course()
            {
                Name = course.Name,
                Description = course.Description,
                CategoryId = course.CategoryId
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //kkk
        public ActionResult Delete(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);

            if (courseInDb == null) return HttpNotFound();

            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {




            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (courseInDb == null) return HttpNotFound();

            var viewModel = new CourseCategoriesViewModel()
            {
                Course = courseInDb,
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }
        public ActionResult Details( int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            var courses = _context.Courses.Include(c => c.Category).ToList();
            return View(courseInDb);
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CourseCategoriesViewModel()
                {
                    Course = course,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);

            courseInDb.Name = course.Name;
            courseInDb.Description = course.Description;
            courseInDb.CategoryId = course.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}