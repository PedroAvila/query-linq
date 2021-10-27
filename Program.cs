using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();
            //IQueryable<Customer> custs = from c in context.Customers
            //                             where c.City == "London"
            //                             select c;
            //foreach (var cust in custs)
            //{
            //    Console.WriteLine($"Customer: {cust.CompanyName}");
            //}

            //IQueryable<Customer> parisCustomers = from customer in context.Customers
            //                                      where customer.City == "PARIS"
            //                                      select customer;
            //foreach (var cust in parisCustomers)
            //{
            //    Console.WriteLine($"Paris customer: {cust.CompanyName}");
            //}

            //Console.WriteLine(Environment.NewLine);

            //IQueryable<Customer> custs = from c in context.Customers
            //                             where c.Country == "UK" && c.City == "London"
            //                             orderby c.CustomerID
            //                             select c;

            //IQueryable<Customer> custs = from c in context.Customers
            //                             .Include("Orders")
            //                             where c.Country == "UK" && c.City == "London"
            //                             orderby c.CustomerID
            //                             select c;

            //foreach (var cust in custs)
            //{
            //    Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
            //    Order firstOrder = cust.Orders.First();
            //    Console.WriteLine("     {0}", firstOrder.OrderID);
            //}

            //IQueryable<OrderExtend> orders = from o in context.Order_Details
            //                                 join p in context.Products on o.ProductID equals p.ProductID
            //                                 join c in context.Categories on p.CategoryID equals c.CategoryID
            //                                 select new OrderExtend
            //                                 {
            //                                     OrderId = o.OrderID,
            //                                     ProductName = p.ProductName,
            //                                     CategoryName = c.CategoryName,
            //                                     UnitPrice = o.UnitPrice,
            //                                     Quantity = o.Quantity
            //                                 };

            List<OrderExtend> orders2 = context.Order_Details
                                        .Include("Product")
                                        .Include("Category")
                                        .Select(x => new OrderExtend()
                                        {
                                            OrderId = x.OrderID,
                                            ProductName = x.Product.ProductName,
                                            CategoryName = x.Product.Category.CategoryName,
                                            UnitPrice = x.UnitPrice,
                                            Quantity = x.Quantity
                                        }).ToList();

            foreach (var order in orders2)
            {
                Console.WriteLine($"{order.OrderId} - {order.ProductName} - {order.CategoryName} - {order.UnitPrice} - {order.Quantity}");
            }

            Console.ReadKey();

        }
    }
}
