using AUCTechnicalTask_AhmedMohammedRabie.BL.Interfaces;
using AUCTechnicalTask_AhmedMohammedRabie.DL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AUCTechnicalTask_AhmedMohammedRabie.BL.Repository
{
    class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class
    {
        DbSet<Tentity> _dbset;
        private AppDbContext _dbContext;
        public GenericRepository(AppDbContext context)
        {
            _dbContext = context;
            _dbset = _dbContext.Set<Tentity>();

        }
        public void Add(Tentity Entity)
        {
            _dbset.Add(Entity);
        }
        public Tentity Create(Tentity Entity)
        {
            _dbset.Add(Entity);
            return Entity;
        }

        public void Delete(int Id)
        {
            var entity = _dbset.Find(Id);
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbset.Attach(entity);
            _dbset.Remove(entity);
        }

        public IEnumerable<Tentity> Get()
        {
            IEnumerable<Tentity> query = _dbset;
            return query.ToList();
        }

        public IEnumerable<Tentity> Get(int PageSize, int CurrentPage, out int Count)
        {
            IEnumerable<Tentity> query = _dbset;
            Count = query.Count();
            return query.Skip((PageSize * CurrentPage) - PageSize).Take(PageSize).ToList();

        }

        public Tentity Get(int Id)
        {
            return _dbset.Find(Id);
        }

        public IQueryable<Tentity> GetFiltered(Expression<Func<Tentity, bool>> Where)
        {
            return _dbset.Where(Where);
        }

        public void Update(Tentity Entity)
        {
            _dbset.Attach(Entity);
            _dbContext.Entry(Entity).State = EntityState.Modified;
        }
    }
}
