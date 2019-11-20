using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Test.Application.Dto;
using Project.Test.Application.Dto.Dto;
using Project.Test.Application.Service.Interface;

namespace Project.Test.Api.Controllers
{
    [Route("api/carros")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroAppService _appService;

        public CarroController(ICarroAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public ServiceResponse<IEnumerable<CarroDto>> Get()
        {
            var retorno = new ServiceResponse<IEnumerable<CarroDto>> { Result = false };

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
        public ServiceResponse<CarroDto> Get(Guid id)
        {
            var retorno = new ServiceResponse<CarroDto> { Result = false };

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
        public ServiceResponse<bool> Post([FromBody] CarroDto carro)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Add(carro);
                retorno.Result = true;
            }
            catch (Exception ex)
            {
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        [HttpPut]
        public ServiceResponse<bool> Put([FromBody] CarroDto carro)
        {
            var retorno = new ServiceResponse<bool> { Result = false };

            try
            {
                _appService.Update(carro);
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
                _appService.Delete(new CarroDto { Id = id });
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