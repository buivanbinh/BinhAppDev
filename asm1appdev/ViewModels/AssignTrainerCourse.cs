using asm1appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1appdev.ViewModels
{
    public class AssignTrainerToCourse // TrainerCourseViewModel
    {
        public Course Course { get; set; }
        public Trainer Trainers { get; set; } // Trainer
    }
}