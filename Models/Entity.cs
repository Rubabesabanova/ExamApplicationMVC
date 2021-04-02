using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamApplicationMVC.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Min 3 characters")]
        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }
    }
}