using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.ApplyForScholarship.Contracts;
using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ApplyFrScholarShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Models;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Interfaces;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Repository;
using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.ApplyForScholarship.ApplyForScholarshipManager
{
    public class ApplyForScholarshipManager : IApplyForScholarshipManager
    {
        private readonly GenericUnitOfWork _unitOfWork;
        private readonly IGenericRepository<AUCTechnicalTask_AhmedMohammedRabie.DL.Models.ApplyForScholarship> _repository;
        public ApplyForScholarshipManager()
        {
            _unitOfWork = new GenericUnitOfWork();
            _repository = _unitOfWork.GetRepoInstance<AUCTechnicalTask_AhmedMohammedRabie.DL.Models.ApplyForScholarship>();
        }

        public bool Create(ApplyForScholarshipDTO item)
        {
            try
            {
                AUCTechnicalTask_AhmedMohammedRabie.DL.Models.ApplyForScholarship ApplyForScholarship = new AUCTechnicalTask_AhmedMohammedRabie.DL.Models.ApplyForScholarship()
                {
                   Message=item.Message,
                   UserId = item.UserId,
                   ScholarshipId=item.ScholarshipId,
                   ApplyingStatus=DL.Enums.ApplyingStatus.NoAction,
                   AddUserId = item.UserId,
                   
                   

                };
                _repository.Add(ApplyForScholarship);

                return _unitOfWork.SaveChanges();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ApplyForScholarshipUserDTO> GetAllByScholarScholarId(int schId)
        {
            try
            {
                IEnumerable<ApplyForScholarshipUserDTO> query = _repository.GetFiltered(x=>x.ScholarshipId==schId).OrderByDescending(field => field.Id).Select(item => new ApplyForScholarshipUserDTO()
                {
                    Id = item.Id,
                    ApplyingStatus = item.ApplyingStatus,
                    CVLink = item.User!=null ?item.User.ResumeLink : null,
                    Message = item.User != null ? item.Message : null,
                    Email = item.User != null ? item.User.Email : null,
                    FirstName = item.User != null ? item.User.FirstName : null,
                    LastName = item.User != null ? item.User.LastName : null,
                    UserId = item.User != null ? item.User.Id : null,
                    ApplyingDate = item.AddedDate,
                    Birthdate = item.User != null ? item.User.BirthDate :new DateTime(),
                    GPA= item.User != null ? item.User.GPA : 0,
                    universty= item.User != null ? item.User.University : null,
                    Major= item.User != null ? item.User.Major : null,

                });
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ScholarshipDTO> GetAllByUserId(string userId)
        {
            IEnumerable<ScholarshipDTO> query = _repository.GetFiltered(x => x.UserId == userId).OrderByDescending(field => field.Id).Select(item => new ScholarshipDTO()
            {
                Id = item.Id,
                Title = item.Scholarship !=null ? item.Scholarship.Title:null, 
                Status = item.ApplyingStatus,
                ImagPath = item.Scholarship != null ? item.Scholarship.ImagPath : null,
                
            });
            return query;
        }

        public ApplyForScholarshipDTO GetById(int id)
        {
            try
            {
                var ScholarshipApply = _repository.Get(id);


                ApplyForScholarshipDTO query = ScholarshipApply != null ? new ApplyForScholarshipDTO()
                {
                   ApplyingStatus= ScholarshipApply.ApplyingStatus,
                   ScholarshipId = ScholarshipApply.ScholarshipId,
                   UserId= ScholarshipApply.UserId,
                } : null;
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ApplyForScholarshipDTO applyViewModel)
        {
            try
            {
                 AUCTechnicalTask_AhmedMohammedRabie.DL.Models.ApplyForScholarship ApplyForScholarship = _repository.Get(applyViewModel.Id);
                ApplyForScholarship.ApplyingStatus = applyViewModel.ApplyingStatus;
                _repository.Update(ApplyForScholarship);
                return _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
