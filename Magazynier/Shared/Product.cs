using System.Collections.Generic;

namespace Magazynier.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int MaxQuantity { get; set; }
        public int MinQuantity { get; set; }

        public bool NeedToRefill => Quantity <= (MinQuantity);
        public bool IsFull => Quantity== MaxQuantity;


        public static List<Product> ListOfProductsType1_500 = new List<Product>
        {
            new Product(){Name = "Środki Ochrony pracy",Quantity = 100, MaxQuantity = 100, ImageUrl = "img/products/srodki-ochrony-pracy.jpg"},
            new Product(){Name = "Artykuły Ścierne i tnące",Quantity = 180,MaxQuantity = 200,ImageUrl = "img/products/artykuly-scierne-i-tnace.jpg"},
            new Product(){Name = "Chemia Techniczna",Quantity = 40,MaxQuantity = 150,ImageUrl = "img/products/chemia-techniczna.jpg"},
            new Product(){Name = "Artykuły biurowe",Quantity = 30, MaxQuantity = 50,ImageUrl = "img/products/artykuly-biurowe.jpg"},
        };
        public static List<Product> ListOfProductsTypeEmpty_500 = new List<Product>
        {
            new Product(){Name = "Środki Ochrony pracy",Quantity = 70, MaxQuantity = 100, ImageUrl = "img/products/srodki-ochrony-pracy.jpg"},
            new Product(){Name = "Artykuły Ścierne i tnące",Quantity = 50,MaxQuantity = 200,ImageUrl = "img/products/artykuly-scierne-i-tnace.jpg"},
            new Product(){Name = "Chemia Techniczna",Quantity = 90,MaxQuantity = 150,ImageUrl = "img/products/chemia-techniczna.jpg"},
            new Product(){Name = "Artykuły biurowe",MinQuantity = 5,Quantity = 3, MaxQuantity = 50,ImageUrl = "img/products/artykuly-biurowe.jpg"},
        };
        public static List<Product> ListOfProductsTypeFull_500 = new List<Product>
        {
            new Product(){Name = "Środki Ochrony pracy",Quantity = 100, MaxQuantity = 100, ImageUrl = "img/products/srodki-ochrony-pracy.jpg"},
            new Product(){Name = "Artykuły Ścierne i tnące",Quantity = 200,MaxQuantity = 200,ImageUrl = "img/products/artykuly-scierne-i-tnace.jpg"},
            new Product(){Name = "Chemia Techniczna",Quantity = 150,MaxQuantity = 150,ImageUrl = "img/products/chemia-techniczna.jpg"},
            new Product(){Name = "Artykuły biurowe",Quantity = 50, MaxQuantity = 50,ImageUrl = "img/products/artykuly-biurowe.jpg"},
        };
    }
}
