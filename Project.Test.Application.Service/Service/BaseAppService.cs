using AutoMapper;
using FluentValidation;
using Project.Test.Application.Service.Interface;
using Project.Test.CrossCutting.Entity;
using Project.Test.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace Project.Test.Application.Service.Service
{
    public class BaseAppService<Dto, T, V> : IBaseAppService<Dto>
        where Dto : BaseEntity
        where T : BaseEntity
        where V : AbstractValidator<T>
    {
        private readonly IBaseService<T> _service;
        private readonly IMapper _mapper;

        public BaseAppService(IBaseService<T> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public bool Add(Dto obj)
        {
            var entity = _mapper.Map<T>(obj);
            return _service.Add<V>(entity);
        }
        public bool Update(Dto obj)
        {
            var entity = _mapper.Map<T>(obj);
            return _service.Update<V>(entity);
        }
        public bool Delete(Dto obj)
        {
            var entity = _mapper.Map<T>(obj);
            return _service.Delete(entity);
        }
        public Dto Get(Guid id)
        {
            return _mapper.Map<Dto>(_service.Get(id));
        }
        public IEnumerable<Dto> GetAll()
        {
            return _mapper.Map<IEnumerable<Dto>>(_service.GetAll());
        }
    }
}