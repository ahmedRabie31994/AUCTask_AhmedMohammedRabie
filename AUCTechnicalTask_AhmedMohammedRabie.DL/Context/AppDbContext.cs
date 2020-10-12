using AUCTechnicalTask_AhmedMohammedRabie.DL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Context
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
          : base("DefaultConnection")
        {
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        public DbSet<scholarship>  Scholarships { get; set; }
        public DbSet<ApplyForScholarship>   ApplyForScholarships { get; set; }


    }
}
