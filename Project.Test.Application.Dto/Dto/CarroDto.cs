using Project.Test.CrossCutting.Entity;

namespace Project.Test.Application.Dto.Dto
{
    public class CarroDto : BaseEntity
    {
        public CarroDto()
        {

        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
    }
}