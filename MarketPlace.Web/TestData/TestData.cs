using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Web.TestData
{
    public class TestData
    {
        public static List<Market> Markets { get; set; }
        public static List<Product> Products { get; set; }
        public static List<ProductsCategory> Categories { get; set; }
        static TestData()
        {
            
            Categories = new List<ProductsCategory>
            {
                new ProductsCategory { Id = "0", Name = "Автомобили" },
                new ProductsCategory { Id = "1", Name = "Электроника" },
                new ProductsCategory { Id = "2", Name = "Самокаты" },
                new ProductsCategory { Id = "3", Name = "Телевизоры" },
                new ProductsCategory { Id = "4", Name = "Спорт" }
            };
            Products = new List<Product>
            {
                new Product { Id = "0", Name = "AUDI 9", Cost = 400000, Description = "Спортивный автомобиль.", Categories = new List<ProductsCategory> { TestData.Categories[0], TestData.Categories[4] } },
                new Product { Id = "1", Name = "Флексокат", Cost = 35000, Description = "Подвороты показывающие заряд прилагаются.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[2] } },
                new Product { Id = "2", Name = "Samsung", Cost = 40000, Description = "Показывает картинки.", Categories = new List<ProductsCategory> { TestData.Categories[3], TestData.Categories[1] } },
                new Product { Id = "3", Name = "Самокат", Cost = 8000, Description = "Спортивный самокат.", Categories = new List<ProductsCategory> { TestData.Categories[4], TestData.Categories[2] } },
                new Product { Id = "4", Name = "FIFA19", Cost = 2999, Description = "Для плойки.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[4] } },
                new Product { Id = "5", Name = "AUDI 9", Cost = 430000, Description = "Спортивный автомобиль.", Categories = new List<ProductsCategory> { TestData.Categories[0], TestData.Categories[4] } },
                new Product { Id = "6", Name = "Флексокат", Cost = 25000, Description = "Подвороты показывающие заряд прилагаются.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[2] } },
                new Product { Id = "7", Name = "Флексокат", Cost = 30000, Description = "Подвороты показывающие заряд прилагаются.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[2] } },
                new Product { Id = "8", Name = "Samsung", Cost = 50000, Description = "Показывает картинки.", Categories = new List<ProductsCategory> { TestData.Categories[3], TestData.Categories[1] } },
                new Product { Id = "9", Name = "Samsung", Cost = 42000, Description = "Показывает картинки.", Categories = new List<ProductsCategory> { TestData.Categories[3], TestData.Categories[1] } },
                new Product { Id = "10", Name = "Самокат", Cost = 6000, Description = "Спортивный самокат.", Categories = new List<ProductsCategory> { TestData.Categories[4], TestData.Categories[2] } },
                new Product { Id = "11", Name = "FIFA19", Cost = 4199, Description = "Для плойки.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[4] } },
                new Product { Id = "12", Name = "FIFA19", Cost = 3499, Description = "Для плойки.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[4] } },
                new Product { Id = "13", Name = "FIFA19", Cost = 3999, Description = "Для плойки.", Categories = new List<ProductsCategory> { TestData.Categories[1], TestData.Categories[4] } },
            };
            Markets = new List<Market>
            {
                new Market { Name = "Эльдорадо" },
                new Market { Name = "Ситилинк" },
                new Market { Name = "Канавто" },
                new Market { Name = "Алик" },
                new Market { Name = "СпортМастер" }
            };
            Markets[0].Products = new List<Product>();
            Markets[1].Products = new List<Product>();
            Markets[2].Products = new List<Product>();
            Markets[3].Products = new List<Product>();
            Markets[4].Products = new List<Product>();
            Markets[0].Categories = new List<ProductsCategory>();
            Markets[1].Categories = new List<ProductsCategory>();
            Markets[2].Categories = new List<ProductsCategory>();
            Markets[3].Categories = new List<ProductsCategory>();
            Markets[4].Categories = new List<ProductsCategory>();

            Markets[0].AddProduct(Products[2]);
            Markets[0].AddProduct(Products[6]);
            Markets[0].AddProduct(Products[11]);
            Markets[1].AddProduct(Products[8]);
            Markets[1].AddProduct(Products[4]);
            Markets[2].AddProduct(Products[1]);
            Markets[2].AddProduct(Products[5]);
            Markets[3].AddProduct(Products[7]);
            Markets[3].AddProduct(Products[9]);
            Markets[3].AddProduct(Products[10]);
            Markets[3].AddProduct(Products[12]);
            Markets[4].AddProduct(Products[0]);
            Markets[4].AddProduct(Products[13]);
            Markets[4].AddProduct(Products[3]);
        }

       
    }
}
