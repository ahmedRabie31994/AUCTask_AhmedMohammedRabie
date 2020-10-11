using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.Contract;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.ScholarshipManager;
using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCTechnicalTask_AhmedMohammedRabie.Controllers
{
    public class ScholarshipController : Controller
    {
        private readonly IScholarship _manager;
        public ScholarshipController()
        {
            _manager = new ScholarshipManager();
           
        }
        // GET: Scholarhip
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int? index)
        {
            int PageSize = 10;
            int PageIndex = index ?? 1;
            var list = _manager.GetAll().ToPagedList(PageIndex, PageSize);
            return View(list);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var item = _manager.GetById(Id);
            return View(item);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(string Title,string TitleInEng,string Description, HttpPostedFileBase scholarshipImage)
        {
            //Title 
            ScholarshipDTO model = new ScholarshipDTO()
            {
                Title= Title,
                TitleInEnglish=TitleInEng,
                Description=Description,
            };
            if ( !ModelState.IsValid)
            {
                return View();
            }
            if(scholarshipImage !=null)
            {
                    var Extension = scholarshipImage.FileName.Substring(scholarshipImage.FileName.LastIndexOf('.')).ToLower();
                    var LowerExtension = Extension.ToLower();
                    string FileNameImage = "scholarshipImage-" + Guid.NewGuid().ToString() + LowerExtension;
                    model.ImagPath = FileNameImage;

                    string path = Path.Combine(Server.MapPath("~/UploadedImages/scholarship"), FileNameImage.Replace(" ", "_"));
                    scholarshipImage.SaveAs(path);
            }
           

            bool checkSuccess =  _manager.Create(model);
            if(checkSuccess)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}