using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Models
{
    public class Customer
    {
		[Key]
		public int CustomerID { get; set; }

		[Required]
		public string CustomerName { get; set; }

		[Required]
		public string CustomerEmail { get; set; }

		[Required]
		public string CustomerPhoneNo { get; set; }

		[Required]
		public string CustomerAddress { get; set; }

		[Required]
		public int MemberNo { get; set; }

		[Required]
		public string MemberType { get; set; }
	}
}
