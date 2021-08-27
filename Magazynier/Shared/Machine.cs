using System.Collections.Generic;
using System.Linq;

namespace Magazynier.Shared
{
    public class Machine
    {
        public const int MaxCapacity = 1080;
        public const int MinCapacity = 100;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsAlmostEmpty=>_productsList.Any(product => product.NeedToRefill);
        public bool IsFull=>_productsList.All(product => product.IsFull);

        int _capacity;
        public int Capacity
        {
            get => _capacity;
            set
            {
                if(value<MinCapacity)
                    _capacity = MinCapacity;
                else if (value > MaxCapacity)
                    _capacity = MaxCapacity;
                else
                    _capacity = value;
            }
        }
        
        private List<Product> _productsList = new List<Product>(MaxCapacity);
        public List<Product> ProductsList
        {
            get => _productsList;
            set
            {
                if (CalculateAmount(value) > _capacity)
                {
                    value = new List<Product>();
                }
                else
                    _productsList = value;
            }
        }
        public int CurrentNumberOfProducts => CalculateAmount(ProductsList);

        public List<Product> ProductsToRefill
        {
            get
            {
                var productsToRefill = new List<Product>();
                foreach (var product in ProductsList)
                {
                    if(product.NeedToRefill)
                        productsToRefill.Add(product);
                }
                return productsToRefill;
            }
        }

        static int CalculateAmount(IEnumerable<Product> products) => products.Sum(product => product.Quantity);
        
    }
}
