using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class Purchase
    {
		[Key]
		public int PurchaseID { get; set; }

		[Required]
		public DateTime PurchaseDate { get; set; }

		[Required]
		public int PurchaseBillNo { get; set; }

		[Required]
		public string VendorName { get; set; }

		[Required]
		public int PurchaseTotalAmount { get; set; }

	}
}
