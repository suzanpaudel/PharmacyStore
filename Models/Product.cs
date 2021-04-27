using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class Product
    {
		[Key]
		public int ProductID { get; set; }
		
		[ForeignKey("Category")]
		public int CategoryID { get; set; }

		[Required]
		public string ProductName { get; set; }

		[Required]
		public string Description { get; set; }

		public virtual Category Category { get; set; }
	}
}
