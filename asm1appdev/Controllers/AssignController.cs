using asm1appdev.Models;
using asm1appdev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    [Authorize(Roles = "Staff")]
    public class AssignController : Controller
    {
        
            private ApplicationDbContext _context;
        public AssignController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(int id)
        {
            var trainerInCourse = _context.Trainers.Where(c => c.CourseId == id).ToList();
            var traineeInCourse = _context.Trainees.Where(c => c.CourseId == id).ToList();
            var trainerandtraineecourselist  = new TrainersTraineesCourseViewModel
            {
                Trainers = trainerInCourse,
                Trainees = traineeInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerandtraineecourselist);
        }
        [HttpGet]
        public ActionResult CreateTrainerAssign(int id)
        {
            var trainerNotInCourse = _context.Trainers.Where(c => c.CourseId == null).ToList();
            var trainerandtraineecourselist = new TrainersTraineesCourseViewModel
            {
                Trainers = trainerNotInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerandtraineecourselist);
        }

        [HttpPost]
        public ActionResult CreateTrainerAssign(string CourseId, string TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainer = _context.Trainers.SingleOrDefault(t => t.TrainerId == TrainerId);
            trainer.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { id = CourseId });
        }
        [HttpGet]
        public ActionResult ChangeTrainerAssign(int CourseId, string TrainerId)
        {
            var trainerChange = _context.Trainers.SingleOrDefault(t => t.TrainerId == TrainerId);
            var CoursesExclude = _context.Courses.Where(c => c.Id != CourseId);

            var changeViewmodel = new ChangeAssignTrainer()
            {
                Courses = CoursesExclude,
                Trainer = trainerChange,
            };
            return View(changeViewmodel);
        }

        [HttpPost]
        public ActionResult ChangeTrainerAssign(string CourseId, string TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainer = _context.Trainers.SingleOrDefault(t => t.TrainerId == TrainerId);
            trainer.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { Id = CourseId });
        }
        [HttpPost]
        public ActionResult DeleteTrainerAssign(string CourseId, string TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainer = _context.Trainers.SingleOrDefault(t => t.TrainerId == TrainerId);
            trainer.CourseId = null;
            _context.SaveChanges();
            return RedirectToAction("Index/" + CourseId);
        }

        ///traineeasssign/////

        [HttpGet]
        public ActionResult CreateTraineeAssign(int id)
        {
            var traineeNotInCourse = _context.Trainees.Where(c => c.CourseId == null).ToList();
            var trainerandtraineecourselist = new TrainersTraineesCourseViewModel()
            {
                Trainees = traineeNotInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerandtraineecourselist);
        }

        [HttpPost]
        public ActionResult CreateTraineeAssign(string CourseId, string TraineeId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainee = _context.Trainees.SingleOrDefault(t => t.TraineeId == TraineeId);
            trainee.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index/" + CourseId);
        }

        [HttpGet]
        public ActionResult ChangeTraineeAssign(int CourseId, string TraineeId)
        {
            var traineechange = _context.Trainees.SingleOrDefault(t => t.TraineeId == TraineeId);
            var coursesexclude = _context.Courses.Where(c => c.Id != CourseId);

            var changeViewmodel = new ChangeAssignTrainee()
            {
                Courses = coursesexclude,
                Trainee = traineechange,
            };
            return View(changeViewmodel);
        }

        [HttpPost]
        public ActionResult ChangeTraineeAssign(string CourseId, string TrainerId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainee = _context.Trainees.SingleOrDefault(t => t.TraineeId == TrainerId);
            trainee.CourseId = courseId;
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = CourseId });
        }
        [HttpPost]
        public ActionResult DeleteTraineeAssign(string CourseId, string TraineeId)
        {
            int courseId = Convert.ToInt32(CourseId);
            var trainee = _context.Trainees.SingleOrDefault(t => t.TraineeId == TraineeId);
            trainee.CourseId = null;
            _context.SaveChanges();
            return RedirectToAction("Index/" + CourseId);
        }
    }
}