using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueBookCase.DomainModel
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
