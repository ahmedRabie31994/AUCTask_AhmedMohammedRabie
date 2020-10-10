using AUCTechnicalTask_AhmedMohammedRabie.BL.Interfaces;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Repository
{
    public class GenericUnitOfWork
    {
        private AppDbContext _dbcontext;
        public Type TheType { get; set; }

        public GenericUnitOfWork()
        {
            _dbcontext = new AppDbContext();
        }
        public IGenericRepository<TEntityType> GetRepoInstance<TEntityType>() where TEntityType : class
        {
            return new GenericRepository<TEntityType>(_dbcontext);
        }
        public bool SaveChanges()
        {
            try
            {
                if (_dbcontext.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
