using asm1appdev.Models;
using asm1appdev.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace asm1appdev.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );
        }
        // GET: Staffs
        public ActionResult Index(string searchInput)
        {
            List<ApplicationUser> StaffList = new List<ApplicationUser>();
            var staffs = _context.Users.ToList();
            foreach (var item in staffs)
            {
                var userTemp = _userManager.GetRoles(item.Id);
                if (userTemp.FirstOrDefault() == "Staff")
                {
                    StaffList.Add(item);
                }
            }
            if (!searchInput.IsNullOrWhiteSpace())
            {
                staffs = _context.Users
                     .Where(s => s.FullName.Contains(searchInput) || s.UserName.Contains(searchInput))
                     .ToList();
                StaffList.Clear();
                foreach (var item in staffs)
                {
                    var userTemp = _userManager.GetRoles(item.Id);
                    if (userTemp.FirstOrDefault() == "Staff")
                    {
                        StaffList.Add(item);
                    }
                }
            }
            return View(StaffList);
        }
        public ActionResult Update(string id)
        {
            StarffViewModel staffViewModel = new StarffViewModel();
            staffViewModel.ApplicationUser = _context.Users.SingleOrDefault(t => t.Id == id);
            if (staffViewModel == null)
            {
                return HttpNotFound();
            }
            return View(staffViewModel);
        }
        [HttpPost]
        public ActionResult Update(StarffViewModel staffViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var staffInDb = _context.Users.SingleOrDefault(s => s.Id == staffViewModel.ApplicationUser.Id);
            {
                staffInDb.FullName = staffViewModel.ApplicationUser.FullName;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
           
            var staffInDb = _context.Users.SingleOrDefault(s => s.Id == id);
          
            if (staffInDb == null)
            {
                return HttpNotFound();
            }
           
            _context.Users.Remove(staffInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}