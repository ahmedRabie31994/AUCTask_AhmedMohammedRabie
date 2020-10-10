using AUCTechnicalTask_AhmedMohammedRabie.BL.Interfaces;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.User.Contracts;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.User.UserManagers
{
    public class UserManager : IUserManager
    {
        private readonly GenericUnitOfWork _unitOfWork;
        private readonly IGenericRepository<IdentityUserRole> _repository;
        private readonly IGenericRepository<IdentityRole> _Rolerepository;

        public UserManager()
        {
            _unitOfWork = new GenericUnitOfWork();
            _repository = _unitOfWork.GetRepoInstance<IdentityUserRole>();
            _Rolerepository= _unitOfWork.GetRepoInstance<IdentityRole>();
        }
        public string RetrieveRole(string UId)
        {
            var UserRole = _repository.GetFiltered(x=>x.UserId==UId).FirstOrDefault();
            var role = UserRole !=null? _Rolerepository.GetFiltered(x => x.Id == UserRole.RoleId).FirstOrDefault() :null;
            return role !=null ?  role.Name :null;

        }
    }
}
