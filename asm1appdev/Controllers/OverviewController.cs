using asm1appdev.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    [Authorize(Roles = "Staff")]
    public class OverviewController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public OverviewController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );
        }
        // GET: Overview
        public ActionResult Index()
        {
            var CourseList = _context.Courses.ToList();
            return View(CourseList);
        }
        public ActionResult Overview(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var TraineeIDList = _context.Enrollments.Where(e=> e.CourseId == id).ToList();
            List<ApplicationUser> Trainees = new List<ApplicationUser>();//tạo list để chứa 
            foreach (var Id in TraineeIDList)
            {
                var trainee = _context.Users.Find(Id.TraineeId);
                if (trainee != null)
                {
                    Trainees.Add(trainee);
                }
            }
            return View(Trainees);
        }
    }
}