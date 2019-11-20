using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Test.Application.Dto;
using Project.Test.Application.Dto.Dto;
using Project.Test.Application.Service.Interface;

namespace Project.Test.Api.Controllers
{
    [Route("api/manobristas")]
    [ApiController]
    public class ManobristaController : ControllerBase
    {
        private readonly IManobristaAppService _appService;

        public ManobristaController(IManobristaAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public ServiceResponse<IEnumerable<ManobristaDto>> GetAll()
        {
            var retorno = new ServiceResponse<IEnumerable<ManobristaDto>> { Result = false };

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
        public ServiceResponse<ManobristaDto> Get(Guid id)
        {
            var retorno = new ServiceResponse<ManobristaDto> { Result = false };

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
        public ServiceResponse<bool> Post([FromBody] ManobristaDto manobrista)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Add(manobrista);
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        [HttpPut]
        public ServiceResponse<bool> Put([FromBody] ManobristaDto manobrista)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Update(manobrista);
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
                _appService.Delete(new ManobristaDto { Id = id });
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