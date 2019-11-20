using Project.Test.CrossCutting.Entity;
using System;
using System.Collections.Generic;

namespace Project.Test.Application.Service.Interface
{
    public interface IBaseAppService<T> where T : BaseEntity
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(T obj);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}