using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Models
{
    public class scholarship :BaseClass
    {
   
        [Required(ErrorMessage = "Title field is Required")]
        [MaxLength(100, ErrorMessage = "max length of Title is 100 char")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Title field is Required")]
        [MaxLength(100, ErrorMessage = "max length of Title is 100 char")]
        public string TitleInEnglish { get; set; }
        public string Description { get; set; }
        public string ImagPath { get; set; }
    }
}
