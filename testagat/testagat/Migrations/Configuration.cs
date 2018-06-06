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

            context.Users.Add(new Users() {Login="derevyanko", FirstName = "�����", LastName = "���������", MiddleName = "�������" });
            context.Users.Add(new Users() {Login="trubiner", FirstName = "�����", LastName = "��������", MiddleName = "��������������" });
            context.Users.Add(new Users() {Login="puderevyanko", FirstName = "�����", LastName = "���������", MiddleName = "�������" });
            context.Users.Add(new Users() {Login="konyashkina", FirstName = "������", LastName = "���������", MiddleName = "���������" });
            context.Users.Add(new Users() {Login="lomonosova", FirstName = "�����", LastName = "����������", MiddleName = "��������" });
            context.Users.Add(new Users() {Login="sidihkin", FirstName = "�������", LastName = "�������", MiddleName = "������������" });
            context.Users.Add(new Users() {Login="barinov", FirstName = "����", LastName = "�������", MiddleName = "����������" });
            context.Users.Add(new Users() {Login="smirnov", FirstName = "������", LastName = "�������", MiddleName = "���������" });
            context.Users.Add(new Users() {Login="savochkin", FirstName = "�����", LastName = "��������", MiddleName = "�������" });
            context.Users.Add(new Users() {Login="khmurov", FirstName = "������", LastName = "������", MiddleName = "����������" });
            context.SaveChanges();

            Users creator = context.Users.Find(1);
            Users exec = context.Users.Find(3);
            context.Tasks.Add(new Tasks() { Title = "Users Table", CreateDate = DateTime.Now, Creator = creator, Executor = exec, Description = "������� ������� ������������� �� ���. Users." });
            context.Tasks.Add(new Tasks() { Title = "Users List", CreateDate = DateTime.Now, Creator = context.Users.Find(4), Executor = context.Users.Find(6), Description = "������� ������ ������������� �� ���. Users." });
            context.Tasks.Add(new Tasks() { Title = "Tasks Table", CreateDate = DateTime.Now, Creator = context.Users.Find(5), Executor = context.Users.Find(7), Description = "������� ������� ����� �� ���. Tasks." });
            context.Tasks.Add(new Tasks() { Title = "Users Table", CreateDate = DateTime.Now, Creator = context.Users.Find(6), Executor = context.Users.Find(8), Description = "������� ������� ������������� �� ���. Users." });
            context.Tasks.Add(new Tasks() { Title = "Users List for Tasks", CreateDate = DateTime.Now, Creator = context.Users.Find(3), Executor = context.Users.Find(5), Description = "������� ������� ������������� �� ���. Users." });
            context.SaveChanges();

            context.TaskComments.Add(new TaskComments() { CommentText = "����� ������", UserID = 9, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "������", UserID = 4, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����������", UserID = 6, TaskID = 1 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����� ������", UserID = 2, TaskID = 2 });
            context.TaskComments.Add(new TaskComments() { CommentText = "������", UserID = 7, TaskID = 2 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����������", UserID = 8, TaskID = 2 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����� ������", UserID = 2, TaskID = 2 });

            context.TaskComments.Add(new TaskComments() { CommentText = "����� ������", UserID = 5, TaskID = 3 });
            context.TaskComments.Add(new TaskComments() { CommentText = "������", UserID = 2, TaskID = 3 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����������", UserID = 1, TaskID = 3 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����� ������", UserID = 7, TaskID = 4 });
            context.TaskComments.Add(new TaskComments() { CommentText = "������", UserID = 2, TaskID = 4 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����������", UserID = 9, TaskID = 4 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����� ������", UserID = 7, TaskID = 5 });
            context.TaskComments.Add(new TaskComments() { CommentText = "������", UserID = 4, TaskID = 5 });
            context.TaskComments.Add(new TaskComments() { CommentText = "����������", UserID = 3, TaskID = 5 });

            context.SaveChanges();













        }
    }
}
