using Infosys.QuickKartDBFirst.DAL.Models;
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

    }

}
