using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class SalesDetail
    {
		[Key]
		public int SalesDetailID { get; set; }

		[ForeignKey("Product")]
		public int ProductID { get; set; }

		[ForeignKey("Sales")]
		public int SalesID { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public int SellingPrice { get; set; }

		[Required]
		public string Remarks { get; set; }


		public virtual Product Product { get; set; }


		public virtual Sales Sales { get; set; }
	}
}
