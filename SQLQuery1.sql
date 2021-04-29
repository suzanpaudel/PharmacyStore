SELECT CustomerName, CustomerEmail, CustomerPhoneNo, CustomerAddress from Customer
                                        WHERE CustomerID NOT IN
                                        (SELECT DISTINCT CustomerID FROM Sales 
                                        WHERE SalesDate > GETDATE() -31);