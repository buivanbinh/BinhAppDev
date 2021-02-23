using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asm1appdev.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description should not be Empty !!!")]    
        [StringLength(255)]
        [DisplayName("Category Description")]

        public string Description { get; set; }
        
    }
}