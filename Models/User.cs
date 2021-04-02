using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamApplicationMVC.Models
{
    public class User: Entity
    {
        [MaxLength(100)]
        [MinLength(3)]
        [Required(ErrorMessage = "The field is required")]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        [Remote("EmailIsUnique", "Auth", HttpMethod = "POST", ErrorMessage = "Email already exists.")]
        [Required(ErrorMessage = "The field is required")]
        public string Email { get; set; }
        [MinLength(3, ErrorMessage = "Min 3 characters")]
        [Required(ErrorMessage = "The field is required")]
        public string Password { get; set; }
        [DefaultValue(0)]
        public int Point { get; set; }
        [DefaultValue(0)]
        public int TrueAnswer { get; set; }
        [DefaultValue(0)]
        public int TotalQuestion { get; set; }
    }
}