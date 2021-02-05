using asm1appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1appdev.ViewModels
{
    public class TrainersTraineesCourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
    }
}