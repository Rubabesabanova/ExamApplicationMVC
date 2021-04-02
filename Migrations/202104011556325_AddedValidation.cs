namespace ExamApplicationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Subjects", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Topics", "Name", c => c.String(maxLength: 100));
        }
    }
}
