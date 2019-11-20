using Project.Test.CrossCutting.Entity;
using System;
using System.Collections.Generic;

namespace Project.Test.Domain.Entity
{
    public class Manobrista : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual IEnumerable<Manobra> Manobras { get; set; }
    }
}