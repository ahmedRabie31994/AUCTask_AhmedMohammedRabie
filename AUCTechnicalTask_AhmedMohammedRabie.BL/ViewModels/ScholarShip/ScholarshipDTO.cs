using AUCTechnicalTask_AhmedMohammedRabie.DL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip
{
    public class ScholarshipDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title field is Required")]
        [MaxLength(100, ErrorMessage = "max length of Title is 100 char")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Title field is Required")]
        [MaxLength(100, ErrorMessage = "max length of Title is 100 char")]
        public string TitleInEnglish { get; set; }
        public string Description { get; set; }
        public string ImagPath { get; set; }
        public DateTime AddedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }
        public string IPAddress { get; set; }
        public string AddUserId { get; set; }
        public string ModifyUserId { get; set; }
        public ApplyingStatus Status { get; set; }
    }
}
