namespace testagat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskComments",
                c => new
                    {
                        TaskCommentID = c.Int(nullable: false, identity: true),
                        TaskID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CommentText = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.TaskCommentID)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TaskID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 256),
                        Creator_UserID = c.Int(),
                        Executor_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Users", t => t.Creator_UserID)
                .ForeignKey("dbo.Users", t => t.Executor_UserID)
                .Index(t => t.Creator_UserID)
                .Index(t => t.Executor_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Login = c.String(nullable: false, maxLength: 128),
                        MiddleName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskComments", "UserID", "dbo.Users");
            DropForeignKey("dbo.TaskComments", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "Executor_UserID", "dbo.Users");
            DropForeignKey("dbo.Tasks", "Creator_UserID", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "Executor_UserID" });
            DropIndex("dbo.Tasks", new[] { "Creator_UserID" });
            DropIndex("dbo.TaskComments", new[] { "UserID" });
            DropIndex("dbo.TaskComments", new[] { "TaskID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskComments");
        }
    }
}
