using Project.Test.CrossCutting.Entity;
using System.Collections.Generic;

namespace Project.Test.Domain.Entity
{
    public class Carro : BaseEntity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public virtual IEnumerable<Manobra> Manobras { get; set; }
    }
}