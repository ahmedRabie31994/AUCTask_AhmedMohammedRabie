using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.Contract;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.ScholarshipManager;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.User.Contracts;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.User.UserManagers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCTechnicalTask_AhmedMohammedRabie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScholarship _manager;
        private readonly IUserManager _userManager;
        public HomeController()
        {
            _manager = new ScholarshipManager();
            _userManager = new UserManager();
        }
        public ActionResult Index()
        {
            string UId = User.Identity.GetUserId();
            var RoleName = _userManager.RetrieveRole(UId);
            if(RoleName == "Admin")
            {
                return RedirectToAction("Index", "Scholarship");
            }
            var list = _manager.GetAll();
            return View(list);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}