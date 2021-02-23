using asm1appdev;
using asm1appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1appdev.ViewModels
{
    public class UserProfile
    {
        public Trainer TrainerInWeb { get; set; }
        public Trainee TraineeInWeb { get; set; }
        public ApplicationUser UserInWeb { get; set; }
    }
}