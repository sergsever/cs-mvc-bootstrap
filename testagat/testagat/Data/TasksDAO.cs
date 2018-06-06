using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace testagat.Data
{
    public class TasksDAO
    {
        private AgatDbContext DbContext { get; set; }
        public TasksDAO()
        {
            DbContext = new AgatDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
        }

        public int InsertTask(int userID, string title, string desc)
        {
            Tasks task = new Tasks()
            {
                Title = title,
                Description = desc,
                CreateDate = DateTime.Now,
                Creator = DbContext.Users.Find(userID),
                Executor = DbContext.Users.Find(userID)
            };

            try
            {

                DbContext.Tasks.Add(task);
                DbContext.SaveChanges();
            }
            catch(Exception e)
            {
                new Exception("insert task ex:" + e.Message);
            }
            int res = task.TaskID;
            return res;

        }

        public Tasks Save(Tasks task)
        {
            int id = task.TaskID;
            Tasks curr = DbContext.Tasks.Find(id);
            curr.Title = task.Title;
            curr.Description = task.Description;
            curr.Executor = task.Executor;
            DbContext.SaveChanges();
            return DbContext.Tasks.Find(id);
        }

        public Tasks GetTask(int taskID)
        {
            Tasks res = DbContext.Tasks.Include(t => t.Creator).Include(t => t.Executor).Where(t => t.TaskID == taskID).First();
            return res;
        }

        public IEnumerable<Tasks> GetTasks()
        {
            IEnumerable<Tasks> res;
            try
            {
                 res = DbContext.Tasks.Include(t => t.Creator).Include(t => t.Executor).ToList();
            }
            catch(Exception e)
            {
                throw new Exception("get tasks ex:" + e.Message);
            }
            return res;
        }

        public void AddComment(int taskID, int userID, string comment)
        {
            
            DbContext.TaskComments.Add(new TaskComments() { TaskID=taskID, UserID = userID, CommentText = comment });
            DbContext.SaveChanges();
        }

        public IEnumerable<TaskComments> GetComments(int taskID)
        {
            List<TaskComments> res = DbContext.TaskComments.Include(c => c.User).Where(c => c.TaskID == taskID).ToList();
            return res;
        }

        public void EditComment(int commentID, string comment)
        {
            TaskComments comm = DbContext.TaskComments.Find(commentID);
            comm.CommentText = comment;
            DbContext.SaveChanges();
        }

        public void DeleteComment(int commentID)
        {
            TaskComments comm = DbContext.TaskComments.Find(commentID);
            DbContext.TaskComments.Remove(comm);
            DbContext.SaveChanges();
        }

        public IEnumerable<Tasks> GetFiltered(string filter)
        {
            DateTime filterDate = DateTime.MinValue;
            if (DateTime.TryParse(filter, out filterDate))
                filterDate = DateTime.Parse(filter);
                
            List<Tasks> res = DbContext.Tasks.Include(t => t.Creator).Include(t => t.Executor).Where(t => t.Creator.LastName.Contains(filter) || t.Executor.LastName.Contains(filter)
            || t.Title.Contains(filter) || (t.CreateDate == filterDate)).ToList();
            return res;
        }

        public void SaveTask(int taskID, string title, string description, int creatorID, int executorID)
        {
            if (taskID == 0)
            {
                Tasks task = new Tasks() { CreateDate = DateTime.Now, Title = title, Description = description,
                    Creator = DbContext.Users.Find(creatorID), Executor = DbContext.Users.Find(executorID) };
                DbContext.Tasks.Add(task);
            }
            else
            {
                Tasks task = DbContext.Tasks.Include(t => t.Creator).Include(t => t.Executor).Where(t => t.TaskID == taskID).First();
                task.Title = title;
                task.Description = description;
                task.Creator =  creatorID == 0? null: DbContext.Users.Find(creatorID);
                task.Executor = executorID == 0? null: DbContext.Users.Find(executorID);
            }
            try
            {
                DbContext.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                throw new Exception("Save task ex:" + e.Message);
            }

        }

        public void DeleteTask(int taskID)
        {
            Tasks task = DbContext.Tasks.Find(taskID);
            DbContext.Tasks.Remove(task);
            DbContext.SaveChanges();
        }
    }
}