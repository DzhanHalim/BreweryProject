using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WholesalerStock : IEntity
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int BeersInStock { get; set; }


    }
}
