using System;
using System.Collections.Generic;
using System.Text;

namespace Infosys.QuickKartDBFirst.DAL.Models
{
    public class ProductWithTax
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
