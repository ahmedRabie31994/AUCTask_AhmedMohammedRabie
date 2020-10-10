using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ApplyFrScholarShip;
using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.ApplyForScholarship.Contracts
{
    public interface IApplyForScholarshipManager
    {
        IEnumerable<ApplyForScholarshipUserDTO> GetAllByScholarScholarId(int schId);
        IEnumerable<ScholarshipDTO> GetAllByUserId(string userId);

        ApplyForScholarshipDTO GetById(int id);
        bool Create(ApplyForScholarshipDTO item);
        bool Update(ApplyForScholarshipDTO applyViewModel);
        //bool Remove(int id);
    }
}
