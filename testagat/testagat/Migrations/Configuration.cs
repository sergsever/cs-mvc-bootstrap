namespace testagat.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<testagat.AgatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(testagat.AgatDbContext context)
        {

			//if (System.Diagnostics.Debugger.IsAttached == false)
			//{
			//    System.Diagnostics.Debugger.Launch();
			//}
			context.Database.ExecuteSqlCommand("delete from dbo.Users");
			context.Database.ExecuteSqlCommand("delete from dbo.TaskComments");
			context.Database.ExecuteSqlCommand("delete from dbo.Tasks");

			context.Users.Add(new Users() {Login="ivanovii", FirstName = "Иван", LastName = "Иванов", MiddleName = "Иванович" });
            context.Users.Add(new Users() {Login="petrov", FirstName = "Петр", LastName = "Петров", MiddleName = "Петрович" });
            context.SaveChanges();

            Users creator = context.Users.Find(1);
            Users exec = context.Users.Find(2);
			context.Tasks.Add(new Tasks() { Title = "Users Table", CreateDate = DateTime.Now, Creator = creator, Executor = exec, Description = "Создать БД объекты для  Users." });
            context.Tasks.Add(new Tasks() { Title = "Users List", CreateDate = DateTime.Now, Creator = context.Users.Find(4), Executor = context.Users.Find(6), Description = "Написать DAO для Users." });
            context.Tasks.Add(new Tasks() { Title = "Tasks Table", CreateDate = DateTime.Now, Creator = context.Users.Find(5), Executor = context.Users.Find(7), Description = "Создать БД объекты для Tasks." });
            context.SaveChanges();

            context.TaskComments.Add(new TaskComments() { CommentText = "Выполнено", UserID = 1, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "Готово", UserID = 2, TaskID = 2 });
            context.SaveChanges();













        }
    }
}
