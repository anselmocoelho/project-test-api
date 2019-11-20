using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Test.Application.Dto;
using Project.Test.Application.Dto.Dto;
using Project.Test.Application.Service.Interface;

namespace Project.Test.Api.Controllers
{
    [Route("api/manobras")]
    [ApiController]
    public class ManobraController : ControllerBase
    {
        private readonly IManobraAppService _appService;

        public ManobraController(IManobraAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public ServiceResponse<IEnumerable<ManobraDto>> GetAll()
        {
            var retorno = new ServiceResponse<IEnumerable<ManobraDto>> { Result = false };

            try
            {
                retorno.Object = _appService.GetAll();
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        [HttpGet("{id}")]
        public ServiceResponse<ManobraDto> Get(Guid id)
        {
            var retorno = new ServiceResponse<ManobraDto> { Result = false };

            try
            {
                retorno.Object = _appService.Get(id);
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        [HttpPost]
        public ServiceResponse<bool> Post([FromBody] ManobraDto manobra)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Add(manobra);
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        [HttpPut]
        public ServiceResponse<bool> Put([FromBody] ManobraDto manobra)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Update(manobra);
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        [HttpDelete("{id}")]
        public ServiceResponse<bool> Delete(Guid id)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Delete(new ManobraDto { Id = id });
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }
    }
}