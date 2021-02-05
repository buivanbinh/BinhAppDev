using asm1appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1appdev.ViewModels
{
    public class ChangeAssignTrainer
    {
        public IEnumerable<Course> Courses { get; set; }
        public Trainer Trainer { get; set; }
    }
}