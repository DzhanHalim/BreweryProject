using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class Quote : IDTO
    {
        public int WholesalerId { get; set; }
        public string WholesalerName { get; set; }
        public int BeerInStock { get; set; }
        public decimal Price { get; set; }
        public string AlcoholContent { get; set; }
        public string BeerName { get; set; }
    }
}
