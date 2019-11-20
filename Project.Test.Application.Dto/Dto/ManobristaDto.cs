using Project.Test.CrossCutting.Entity;
using System;

namespace Project.Test.Application.Dto.Dto
{
    public class ManobristaDto : BaseEntity
    {
        public ManobristaDto()
        {

        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
