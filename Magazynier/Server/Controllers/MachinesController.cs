using System;
using System.Collections.Generic;
using Magazynier.Shared;
using Magazynier.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MagazynierApp.Server.Controllers
{
    [Route("machines")]
    [ApiController]
    public class MachinesController: Controller
    {

        public static Machine[] ListOfMachines = { 
            new Machine
            {
                Id = 1,
                Name = "D1080",
                Localization = "Brembo",
                Capacity = 500,
                ImageUrl = "img/machines/D1080.png",
                ProductsList = Product.ListOfProductsType1_500
            },
            new Machine
            {
                Id = 2,
                Name = "D540",
                Localization = "KGHM",
                Capacity = 600,
                ImageUrl = "img/machines/D540.png",
                ProductsList = Product.ListOfProductsTypeEmpty_500
            },
            new Machine
            {
                Id = 3,
                Name = "F80",
                Localization = "Ekookna",
                Capacity = 500,
                ImageUrl = "img/machines/F80.png",
                ProductsList = Product.ListOfProductsTypeFull_500
            },
            new Machine
            {
                Id = 4,
                Name = "L40",
                Localization = "Tenneco",
                Capacity = 800,
                ImageUrl = "img/machines/L40.png",
                ProductsList = Product.ListOfProductsType1_500
            },
            new Machine
            {
                Id = 5,
                Name = "D1080",
                Localization = "Tenneco",
                Capacity = 1000,
                ImageUrl = "img/machines/D1080.png",
                ProductsList = Product.ListOfProductsType1_500
            },
            new Machine
            {
                Id = 6,
                Name = "F80",
                Localization = "Ekookna",
                Capacity = 550,
                ImageUrl = "img/machines/F80.png",
                ProductsList = Product.ListOfProductsType1_500
            },
            
        };
        
        [HttpGet]
        public IEnumerable<Machine> Get()
        {
            Console.WriteLine("Try to get machines");
            return ListOfMachines;
        }

        [HttpPut]
        public void UpdateMachines(Machine machine)
        {
            ListOfMachines[machine.Id-1] = machine;
        }
    }
}
