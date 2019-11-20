using Microsoft.EntityFrameworkCore;
using Project.Test.CrossCutting.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Test.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly TestContext _context;

        public BaseRepository(TestContext context)
        {
            _context = context;
        }

        public virtual bool Add(T obj)
        {
            _context.Set<T>().Add(obj);
            return _context.SaveChanges() > 0;
        }

        public virtual bool Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public virtual bool Delete(T obj)
        {
            //_context.Set<T>().Remove(obj);
            //return _context.SaveChanges() > 0;

            return Inactive(obj.Id);
        }

        public virtual T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
               
        public virtual bool Inactive(Guid id)
        {
            var obj = Get(id);
            obj.Active = false;
            return Update(obj);
        }
    }
}

