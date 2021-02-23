using asm1appdev.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    [Authorize(Roles = "Staff")]
    public class TraineesController : Controller
    {
        
        public ApplicationDbContext _context;
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchInput)
        {
            var trainees = _context.Trainees.ToList();

            if (!searchInput.IsNullOrWhiteSpace())
            {
                trainees = _context.Trainees
                     .Where(c => c.ApplicationUser.UserName.Contains(searchInput) ||
                     c.ProgramingLanguage.Contains(searchInput) || c.ToeicScore.Contains(searchInput))
                     .ToList();
            }
            return View(trainees);
        }
        public ActionResult Details(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            return View(traineeInDb);
        }
        [HttpGet]
        public ActionResult Update(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            if (traineeInDb == null)
            {
                return HttpNotFound();
            }
            return View(traineeInDb);
        }
        [HttpPost]
        public ActionResult Update(Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == trainee.TraineeId);
            {
                traineeInDb.ApplicationUser.FullName = trainee.ApplicationUser.FullName;
                traineeInDb.Age = trainee.Age;
                traineeInDb.DayOfBirth = trainee.DayOfBirth;
                traineeInDb.Education = trainee.Education;
                traineeInDb.ProgramingLanguage = trainee.ProgramingLanguage;
                traineeInDb.ToeicScore = trainee.ToeicScore;
                traineeInDb.Location = trainee.Location;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);

            if (traineeInDb == null) return HttpNotFound();

            _context.Trainees.Remove(traineeInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}