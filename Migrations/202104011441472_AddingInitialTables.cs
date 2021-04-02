namespace ExamApplicationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        Title = c.String(),
                        Point = c.Int(nullable: false),
                        A = c.String(),
                        B = c.String(),
                        C = c.String(),
                        D = c.String(),
                        E = c.String(),
                        TrueAnswer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                        Point = c.Int(nullable: false),
                        TrueAnswer = c.Int(nullable: false),
                        TotalQuestion = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "TopicId", "dbo.Topics");
            DropIndex("dbo.Topics", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "TopicId" });
            DropTable("dbo.Users");
            DropTable("dbo.Subjects");
            DropTable("dbo.Topics");
            DropTable("dbo.Questions");
        }
    }
}
