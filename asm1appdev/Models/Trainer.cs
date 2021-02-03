using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asm1appdev.Models
{
    public class Trainer
    {
        [ForeignKey("ApplicationUser")]
        [Key]

        public string TrainerId { get; set; }


        public TrainerType Type { get; set; }
        [DisplayName("Working Place")]
        public string WorkingPlace { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("EMail")]
        public string Email { get; set; }
        public enum TrainerType
        {
            None = 0,
            Internal = 1,
            External = 2
        }
        public int? CourseId { get; set; }
        public Course course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    
}