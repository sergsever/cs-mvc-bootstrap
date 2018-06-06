using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testagat.Data;

namespace testagat.Models
{
    public class TasksModel
    {
        private TasksDAO TasksDAO { get; set; }
        private UsersDAO UsersDAO { get; set; }

        public TasksModel()
        {
            TasksDAO = new TasksDAO();
            UsersDAO = new UsersDAO();
        }

        public Users GetUser(int userID)
        {
            return UsersDAO.GetUser(userID);
        }

        public int AddTask(int userID, string title, string description)
        {
            return TasksDAO.InsertTask(userID, title, description);
        }

        public Tasks GetTask(int TaskID)
        {
            return TasksDAO.GetTask(TaskID);
        }

        public IEnumerable<Users> GetUsers()
        {
            return UsersDAO.GetUsers();
        }

        //public Tasks SaveTask(Tasks task)
        //{
        //    return TasksDAO.Save(task);
        //}

        public void SaveTask(int taskID, string title, string description, int creatorID, int executorID)
        {
            TasksDAO.SaveTask(taskID, title, description, creatorID, executorID);
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return TasksDAO.GetTasks();
        }

        public void Save(Tasks task)
        {
            TasksDAO.Save(task);
        }

        public void Delete(int taskID)
        {
            TasksDAO.DeleteTask(taskID);
        }

        public void SetExecutor(Tasks task, int userID)
        {
            Users user = UsersDAO.GetUser(userID);
            task.Executor = user;
            TasksDAO.Save(task);

        }

        public void AddComment(int taskID, int userID, string comment)
        {
            TasksDAO.AddComment(taskID, userID, comment);
        }

        public IEnumerable<TaskComments> GetComments(int taskID)
        {
            return TasksDAO.GetComments(taskID);
        }

        public void EditComment(int commentID, string comment)
        {
            TasksDAO.EditComment(commentID, comment);
        }

        public void DeleteComment(int commentID)
        {
            TasksDAO.DeleteComment(commentID);
        }

        public IEnumerable<Tasks> GetFiltered(string filter)
        {
            return TasksDAO.GetFiltered(filter);
        }
    }
}