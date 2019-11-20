using FluentValidation;
using Project.Test.CrossCutting.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace Project.Test.Domain.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual bool Add<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            return _repository.Add(obj);
        }

        public virtual bool Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            return _repository.Update(obj);
        }

        public virtual bool Delete(T obj)
        {
            return _repository.Delete(obj);
        }

        public virtual T Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}