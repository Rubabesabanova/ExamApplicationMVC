using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamApplicationMVC.Models
{
    public class Topic: Entity
    {
        public Topic()
        {
            Questions = new HashSet<Question>();
        }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}