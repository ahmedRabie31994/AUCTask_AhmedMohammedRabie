using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Models
{
    public class ApplicationUser :IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);


            //Add custom user claims here
            return userIdentity;
        }
        [Required(ErrorMessage = "this Field is Required")]
        [MaxLength(50, ErrorMessage = "National ID must less than 50 char")]

        public string FirstName { get; set; }
        [Required(ErrorMessage ="this Field is Required")]

        public string LastName { get; set; }
        [Required(ErrorMessage ="this field is required")]

        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(14,ErrorMessage ="National ID must 14 char")]
        [MinLength(14, ErrorMessage = "National ID must 14 char")]

        public string NationalId { get; set; }
        [Required(ErrorMessage = "this Field is Required")]
        public string  University{ get; set; }
        [Required(ErrorMessage = "this Field is Required")]
        public string Major { get; set; }
        [Required(ErrorMessage = "this Field is Required")]
        public float GPA { get; set; }
        public string ResumeLink { get; set; }
    }

}
