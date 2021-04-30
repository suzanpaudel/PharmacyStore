using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PharmacyStore.Data;
using PharmacyStore.Models;
using PharmacyStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductStockViewModel> lstData = new List<ProductStockViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
            
                    command.CommandText = @"SELECT p.ProductId, p.ProductName, ps.StockQuantity FROM Product p 
                                        INNER JOIN ProductStock ps on p.ProductId=ps.ProductId
                                        WHERE ps.StockQuantity <10 ORDER BY p.ProductName";


                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    ProductStockViewModel data;
                    while (result.Read())
                    {
                        data = new ProductStockViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
            //OutofStockItemsViewModel model = new OutofStockItemsViewModel();
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
