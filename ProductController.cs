﻿using C_sharp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp
{
    internal class ProductController
    {
        ProductDBContext dbContext;
        public ProductController()
        {
            var productDbOptions = new DbContextOptionsBuilder<ProductDBContext>()
                .UseSqlServer("Data Source=DESKTOP-71IL0V1\\SEVERDUNG;Initial Catalog=Demo;User ID=sa;Password=040620;Encrypt=False")
                .Options;
            this.dbContext = new ProductDBContext(productDbOptions);
        }
        public void CreateNewProduct()
        {
            Console.Write("Name : ");
            string? name = Console.ReadLine();
            Console.Write("Product ID : ");
            string? desccribe = Console.ReadLine();
         
            Console.Write("Price : ");
           int price = Convert.ToInt32(Console.ReadLine());


            var product = new Product
            {
                Name = name,
                ProductID = desccribe,
                Price = price

            };

            try
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetAllProducts()
        {
            var products = dbContext.Products.ToList();
            foreach (var item in products)
            {
                Console.WriteLine($" ProductID:{item.ProductID}  Name:{item.Name}  Price:{item.Price}");
            }
        }

        public void DeleteProduct(int id)
        {

            Product deleteProduct = (Product)dbContext.Products.Where(p => p.Id == id)
                                         .Single();

            try
            {
                dbContext.Products.Remove(deleteProduct);
                dbContext.SaveChanges();
                Console.WriteLine("Delete success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
