using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class PurchaseDetail
    {
		[Key]
		public int PurchaseDetailID { get; set; }

		[ForeignKey("Product")]
		public int ProductID { get; set; }

		[ForeignKey("Purchase")]
		public int PurchaseID { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public int PurchasePrice { get; set; }

		[Required]
		public DateTime ManufacturedDate { get; set; }

		[Required]
		public DateTime ExpiryDate { get; set; }

		[Required]
		public string Remarks { get; set; }

		public virtual Product Product { get; set; }

		public virtual Purchase Purchase { get; set; }
	}
}
