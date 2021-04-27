using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class Sales
    {
		[Key]
		public int SalesID { get; set; }

		[ForeignKey("Customer")]
		public int CustomerID { get; set; }

		[Required]
		public DateTime SalesDate { get; set; }

		[Required]
		public string SalesBillNo { get; set; }

		[Required]
		public string SalesTotalAmount { get; set; }


		public virtual Customer Customer { get; set; }
	}
}
