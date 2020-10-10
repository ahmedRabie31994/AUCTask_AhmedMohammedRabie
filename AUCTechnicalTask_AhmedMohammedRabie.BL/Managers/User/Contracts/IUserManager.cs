using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.User.Contracts
{
    public interface IUserManager
    {
        string RetrieveRole(string UId);
    }
}
