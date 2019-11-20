using Project.Test.CrossCutting.Entity;
using System;

namespace Project.Test.Domain.Entity
{
    public class Manobra : BaseEntity
    {
        public Guid CarroId { get; set; }
        public Guid ManobristaId { get; set; }
        public bool Realizada { get; set; }
        public virtual Carro Carro { get; set; }
        public virtual Manobrista Manobrista { get; set; }
    }
}