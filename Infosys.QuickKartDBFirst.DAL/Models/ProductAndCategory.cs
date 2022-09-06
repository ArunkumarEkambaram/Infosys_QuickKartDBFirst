using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infosys.QuickKartDBFirst.DAL.Models
{
    public class ProductAndCategory
    {
        //Data Annotation - Compiler Instruction
        [Key]//Apply Primark Key for ProductId
        public string ProductId { get; set; }
        public string ProductName { get; set; }        
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public string CategoryName { get; set; }
    }
}
