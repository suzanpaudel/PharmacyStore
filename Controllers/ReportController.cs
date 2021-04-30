using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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



        public IActionResult SalesEntryForm()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerName");

            return View();
        }

        public IActionResult BillingReport([FromQuery] int CustomerID, int ProductID, int Quantity, int SellingPrice)
        {
            List<SalesInfo> lstData = new List<SalesInfo>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT p.ProductId,  p.ProductName, p.Description, c.CategoryName from Product p JOIN Category c ON c.CategoryID = p.CategoryID where ProductId =" + ProductID;
            
                _context.Database.OpenConnection();
                
                SalesInfo data;

                data = new SalesInfo();

                data.Quantity = Quantity;
                data.Price = SellingPrice;

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        data.ProductID = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.Description = result.GetString(2);
                        data.CategoryName = result.GetString(3);
                        lstData.Add(data);
                    }
                }

                command.CommandText = "SELECT CustomerId, CustomerName, CustomerEmail from Customer where CustomerId =" + CustomerID;

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        data.CustomerID = result.GetInt32(0);
                        data.CustomerName = result.GetString(1);
                        data.Email = result.GetString(2);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData[0]);
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

        public IActionResult CustomerPurchaseHistoryReport([FromQuery] string CustomerId = "")
        {
            List<CustomerPurchaseHistoryViewModel> lstData = new List<CustomerPurchaseHistoryViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (CustomerId == "")
                {


                    command.CommandText = @"SELECT c.MemberNo, c.CustomerName, p.ProductName, sd.Quantity, sd.SellingPrice
                                            FROM Sales s
                                            JOIN SalesDetail sd ON s.SalesID = sd.SalesID
                                            JOIN Product p ON p.ProductID = sd.ProductID
                                            JOIN Customer c ON c.CustomerID = s.CustomerID
                                            WHERE s.SalesDate > GETDATE() - 31";
                }
                else
                {
                    var id = int.Parse(CustomerId);
                    command.CommandText = @"SELECT c.MemberNo, c.CustomerName, p.ProductName, sd.Quantity, sd.SellingPrice
                                            FROM Sales s
                                            JOIN SalesDetail sd ON s.SalesID = sd.SalesID
                                            JOIN Product p ON p.ProductID = sd.ProductID
                                            JOIN Customer c ON c.CustomerID = s.CustomerID
                                            WHERE c.CustomerId = "+ id +"AND s.SalesDate > GETDATE() - 31";

                }
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    CustomerPurchaseHistoryViewModel data;
                    while (result.Read())
                    {
                        data = new CustomerPurchaseHistoryViewModel();
                        data.CustomerId = result.GetInt32(0);
                        data.CustomerName = result.GetString(1);
                        data.ProductName = result.GetString(2);
                        data.Quantity = result.GetInt32(3);
                        data.SellingPrice = result.GetInt32(4);
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
        }

        //Question No 10
        public IActionResult NotPurchaseItemReport()
        {
            List<NotPurchaseItemViewModel> lstData = new List<NotPurchaseItemViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT p.ProductId, p.ProductName, p.Description FROM Product p
                                        WHERE p.ProductId NOT IN 
                                        (SELECT DISTINCT ProductID from PurchaseDetail)";
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    NotPurchaseItemViewModel data;
                    while (result.Read())
                    {
                        data =new NotPurchaseItemViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.Description = result.GetString(2);
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

        //Question No 14
        public IActionResult UsersReport()
        {
            List<UserModel> lstData = new List<UserModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"select username, email, phonenumber from AspNetUsers where id in (
                                        select userid from AspNetUserRoles where roleid = 2);";
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    UserModel data;
                    while (result.Read())
                    {
                        data = new UserModel();
                        data.UserName = result.GetString(0);
                        data.PhoneNumber = result.GetString(1);
                        data.Email = result.GetString(2);
                        lstData.Add(data);
                    }
                }
            }

            return View(lstData);
        }

        //public IActionResult DeleteUsers()
        //{
        //    List<UserReportViewModel> lstData = new List<UserReportViewModel>();

        //    using (var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        command.CommandText = @"?";
        //        _context.Database.OpenConnection();

        //        using (var result = command.ExecuteReader())
        //        {
        //            UserReportViewModel data;
        //            while (result.Read())
        //            {
        //                data = new UserReportViewModel();
        //                data.UserName = result.GetString(0);
        //                data.PhoneNumber = result.GetString(1);
        //                data.Email = result.GetString(2);
        //                lstData.Add(data);
        //            }
        //        }
        //    }

        //    return View(lstData);
        //}

    }
}
