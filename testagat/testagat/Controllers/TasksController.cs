using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using testagat.Data;
using testagat.Models;

namespace testagat.Controllers
{
    public class TasksController : Controller
    {
        private TasksModel Model { get; set; }
        private RunContext RunContext { get; set; }

        public TasksController()
        {
            Model = new TasksModel();
            RunContext = RunContext.GetInstance();

        }

        private Logger log = LogManager.GetLogger("Tasks");


        public ActionResult Index()
        {
            return View("Task");
        }

        public ActionResult Edit(int TaskID)
        {
            RunContext.CurrentTaskID = TaskID;
            return View("Task");
        }
        [HttpGet]
        public ActionResult GetUsers(string filter)
        {
            List<Users> res = Model.GetUsers().ToList();
            List<Select2Result> results = new List<Select2Result>();
            foreach(Users user in res)
            {
                results.Add(new Select2Result() { id = user.UserID.ToString(), text = user.FirstName + " " + user.LastName + " " + user.MiddleName });
            }

            Select2PagedResult result = new Select2PagedResult();
            result.Total = results.Count();
            result.Results = results;
            return Json(new { Total=results.Count(), results=results} , JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult CreateTask(string UserID)
        {
            string strUserID = JsonConvert.DeserializeObject<string>(UserID);
            log.Info("createTask:");
            int userID = int.Parse(strUserID);

            Tasks task = new Tasks() { CreateDate=DateTime.Now, Title = "New", Description = "New", Creator=Model.GetUser(userID), Executor= Model.GetUser(userID) };
            int taskID = Model.AddTask(userID, "new", "desc");
            task = Model.GetTask(taskID);
            Model.SaveTask(task.TaskID, task.Title, task.Description, task.Creator.UserID, task.Executor.UserID);
            RunContext.CurrentTaskID = taskID;

            return Json("OK");
        }
        [HttpGet]
        public ActionResult GetTasks()
        {
            log.Info("get tasks:");
            List<Tasks> res = Model.GetTasks().ToList();
            int recordsTotal = res.Count();

            var retvalue =  Json(new { draw="1", recordsTotal= recordsTotal, recordsFiltered=recordsTotal, data=res }, JsonRequestBehavior.AllowGet);
            return retvalue;
        }
        [HttpGet]
        public ActionResult GetTask(string taskID)
        {
            int id = int.Parse(taskID);
            Tasks res = Model.GetTask(id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveTask(int taskID, string title, string description, int creatorID, int ExecutorID)
        {
            Model.SaveTask(taskID, title, description, creatorID, ExecutorID);
            return Json("OK");
        }
        [HttpDelete]
        public ActionResult DeleteTask(int taskID)
        {
            Model.Delete(taskID);
            return Json("Ok");
        }
        [HttpPost]
        public string SetExecutor([System.Web.Http.FromBody]Tasks task, string userID)
        {
            int id = int.Parse(userID);
            Model.SetExecutor(task, id);
            return JsonConvert.SerializeObject("OK");
        }
        [HttpPost]
        public ActionResult AddComment(int taskID, int userID, string comment)
        {
            Model.AddComment(taskID, userID, comment);
            return Json("OK");
        }

        public ActionResult GetComments(string taskID)
        {
            int id = int.Parse(taskID);
            List<TaskComments> res = Model.GetComments(id).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveComment(string commentID, string comment)
        {
            int id = int.Parse(commentID);
            Model.EditComment(id, comment);
            return Json("OK");
        }
        [HttpDelete]
        public string DeleteComment(string commentID)
        {
            int id = int.Parse(commentID);
            Model.DeleteComment(id);
            return JsonConvert.SerializeObject("OK");
        }

        public string GetFiltered(string filter)
        {
            List<Tasks> res = Model.GetFiltered(filter).ToList();
            return JsonConvert.SerializeObject(res);
        }

        
    }
}