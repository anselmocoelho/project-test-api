using Project.Test.CrossCutting.Entity;
using System;

namespace Project.Test.Application.Dto.Dto
{
    public class ManobraDto : BaseEntity
    {
        public ManobraDto()
        {

        }

        public Guid CarroId { get; set; }
        public Guid ManobristaId { get; set; }
        public bool Realizada { get; set; }
    }
}