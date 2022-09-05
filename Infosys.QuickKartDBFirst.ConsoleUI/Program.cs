using Infosys.QuickKartDBFirst.DAL;
using Infosys.QuickKartDBFirst.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infosys.QuickKartDBFirst.ConsoleUI
{

    class Program
    {
        public static void ChangeTracking(IEnumerable<EntityEntry> entities)
        {
            Console.WriteLine($"{"Entity Name",-15}\t{"Entity State"}");
            Console.WriteLine("----------------------------------------");
            foreach (var item in entities)
            {
                Console.WriteLine($"{item.Entity.GetType().Name,-15}\t{item.State}");
            }
        }


        static void Main(string[] args)
        {
            #region Change Tracking

            //// var context = new QuickKartDBContext();
            //using (var context = new QuickKartDBContext())
            //{
            //    //var catergory = context.Categories.OrderBy(c => c.CategoryId).First();
            //    //Console.WriteLine($"State :{context.Entry(catergory).State}");
            //    //Console.WriteLine("------------------------------------");
            //    //Categories c1 = new Categories
            //    //{
            //    //    CategoryName = "Baby"
            //    //};
            //    //Console.WriteLine($"State :{context.Entry(c1).State}");
            //    //context.Categories.Add(c1);
            //    //Console.WriteLine($"State :{context.Entry(c1).State}");
            //    //Console.WriteLine("------------------------------------");
            //    ////Update
            //    //Console.WriteLine("Performing Update Operation");
            //    //byte id = 1;
            //    //var updCategory = context.Categories.Find(id);
            //    //updCategory.CategoryName = "Baby & Toys";
            //    //context.Categories.Update(updCategory);
            //    //Console.WriteLine($"State :{context.Entry(updCategory).State}");
            //    ////Delete
            //    //Console.WriteLine("------------------------------------");
            //    //Console.WriteLine("Performing Delete Operation");
            //    //var delCategory = context.Categories.Find(id);
            //    //context.Categories.Remove(delCategory);
            //    //Console.WriteLine($"State :{context.Entry(delCategory).State}");

            //    Console.WriteLine("------------------------------------");
            //    //Calling Change Tracking
            //    context.Categories.ToList();
            //    Roles r1 = new Roles
            //    {
            //        RoleName = "Executive"
            //    };
            //    context.Roles.Add(r1);
            //    var product = context.Products.Find("P101");
            //    context.Products.Remove(product);
            //    Program.ChangeTracking(context.ChangeTracker.Entries());
            //}

            #endregion

            using (var repository = new QuickKartRepository())
            {
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

                //var product = repository.GetProductById("P500");
                //if (product != null)
                //{
                //    Console.WriteLine($"Product ID :{product.ProductId}\nProduct Name :{product.ProductName}\nPrice :{product.Price}\nQuantity Available :{product.QuantityAvailable}");
                //}
                //else
                //{
                //    Console.WriteLine("No Product");
                //}

                #endregion

                #region Filter Product By Pattern

                //Console.Write("Enter Pattern to search product name :");
                //string pattern = Console.ReadLine();
                //var products = repository.FilterProductByPattern(pattern);

                //if (products.Count > 0)
                //{
                //    Console.WriteLine($"{"Product Id",-10}\t{"Product Name",-50}\t{"Category Id",-10}\t{"Price"}");
                //    Console.WriteLine("---------------------------------------------------------------------------------------------");
                //    foreach (var prd in products)
                //    {
                //        Console.WriteLine($"{prd.ProductId,-10}\t{prd.ProductName,-50}\t{prd.CategoryId,-10}\t{prd.Price}");
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("No Record found.");
                //}

                #endregion

                #region Add New Category

                //try
                //{
                //    Console.Write("Enter a Category :");
                //    string categoryName = Console.ReadLine();
                //    var result = repository.AddNewCategory(categoryName);
                //    if (result)
                //    {
                //        Console.WriteLine("New Category Created Successfully");
                //    }
                //}
                //catch//(Exception)
                //{
                //    Console.WriteLine("Please enter different Category Name");
                //}
                //finally
                //{
                //    repository.Dispose();
                //}

                #endregion

                #region Add New Product

                //try
                //{
                //    Products products = new Products
                //    {
                //        ProductId = "P158",
                //        ProductName = "Dell Laptop",
                //        Price = 75800.89M,
                //        QuantityAvailable = 13,
                //        CategoryId = 3
                //    };
                //    var result = repository.AddNewProduct(products);
                //    if (result)
                //    {
                //        Console.WriteLine("Product Added Successfully");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.InnerException.Message);
                //}
                //finally
                //{
                //    if (repository != null)
                //    {
                //        repository.Dispose();
                //    }
                //}
                #endregion

                #region Add Range of Products

                //Products p1 = new Products
                //{
                //    ProductId = "P159",
                //    ProductName = "Wall Clock",
                //    Price = 1050,
                //    QuantityAvailable = 120,
                //    CategoryId = 5
                //};

                //Products p2 = new Products
                //{
                //    ProductId = "P160",
                //    ProductName = "Table Fan",
                //    Price = 2550,
                //    QuantityAvailable = 12,
                //    CategoryId = 5
                //};

                //var result = repository.AddProductUsingAddRange(p1, p2);
                //if (result)
                //{
                //    Console.WriteLine("Products added successfully");
                //}

                #endregion

                #region Update Product

                //string productId = "P161";
                //decimal price = 2850;
                //int quantity = 100;
                //var result = repository.UpdateProductByProductId(productId, price, quantity);
                //if (result)
                //{
                //    Console.WriteLine("Product Updated Successfully");
                //}
                //else
                //{
                //    Console.WriteLine("Product Id doesn't exists");
                //}

                #endregion

                #region Delete Category

                //byte categoryId = 17;
                //var result = repository.DeleteCategoryById(categoryId);
                //if (result)
                //{
                //    Console.WriteLine("Category Deleted Successfully");
                //}
                //else
                //{
                //    Console.WriteLine("Invalid Category Id");
                //}

                #endregion

                #region Delete Range of Products

                //var result = repository.DeleteProductByRange("BMW");
                //if (result)
                //{
                //    Console.WriteLine("Delete Range of Product contains 'paint'");
                //}
                //else
                //{
                //    Console.WriteLine("Please provide valid product name pattern");
                //}

                #endregion

                #region GetAllProductsUsingFromSQLRaw

                byte id = 3;
                var products = repository.GetAllProductsUsingFromSQLRaw(id);

                Console.WriteLine($"{"Product Name",-40}\t{"Price",-10}\t{"Category Id"}");
                Console.WriteLine("-----------------------------------------------------------------------");
                foreach (var prd in products)
                {
                    Console.WriteLine($"{prd.ProductName,-40}\t{prd.Price,-10}\t{prd.CategoryId}");
                }

                #endregion

            }
            //Calling Dispose - always call this method at the end of the program
            //repository.Dispose();
        }
    }
}
