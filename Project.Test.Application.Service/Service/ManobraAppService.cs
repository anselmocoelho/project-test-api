using AutoMapper;
using Project.Test.Application.Dto.Dto;
using Project.Test.Application.Service.Interface;
using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Service;
using Project.Test.Domain.Validation;

namespace Project.Test.Application.Service.Service
{
    public class ManobraAppService : BaseAppService<ManobraDto, Manobra, ManobraValidation>, IManobraAppService
    {
        private readonly IManobraService _service;
        private readonly IMapper _mapper;

        public ManobraAppService(IManobraService service, IMapper mapper)
            : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }
    }
}