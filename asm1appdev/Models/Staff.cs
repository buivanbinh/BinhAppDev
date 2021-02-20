using asm1appdev.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APSDevApp.Models
{
    public class Staff
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string StaffId { get; set; }
        [DisplayName("Age")]
        public string Age { get; set; }
        [DisplayName("Day Of Birth")]
        public string DayOfBirthday { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}