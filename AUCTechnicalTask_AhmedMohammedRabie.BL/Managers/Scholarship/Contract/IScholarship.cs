using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.Contract
{
    public interface IScholarship
    {
        IEnumerable<ScholarshipDTO> GetAll();
        ScholarshipDTO GetById(int id);
        bool Create(ScholarshipDTO item);
        bool Update(ScholarshipDTO item);
        bool Remove(int id);
    }
}
