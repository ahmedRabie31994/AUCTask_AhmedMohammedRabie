using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ApplyFrScholarShip
{
    public class ApplyForScholarshipDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ScholarshipId { get; set; }
        
        public virtual ScholarshipDTO Scholarship { get; set; }
        public ApplyingStatus ApplyingStatus { get; set; }
        public string Message { get; set; }

    }
}
