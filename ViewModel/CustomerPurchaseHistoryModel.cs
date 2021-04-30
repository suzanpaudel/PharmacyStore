using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.ViewModel
{
    public class CustomerPurchaseHistoryViewModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int SellingPrice { get; set; }

    }
}
