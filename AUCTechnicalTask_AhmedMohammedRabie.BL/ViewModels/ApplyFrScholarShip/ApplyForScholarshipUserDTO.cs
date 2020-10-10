using AUCTechnicalTask_AhmedMohammedRabie.DL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ApplyFrScholarShip
{
    public class ApplyForScholarshipUserDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ApplyingStatus ApplyingStatus { get; set; }
        public string CVLink  { get; set; }
        public string Message { get; set; }
        public DateTime ApplyingDate { get; set; }
        public DateTime Birthdate { get; set; }
        public float GPA { get; set; }
        public string universty { get; set; }
        public string Major { get; set; }
    }
}
