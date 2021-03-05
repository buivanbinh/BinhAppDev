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
    public class EnrollmentController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public EnrollmentController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );
        }
        public ActionResult Index()
        {
            var CourseList = _context.Courses.ToList();
            return View(CourseList);
        }
        public ActionResult Trainee(int id)// course id
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = id; // lưu course id
            List<ApplicationUser> TraineeList = new List<ApplicationUser>();
            var Trainees = _context.Users.ToList();// list tất cả suser
            foreach (var item in Trainees)// kiếm trainee
            {
                var userTemp = _userManager.GetRoles(item.Id);
                if (userTemp.FirstOrDefault() == "Trainee")
                {
                    TraineeList.Add(item);
                }
            }
            return View(TraineeList);// view ra
        }
        public ActionResult Enroll(string traineeid, int courseid)
        {
            if (traineeid == null)
            {
                return HttpNotFound();
            }
            if (courseid == null)
            {
                return HttpNotFound();
            }
            var isEnrolled = _context.Enrollments.Where(e => e.TraineeId == traineeid && e.CourseId == courseid);// check đã enroll chưa
            if (!isEnrolled.Any())// chưa thì
            {
                Enrollment enrollment = new Enrollment()// tạo object enrollmentt
                {
                    CourseId = courseid,
                    TraineeId = traineeid
                };
                _context.Enrollments.Add(enrollment);
            }
            _context.SaveChanges();
            var CourseList = _context.Courses.ToList();// trả về list courrse
            return View("Index", CourseList);
        }
        public ActionResult Delete(string traineeid, int courseid)
        {
            if (traineeid == null)
            {
                return HttpNotFound();
            }
            if (courseid == null)
            {
                return HttpNotFound();
            }
            var enrollment = _context.Enrollments.Where(e => e.TraineeId == traineeid && e.CourseId == courseid).FirstOrDefault();
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            var CourseList = _context.Courses.ToList();
            return View("Index", CourseList);
        }
    }
}