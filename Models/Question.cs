using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamApplicationMVC.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        [MinLength(3, ErrorMessage = "Min 3 characters")]
        public string Title { get; set; }
        [DefaultValue(10)]
        public int Point { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public int TrueAnswer { get; set; }

    }
}