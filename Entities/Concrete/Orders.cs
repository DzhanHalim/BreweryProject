using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Orders : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WholesalerId { get; set; }
        public int Quantity { get; set; }
        public int BeerId { get; set; }
        public string Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
