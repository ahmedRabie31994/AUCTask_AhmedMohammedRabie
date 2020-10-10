using AUCTechnicalTask_AhmedMohammedRabie.DL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Models
{
    public  class ApplyForScholarship :BaseClass
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual  ApplicationUser User { get; set; }
        public int ScholarshipId { get; set; }
        [ForeignKey("ScholarshipId")]
        public virtual scholarship Scholarship { get; set; }
        public ApplyingStatus ApplyingStatus { get; set; }
        public string Message { get; set; }

    }
}
