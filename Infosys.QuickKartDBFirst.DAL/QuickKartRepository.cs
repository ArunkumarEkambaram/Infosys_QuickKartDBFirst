using Infosys.QuickKartDBFirst.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infosys.QuickKartDBFirst.DAL
{
    public class QuickKartRepository : IDisposable
    {
        private readonly QuickKartDBContext _dbContext = null;

        public QuickKartRepository()
        {
            _dbContext = new QuickKartDBContext();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(_dbContext);//Disable finalize or Destructor
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        //Read Categories
        public List<Categories> GetAllCategories()
        {
            var categories = _dbContext.Categories
                            .OrderBy(c => c.CategoryId)//Order by CategoryId
                            .ToList();//Convert to List of Categories
            return categories;
        }

        public List<Products> GetAllProducts()
        {
            return _dbContext.Products
                   .OrderByDescending(p => p.Price)
                   .ToList();
        }

        //FilterProductByCategoryId
        public List<Products> GetProductsByCategoryId(byte categoryId)
        {
            List<Products> products = null;
            try
            {
                products = _dbContext.Products
                            .Where(p => p.CategoryId == categoryId)
                            .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        //Get Product By Product Id
        public Products GetProductById(string productId)
        {
            Products product = null;
            try
            {
                //Method1
                product = _dbContext.Products.Find(productId); //Find method to search based on primary key
                //Method 2
                //product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId); //Returns First row, if not exist returns null
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }

        public List<Products> FilterProductByPattern(string pattern)
        {
            List<Products> products = null;
            try
            {
                products = _dbContext.Products
                           .Where(p => EF.Functions.Like(p.ProductName, pattern))
                           .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        //DML Operation using EF Core
        public bool AddNewCategory(string categoryName)
        {
            bool status = false;
            try
            {
                //Object Initializer
                //Categories cat = new Categories
                //{
                //    CategoryName = categoryName
                //};

                Categories cat = new Categories();
                cat.CategoryName = categoryName;

                _dbContext.Categories.Add(cat);//Adding new row to categories
                _dbContext.SaveChanges();//reflect the changes to the DB
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        //Add New Product
        public bool AddNewProduct(Products product)
        {
            bool status = false;
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.Entry(product).State = EntityState.Added;
                _dbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        //Add new User
        public bool RegisterUser(string userPassword, string gender, string emailId, DateTime dateOfBirth, string address)
        {
            bool status;
            try
            {
                Users users = new Users
                {
                    EmailId = emailId,
                    UserPassword = userPassword,
                    Gender = gender,
                    DateOfBirth = dateOfBirth,
                    Address = address
                };
                _dbContext.Users.Add(users);
                _dbContext.Entry(users).State = EntityState.Added;
                _dbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public bool AddProductUsingAddRange(params Products[] products)
        {
            bool status;
            try
            {
                _dbContext.Products.AddRange(products);//Adding more than one product
                _dbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public bool UpdateProductByProductId(string productId, decimal price, int quantity)
        {
            bool status;
            try
            {
                var productInDb = _dbContext.Products.Find(productId);
                if (productInDb != null)
                {
                    productInDb.Price = price;
                    productInDb.QuantityAvailable = quantity;
                    _dbContext.Products.Update(productInDb);
                    _dbContext.Entry(productInDb).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        //Delete Category By ID
        public bool DeleteCategoryById(byte categoryId)
        {
            bool status;
            try
            {
                var categoryInDb = _dbContext.Categories.Find(categoryId);
                if (categoryInDb != null)
                {
                    _dbContext.Categories.Remove(categoryInDb);
                    _dbContext.Entry(categoryInDb).State = EntityState.Deleted;
                    _dbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public bool DeleteProductByRange(string productName)
        {
            bool status;
            try
            {
                var productsInDb = _dbContext.Products.Where(p => p.ProductName.Contains(productName));
                if (productsInDb != null)
                {
                    _dbContext.Products.RemoveRange(productsInDb);
                    int r = _dbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        //Invoking SQL statement and USP
        public List<Products> GetAllProductsUsingFromSQLRaw(byte categoryId)
        {
            //FromSqlRaw = Works with "Select" statement only
            SqlParameter sqlCategoryId = new SqlParameter("@CategoryId", categoryId);
            return _dbContext.Products.FromSqlRaw("Select * from Products Where CategoryId=@CategoryId", sqlCategoryId)
                                              .OrderBy(p => p.Price)
                                              .ToList();

            //FromSqlInterpolated
            //return _dbContext.Products.FromSqlInterpolated($"Select * from Products Where CategoryId={categoryId}")
            //                                 .OrderBy(p => p.Price)
            //                                 .ToList();

        }       
    }

}
