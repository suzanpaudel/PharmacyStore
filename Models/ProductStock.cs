using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class ProductStock
    {
		[Key]
		public int ProductStockID { get; set; }
		
		[ForeignKey("Product")]
		public int ProductID { get; set; }

		[Required]
		public int StockQuantity { get; set; }

		public virtual Product Product { get; set; }
	}
}
