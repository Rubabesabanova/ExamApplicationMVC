using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamApplicationMVC.Models
{
    public class Subject: Entity
    {
        public Subject()
        {
            Topics = new HashSet<Topic>();
        }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}