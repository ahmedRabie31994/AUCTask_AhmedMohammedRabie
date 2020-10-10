using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.ApplyForScholarship.ApplyForScholarshipManager;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.ApplyForScholarship.Contracts;
using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ApplyFrScholarShip;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Enums;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Models;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCTechnicalTask_AhmedMohammedRabie.Controllers
{
    public class ApplyForScholarshipController : Controller
    {

        private readonly IApplyForScholarshipManager _manager;
        public ApplyForScholarshipController()
        {
            _manager = new ApplyForScholarshipManager();

        }
        // GET: ApplyForScholarship
        public ActionResult Index()
        {

            return View();
        }
        // GET: ApplyForScholarship
        public ActionResult GetUsersAppliedToScholarShipBySchId(int SchId , int? index)
        {
            int PageSize = 10;
            int PageIndex = index ?? 1;
            TempData["SchId"] = SchId;
            var query = _manager.GetAllByScholarScholarId(SchId).ToPagedList(PageIndex, PageSize); ;

            return View(query);
        }
        public ActionResult GetMyAppliesScholarshipBySchId(int? index)
        {
            string userId = User.Identity.GetUserId();
            int PageSize = 10;
            int PageIndex = index ?? 1;
            var query = _manager.GetAllByUserId(userId).ToPagedList(PageIndex, PageSize); ;

            return View(query);
        }
        [HttpPost]
        public ActionResult Create(string message, int schId)
        {
            string userId= User.Identity.GetUserId();

             
            ApplyForScholarshipDTO model = new ApplyForScholarshipDTO()
            {
                Message = message,
                ScholarshipId=schId,
                UserId=userId,
            };
            

            bool checkSuccess = _manager.Create(model);
            if (checkSuccess)
            {
                
                return RedirectToAction("Index","Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult UpdateApplyStatus(int appId , ApplyingStatus applyingStatus)
        {
            string userId = User.Identity.GetUserId();


            ApplyForScholarshipDTO model = new ApplyForScholarshipDTO()
            {
               Id =appId
               ,
               ApplyingStatus = applyingStatus,
            };


            bool checkSuccess = _manager.Update(model);
            if (checkSuccess)
            {
                var singleApply = _manager.GetById(appId);
                return RedirectToAction("GetUsersAppliedToScholarShipBySchId", routeValues: new { SchId = singleApply.ScholarshipId });

               // return RedirectToAction("Index", "Scholarship");
            }

            
            return View();
        }
        public void DownloadExcel(int SchId)
        {
            var collection = _manager.GetAllByScholarScholarId(SchId).ToList();

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "FirstName";
            Sheet.Cells["B1"].Value = "LastName";
            Sheet.Cells["C1"].Value = "universty";
            Sheet.Cells["D1"].Value = "GPA";
            Sheet.Cells["E1"].Value = "Major";
            Sheet.Cells["F1"].Value = "Message";
            int row = 2;
            foreach (var item in collection)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.FirstName;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.LastName;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.universty;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.GPA;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Major;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Message;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }


    }
}