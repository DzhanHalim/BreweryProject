using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Wholesaler : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
