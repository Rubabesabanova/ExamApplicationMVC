namespace ExamApplicationMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExamApplicationMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamApplicationMVC.Security.ExamDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamApplicationMVC.Security.ExamDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(
                 p => p.Email,
                  new User { Name = "Ali", Surname = "Hesenov", Email = "ali@gmail.com", Password = "123" },
                 new User { Name = "Deniz", Surname = "Erdem", Email = "deniz@gmail.com", Password = "123" },
                  new User { Name = "Test", Surname = "Example", Email = "test@gmail.com", Password = "123" }
                );
            context.Subjects.AddOrUpdate(
                 p => p.Name,
                  new Subject { Name = "Astronomy" },
                 new Subject { Name = "Math" },
                  new Subject { Name = "Philosophy" }
                );
            context.Topics.AddOrUpdate(
                 p => p.Name,
                  new Topic { Name = "Black holes", SubjectId = 1 },
                 new Topic { Name = "Discrete Math", SubjectId = 2 },
                  new Topic { Name = "Logic & Argumentation", SubjectId = 3 }
                );
            context.Questions.AddOrUpdate(
                 p => p.Title,
                  new Question { TopicId = 1, Title = "What powerful force allows black holes to absorb light?", A = "Nuclear fusion", B = "Electromagnetism", C = "Gravity", D = "Nuclear bonding", E = "All of the above", TrueAnswer = 3 },
                 new Question { TopicId = 1, Title = " A function is said to be ______________, if and only if f(a) = f(b) implies that a = b for all a and b in the domain of f.", A = "One-to-many", B = " Many-to-many", C = "None of these", D = "One-to-one", E = "Many-to-one", TrueAnswer = 4 },
                  new Question { TopicId = 2, Title = " A function is said to be ______________, if and only if f(a) = f(b) implies that a = b for all a and b in the domain of f.", A = "One-to-many", B = " Many-to-many", C = "None of these", D = "One-to-one", E = "Many-to-one", TrueAnswer = 4 }
                );
        }
    }
}
