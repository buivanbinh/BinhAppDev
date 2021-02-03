using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asm1appdev.Models
{
    public class Trainee
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string TraineeId { get; set; }
        [DisplayName("Age")]
        public string Age { get; set; }
        [DisplayName("Day Of Birth")]
        public string DayOfBirth { get; set; }
        [DisplayName("Education")]
        public string Education { get; set; }
        [DisplayName("Programing Language")]
        public string ProgramingLanguage { get; set; }
        [DisplayName("ToeicScore")]
        public string ToeicScore { get; set; }
        [DisplayName("Experience")]
        public int Experience { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        public int? CourseId { get; set; }
        public Course course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}