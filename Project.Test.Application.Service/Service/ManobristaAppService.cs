using AutoMapper;
using Project.Test.Application.Dto.Dto;
using Project.Test.Application.Service.Interface;
using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Service;
using Project.Test.Domain.Validation;

namespace Project.Test.Application.Service.Service
{
    public class ManobristaAppService : BaseAppService<ManobristaDto, Manobrista, ManobristaValidation>, IManobristaAppService
    {
        private readonly IManobristaService _service;
        private readonly IMapper _mapper;

        public ManobristaAppService(IManobristaService service, IMapper mapper)
            : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }
    }
}