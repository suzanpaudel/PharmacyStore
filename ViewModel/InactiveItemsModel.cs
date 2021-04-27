using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.ViewModel
{
    public class InactiveItemsModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

    }
}
