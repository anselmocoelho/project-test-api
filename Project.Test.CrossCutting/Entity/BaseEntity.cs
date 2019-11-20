using System;

namespace Project.Test.CrossCutting.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}