using Infosys.QuickKartDBFirst.DAL.Models;
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
    }

}
