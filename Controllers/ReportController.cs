using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyStore.Data;
using PharmacyStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyStore.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListStockReport([FromQuery] string name = "")
        {
            List<ProductStockViewModel> lstData = new List<ProductStockViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (name == "")
                {
                    command.CommandText = "SELECT p.ProductId, p.ProductName, ps.StockQuantity from Product p inner join ProductStock ps on p.ProductId=ps.ProductId";
                }
                else
                {
                    command.CommandText = "SELECT p.ProductId, p.ProductName, ps.StockQuantity from Product p inner join ProductStock ps on p.ProductId=ps.ProductId WHERE p.productName = '"+name+"'";
                }
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    ProductStockViewModel data;
                    while (result.Read())
                    {
                        data = new ProductStockViewModel();
                        data.ProductId = result.GetInt32(0);
                        //data.ProductId = int.Parse(result.GetString(0));
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        //data.Quantity = int.Parse(result.GetString(2));
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
        }

        public IActionResult CustomerPurchaseHistoryReport([FromQuery] string name = "")
        {
            List<CustomerPurchaseHistoryViewModel> lstData = new List<CustomerPurchaseHistoryViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (name == "")
                {
                    command.CommandText = "SELECT p.ProductId, p.ProductName, sd.Quantity, sd.SellingPrice from Sales JOIN SalesDetail sd ON Sales.SalesID = sd.SalesID JOIN Product p on p.ProductID = sd.ProductID";
                }
                else
                {
                    command.CommandText = "SELECT p.ProductId, p.ProductName, sd.Quantity, sd.SellingPrice from Sales JOIN SalesDetail sd ON Sales.SalesID = sd.SalesID JOIN Product p on p.ProductID = sd.ProductID where sales.customerID ='"+ name+ "'";

                }
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    CustomerPurchaseHistoryViewModel data;
                    while (result.Read())
                    {
                        data = new CustomerPurchaseHistoryViewModel();
                        data.ProductId = result.GetInt32(0);
                        //data.ProductId = int.Parse(result.GetString(0));
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        //data.Quantity = int.Parse(result.GetString(2));
                        data.SellingPrice = result.GetInt32(3);
                        //data.SellingPrice = int.Parse(result.GetString(2));
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
        }

        //Question No 11
        public IActionResult OutOfStockItemsReport([FromQuery]  string sort="")
        {
            List<ProductStockViewModel> lstData = new List<ProductStockViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (sort == "name" || sort == "")
                {
                    command.CommandText = @"SELECT p.ProductId, p.ProductName, ps.StockQuantity FROM Product p 
                                        INNER JOIN ProductStock ps on p.ProductId=ps.ProductId
                                        WHERE ps.StockQuantity <10 ORDER BY p.ProductName";

                }else if (sort == "quantity")
                {

                
                command.CommandText = @"SELECT p.ProductId, p.ProductName, ps.StockQuantity FROM Product p 
                                        INNER JOIN ProductStock ps on p.ProductId=ps.ProductId
                                        WHERE ps.StockQuantity <10 ORDER BY ps.StockQuantity DESC";
                }

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
        }


        //Question No 12
        public IActionResult InactiveCustomersReport()
        {
            List<InactiveCustomersViewModel> lstData = new List<InactiveCustomersViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT CustomerName, CustomerEmail, CustomerPhoneNo, CustomerAddress from Customer
                                        WHERE CustomerID NOT IN
                                        (SELECT DISTINCT CustomerID FROM Sales 
                                        WHERE SalesDate > GETDATE() -31)";

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    InactiveCustomersViewModel data;
                    while (result.Read())
                    {
                        data = new InactiveCustomersViewModel();
                        data.CustomerName = result.GetString(0);
                        data.CustomerEmail = result.GetString(1);
                        data.CustomerPhone = result.GetString(2);
                        data.CustomerAddress = result.GetString(3);
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
        }

        //Question No 13
        public IActionResult InactiveItemsReport()
        {
            List<InactiveItemsModel> lstData = new List<InactiveItemsModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT p.ProductName, p.Description, ps.StockQuantity from ProductStock ps
                                        JOIN product p ON p.ProductID = ps.ProductID
                                        WHERE ps.StockQuantity >=10 AND p.ProductID NOT IN 
                                        (SELECT DISTINCT sd.ProductID from Sales s
                                        JOIN SalesDetail sd on sd.SalesID = s.SalesID
                                        WHERE s.SalesDate > GETDATE() - 31)
                                        ";
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    InactiveItemsModel data;
                    while (result.Read())
                    {
                        data = new InactiveItemsModel();
                        data.ProductName = result.GetString(0);
                        data.Description = result.GetString(1);
                        data.StockQuantity = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
        }

        //public IActionResult NotSoldReport()
        //{
        //    List<NotSoldItemViewModel> lstData = new List<NotSoldItemViewModel>();

        //    using (var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        select product.productName
        //                from productStock PS
        //                join product on
        //                product.ProductID = PS.productID
        //                where PS.stockQuantity >= 10 and product.ProductId not in 
        //                (select distinct SD.productID
        //                from sales
        //                join SalesDetail SD on
        //                SD.salesID = sales.SalesID
        //                where sales.salesDate > sysdate - 31)
        //        command.CommandText = @"SELECT p.ProductName, p.Description, ps.StockQuantity
        //                                FROM ProductStock ps
        //                                JOIN Product p on p.ProductID = ps.ProductID
        //                                WHERE ps.StockQuantity >= 10 AND p.ProductID NOT IN
        //                                (SELECT DISTINCT sd.ProductID FROM Sales s
        //                                JOIN SalesDetail sd on sd.SalesID = s.SalesID
        //                                WHERE s.salesDate
        //                                )

        //                                ";
        //        command.CommandText = "SELECT p.ProductId, p.ProductName, ps.StockQuantity from Product p inner join ProductStock ps on p.ProductId=ps.ProductId";
        //        _context.Database.OpenConnection();

        //        using (var result = command.ExecuteReader())
        //        {
        //            ProductStockViewModel data;
        //            while (result.Read())
        //            {
        //                data = new ProductStockViewModel();
        //                data.ProductId = result.GetInt32(0);
        //                //data.ProductId = int.Parse(result.GetString(0));
        //                data.ProductName = result.GetString(1);
        //                data.Quantity = result.GetInt32(2);
        //                //data.Quantity = int.Parse(result.GetString(2));
        //                lstData.Add(data);
        //            }
        //        }
        //    }

        //    return View(lstData.OrderBy(x => x.ProductName));
        //}
        //.OrderBy(x=>x.ProductName)
    }
}
