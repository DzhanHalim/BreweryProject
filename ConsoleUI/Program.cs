using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            OrdersManager ordersManager = new OrdersManager(new EfOrdersDal(),
                new WholesalerStockManager(new EfWholesalerStockDal()), new BeerManager(new EfBeerDal()));

            Orders order = new Orders();
            order.BeerId = 1;
            order.CustomerId = 1;
            order.WholesalerId = 1;
            order.Discount = "";
            order.Quantity = 10;
            ordersManager.Add(order);

            //F1 List all beers by brewery :  
            BeerManager beerManager = new BeerManager(new EfBeerDal());
            var beersByBrewery = beerManager.GetAllByBreweryId(1);
            foreach (var item in beersByBrewery.Data)
            {
                Console.WriteLine(item.Name);


            }
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();

            // FR2- A brewer can add new beer.
            Beer beer1 = new Beer();
            beer1.AlcoholContent = "5";
            beer1.BreweryId = 1;
            beer1.Name = "Beer2";
            beer1.Price = 3;


            beerManager.Add(beer1);
            Beer beerToDelete = new Beer();
            beersByBrewery = beerManager.GetAllByBreweryId(1);
            foreach (var item in beersByBrewery.Data)
            {
                Console.WriteLine(item.Name);
                if (item.Name == "Beer2")
                {
                    beerToDelete = item;

                }
            }

            // FR3- A brewer can delete a beer
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();


            beerManager.Delete(beerToDelete);
            beersByBrewery = beerManager.GetAllByBreweryId(1);
            foreach (var item in beersByBrewery.Data)
            {
                Console.WriteLine(item.Name);


            }




            WholesalerStockManager wholsalerStockManager = new WholesalerStockManager(new EfWholesalerStockDal());

            var wholesaler = wholsalerStockManager.GetById(1);
            wholesaler.Data.BeersInStock = 5;

            wholsalerStockManager.Update(wholesaler.Data);

            Console.ReadLine();

        }
    }
}
