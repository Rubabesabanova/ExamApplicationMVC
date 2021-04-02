using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamApplicationMVC.Models
{
    public class HomeViewModel
    {
        public List<Topic> Topics { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Question> Questions { get; set; }
    }
}