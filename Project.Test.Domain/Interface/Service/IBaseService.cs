using FluentValidation;
using Project.Test.CrossCutting.Entity;
using System;
using System.Collections.Generic;

namespace Project.Test.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        bool Add<V>(T obj) where V : AbstractValidator<T>;
        bool Update<V>(T obj) where V : AbstractValidator<T>;
        bool Delete(T obj);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}