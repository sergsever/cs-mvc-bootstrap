using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testagat.Models;

namespace testagat.Controllers
{
    public class UsersController : Controller
    {

        private UsersModel Model;

        public UsersController()
        {
            Model = new UsersModel();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View("Users");
        }

        public ActionResult GetUsers()
        {
            List<Users> res = Model.GetAllUsers().ToList();
            int recordsTotal = res.Count();

            var retvalue = Json(new { draw = "1", recordsTotal = recordsTotal, recordsFiltered = recordsTotal, data = res }, JsonRequestBehavior.AllowGet);
            return retvalue;
        }
        [HttpGet]
        public ActionResult GetUser(string userID)
        {
            string struserID = JsonConvert.DeserializeObject<string>(userID);
            int id = int.Parse(struserID);
            Users res = Model.GetUser(id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpDelete]
        public ActionResult DeleteUser(string userID)
        {
            string strUserID = JsonConvert.DeserializeObject<string>(userID);
            int id = int.Parse(strUserID);
            Model.DeleteUser(id);
            return Json("OK");
        }
        [HttpPost]
        public ActionResult CreateUser([System.Web.Http.FromBody]Users user)
        {
            int res = Model.CreateUser(user);
            return Json(res);
        }
        [HttpPost]
        public ActionResult SaveUser(int userID, string login, string firstname, string lastname, string middlename)
        {
            if (userID == 0)
            {
                Users user = new Users() { Login = login, FirstName = firstname, LastName = lastname, MiddleName = middlename };
                Model.CreateUser(user);
            }
            else
            {
                Users user = new Users() {UserID=userID, Login = login, FirstName = firstname, LastName = lastname, MiddleName = middlename };
                Model.SaveUser(user);

            }

            return Json("OK");
        }
    }
    
}