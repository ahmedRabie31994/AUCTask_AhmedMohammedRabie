using AUCTechnicalTask_AhmedMohammedRabie.BL.Interfaces;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.Contract;
using AUCTechnicalTask_AhmedMohammedRabie.BL.Repository;
using AUCTechnicalTask_AhmedMohammedRabie.BL.ViewModels.ScholarShip;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Managers.Scholarship.ScholarshipManager
{
    public class ScholarshipManager : IScholarship
    {
        private readonly GenericUnitOfWork _unitOfWork;
        private readonly IGenericRepository<scholarship> _repository;
        public ScholarshipManager()
        {
            _unitOfWork = new GenericUnitOfWork();
            _repository = _unitOfWork.GetRepoInstance<scholarship>();
        }

        public bool Create(ScholarshipDTO _Scholarship)
        {
            try
            {
                   scholarship Scholarship = new scholarship()
                   {
                       Title = _Scholarship.Title,
                       AddUserId = _Scholarship.AddUserId,
                       Description=_Scholarship.Description,
                       ImagPath=_Scholarship.ImagPath,
                       IPAddress=_Scholarship.IPAddress,
                       TitleInEnglish=_Scholarship.TitleInEnglish,
                       
                    };
                    _repository.Add(Scholarship);

                    return _unitOfWork.SaveChanges();
                
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ScholarshipDTO> GetAll()
        {
            try
            {
                IEnumerable<ScholarshipDTO> query = _repository.Get().OrderByDescending(field=>field.Id).Select(item => new ScholarshipDTO()
                {
                    Id = item.Id,
                    AddedDate=item.AddedDate, 
                    AddUserId=item.AddUserId,
                    Description=item.Description,
                    ImagPath=item.ImagPath,
                    IPAddress=item.IPAddress,
                    ModifiedDate=item.ModifiedDate,
                    ModifyUserId=item.ModifyUserId,
                    Title=item.Title,
                    TitleInEnglish=item.TitleInEnglish,

                });
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ScholarshipDTO GetById(int id)
        {
            try
            {
                var Scholarship = _repository.Get(id);


                ScholarshipDTO query = Scholarship != null ? new ScholarshipDTO()
                {
                    Id = Scholarship.Id,
                    IPAddress=Scholarship.IPAddress,
                    ImagPath=Scholarship.ImagPath,
                    Description=Scholarship.Description,
                    AddUserId=Scholarship.AddUserId,
                    Title=Scholarship.Title,
                    AddedDate=Scholarship.AddedDate,
                    ModifiedDate=Scholarship.ModifiedDate,
                    ModifyUserId= Scholarship.ModifyUserId,

                } : null;
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ScholarshipDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
