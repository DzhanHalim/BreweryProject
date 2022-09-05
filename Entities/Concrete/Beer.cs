using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Beer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
    }
}
