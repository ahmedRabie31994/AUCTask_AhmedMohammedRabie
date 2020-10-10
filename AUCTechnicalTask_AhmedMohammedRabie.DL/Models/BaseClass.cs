using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Models
{
    public class BaseClass
    {
         [Key]
        public int Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public string IPAddress { get; set; }
        public string AddUserId { get; set; }
        public string ModifyUserId { get; set; }
    }
}
