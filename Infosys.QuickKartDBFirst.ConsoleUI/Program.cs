using Infosys.QuickKartDBFirst.DAL;
using System;
using System.Collections.Generic;

namespace Infosys.QuickKartDBFirst.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickKartRepository repository = new QuickKartRepository();

            #region Get All Categories

            //var categories = repository.GetAllCategories();

            //Console.WriteLine($"{"Category ID",-10}\t{"Category Name"}");
            //Console.WriteLine("-----------------------------------------------");
            //foreach (var cat in categories)
            //{
            //    Console.WriteLine($"{cat.CategoryId,-10}\t{cat.CategoryName}");
            //}

            #endregion

            #region Get All Products

            //var products = repository.GetAllProducts();
            //Console.WriteLine($"{"Product Id",-10}\t{"Product Name",-50}\t{"Category Id",-10}\t{"Price"}");
            //Console.WriteLine("---------------------------------------------------------------------------------------------");
            //foreach (var prd in products)
            //{
            //    Console.WriteLine($"{prd.ProductId,-10}\t{prd.ProductName,-50}\t{prd.CategoryId,-10}\t{prd.Price}");
            //}

            #endregion

            #region Get Product By Category Id

            //try
            //{
            //    Console.Write("Enter Category Id :");
            //    byte categoryId = Convert.ToByte(Console.ReadLine());
            //    var products = repository.GetProductsByCategoryId(categoryId);
            //    if (products.Count > 0)
            //    {
            //        Console.WriteLine($"{"Product Id",-10}\t{"Product Name",-50}\t{"Category Id",-10}\t{"Price"}");
            //        Console.WriteLine("---------------------------------------------------------------------------------------------");
            //        foreach (var prd in products)
            //        {
            //            Console.WriteLine($"{prd.ProductId,-10}\t{prd.ProductName,-50}\t{prd.CategoryId,-10}\t{prd.Price}");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No Record found for the given category id");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if (repository != null)
            //    {
            //        repository.Dispose();
            //    }
            //}

            #endregion

            #region Get a Product by Product ID

            var product = repository.GetProductById("P500");
            if (product != null)
            {
                Console.WriteLine($"Product ID :{product.ProductId}\nProduct Name :{product.ProductName}\nPrice :{product.Price}\nQuantity Available :{product.QuantityAvailable}");
            }
            else
            {
                Console.WriteLine("No Product");
            }

            #endregion

            //Calling Dispose - always call this method at the end of the program
            repository.Dispose();
        }
    }
}
