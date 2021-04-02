using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ExamApplicationMVC.Models;

namespace ExamApplicationMVC.Security
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext() : base("exam") { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
    }
}