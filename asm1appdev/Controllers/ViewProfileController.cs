using asm1appdev.Models;
using asm1appdev.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    [Authorize(Roles = "Trainer,Trainee")]
    public class ViewProfileController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ViewProfileController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult ViewProfile()
        {
            var userIdCurrent = User.Identity.GetUserId();
            var userInWeb = _context.Users.SingleOrDefault(u => u.Id == userIdCurrent);
            if (User.IsInRole("Trainer"))
            {
                var trainerInWeb = _context.Trainers.SingleOrDefault(t => t.TrainerId == userInWeb.Id);
                /* var courseTrainer = _context.Courses.SingleOrDefault(c => c.Id == trainerInWeb.CourseId);*/
                var trainerInfor = new UserProfile()
                {
                    UserInWeb = userInWeb,
                    TrainerInWeb = trainerInWeb
                };
                return View(trainerInfor);
            }
            if (User.IsInRole("Trainee"))
            {
                var traineeInWeb = _context.Trainees.SingleOrDefault(t => t.TraineeId == userInWeb.Id);
                var traineeInfor = new UserProfile()
                {
                    UserInWeb = userInWeb,
                    TraineeInWeb = traineeInWeb
                };
                return View(traineeInfor);
            }

            var userInfor = new UserProfile()
            {
                UserInWeb = userInWeb
            };
            return View(userInfor);

        }
        
        public ActionResult ViewCourse()
        {
            var userIdCurrent = User.Identity.GetUserId();
            var userInWeb = _context.Users.SingleOrDefault(u => u.Id == userIdCurrent);
            if (User.IsInRole("Trainer"))
            {
                var trainerInWeb = _context.Trainers.SingleOrDefault(t => t.TrainerId == userInWeb.Id);
                var courseTrainer = _context.Courses.SingleOrDefault(c => c.Id == trainerInWeb.CourseId);
                var courses = _context.Courses.Include("Category").ToList();
                var trainerInfor = new UserProfile()
                {
                    UserInWeb = userInWeb,
                    TrainerInWeb = trainerInWeb
                };
                return View(courseTrainer);
            }
            else if (User.IsInRole("Trainee"))
            {
                var traineeInWeb = _context.Trainees.SingleOrDefault(t => t.TraineeId == userInWeb.Id);
                var courseTrainee = _context.Courses.SingleOrDefault(c => c.Id == traineeInWeb.CourseId);
                var courses = _context.Courses.Include("Category").ToList();
                var traineeInfor = new UserProfile()
                {
                    UserInWeb = userInWeb,
                    TraineeInWeb = traineeInWeb
                };
                return View(courseTrainee);
            }
            return HttpNotFound();
        }
        
    }
}