using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.ViewModel
{
    public class SalesInfo
    {

        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}
