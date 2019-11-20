using Project.Test.CrossCutting.Entity;
using System;
using System.Collections.Generic;

namespace Project.Test.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(T obj);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}