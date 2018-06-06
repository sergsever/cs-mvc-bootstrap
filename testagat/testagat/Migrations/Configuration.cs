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

            context.Users.Add(new Users() {Login="derevyanko", FirstName = "Павел", LastName = "Деревянко", MiddleName = "Юрьевич" });
            context.Users.Add(new Users() {Login="trubiner", FirstName = "Павел", LastName = "Трубинер", MiddleName = "Константинович" });
            context.Users.Add(new Users() {Login="puderevyanko", FirstName = "Павел", LastName = "Деревянко", MiddleName = "Юрьевич" });
            context.Users.Add(new Users() {Login="konyashkina", FirstName = "Марина", LastName = "Коняшкина", MiddleName = "Сергеевна" });
            context.Users.Add(new Users() {Login="lomonosova", FirstName = "Ольга", LastName = "Ломоносова", MiddleName = "Олеговна" });
            context.Users.Add(new Users() {Login="sidihkin", FirstName = "Евгений", LastName = "Сидихин", MiddleName = "Владимирович" });
            context.Users.Add(new Users() {Login="barinov", FirstName = "Егор", LastName = "Баринов", MiddleName = "Валерьевич" });
            context.Users.Add(new Users() {Login="smirnov", FirstName = "Андрей", LastName = "Смирнов", MiddleName = "Сергеевич" });
            context.Users.Add(new Users() {Login="savochkin", FirstName = "Игорь", LastName = "Савочкин", MiddleName = "Юрьевич" });
            context.Users.Add(new Users() {Login="khmurov", FirstName = "Михаил", LastName = "Хмуров", MiddleName = "Генрихович" });
            context.SaveChanges();

            Users creator = context.Users.Find(1);
            Users exec = context.Users.Find(3);
            context.Tasks.Add(new Tasks() { Title = "Users Table", CreateDate = DateTime.Now, Creator = creator, Executor = exec, Description = "Сделать таблицу пользователей на стр. Users." });
            context.Tasks.Add(new Tasks() { Title = "Users List", CreateDate = DateTime.Now, Creator = context.Users.Find(4), Executor = context.Users.Find(6), Description = "Сделать список пользователей на стр. Users." });
            context.Tasks.Add(new Tasks() { Title = "Tasks Table", CreateDate = DateTime.Now, Creator = context.Users.Find(5), Executor = context.Users.Find(7), Description = "Сделать таблицу задач на стр. Tasks." });
            context.Tasks.Add(new Tasks() { Title = "Users Table", CreateDate = DateTime.Now, Creator = context.Users.Find(6), Executor = context.Users.Find(8), Description = "Сделать таблицу пользователей на стр. Users." });
            context.Tasks.Add(new Tasks() { Title = "Users List for Tasks", CreateDate = DateTime.Now, Creator = context.Users.Find(3), Executor = context.Users.Find(5), Description = "Сделать таблицу пользователей на стр. Users." });
            context.SaveChanges();

            context.TaskComments.Add(new TaskComments() { CommentText = "новая задача", UserID = 9, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "коммит", UserID = 4, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "обсуждение", UserID = 6, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "новая задача", UserID = 2, TaskID = 2 });
            context.TaskComments.Add(new TaskComments() { CommentText = "коммит", UserID = 7, TaskID = 2 });
            context.TaskComments.Add(new TaskComments() { CommentText = "обсуждение", UserID = 8, TaskID = 2 });
            context.TaskComments.Add(new TaskComments() { CommentText = "новая задача", UserID = 2, TaskID = 2 });

            context.TaskComments.Add(new TaskComments() { CommentText = "новая задача", UserID = 5, TaskID = 3 });
            context.TaskComments.Add(new TaskComments() { CommentText = "коммит", UserID = 2, TaskID = 3 });
            context.TaskComments.Add(new TaskComments() { CommentText = "обсуждение", UserID = 1, TaskID = 3 });
            context.TaskComments.Add(new TaskComments() { CommentText = "новая задача", UserID = 7, TaskID = 4 });
            context.TaskComments.Add(new TaskComments() { CommentText = "коммит", UserID = 2, TaskID = 4 });
            context.TaskComments.Add(new TaskComments() { CommentText = "обсуждение", UserID = 9, TaskID = 4 });
            context.TaskComments.Add(new TaskComments() { CommentText = "новая задача", UserID = 7, TaskID = 5 });
            context.TaskComments.Add(new TaskComments() { CommentText = "коммит", UserID = 4, TaskID = 5 });
            context.TaskComments.Add(new TaskComments() { CommentText = "обсуждение", UserID = 3, TaskID = 5 });

            context.SaveChanges();













        }
    }
}
