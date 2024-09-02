using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ReportController : Controller
    {
        
        
       private readonly Order_context _dbContext; // Replace YourDbContext with your actual DbContext class
        private readonly Store_context _dbContext1;
        public ReportController(Order_context dbContext,Store_context dbcontext1)
            {
                _dbContext = dbContext;
                _dbContext1 = dbcontext1;
        }
        [HttpPost]
        public ActionResult SalesFilter(FilterAttribute F)
        {
            ViewBag.CustomerFilter = F.CustomerFilter;
            ViewBag.QuantityFilter = F.QuantityFilter;
            ViewBag.RegionFilter =F.RegionFilter;
            ViewBag.ProductFilter =F.ProductFilter;

            List<Order> orders = _dbContext.Order.ToList();
            List<Store> stores = _dbContext1.Store.ToList();

            var filteredStores = stores.Where(b => orders.Any(a => a.Store_Name == b.Store_Name));

            if (!string.IsNullOrEmpty(F.CustomerFilter))
            {
                orders = orders.Where(o => o.Customer_Name.Contains(F.CustomerFilter)).ToList();
            }

            if (F.QuantityFilter != 0)
            {
                orders = orders.Where(o => o.Quantity == F.QuantityFilter).ToList();
            }

            if (!string.IsNullOrEmpty(F.RegionFilter))
            {
                filteredStores = filteredStores.Where(s => s.Region.Contains(F.RegionFilter));
            }

            if (!string.IsNullOrEmpty(F.ProductFilter))
            {
                filteredStores = filteredStores.Where(s => s.Product_Name.Contains(F.ProductFilter));
            }
            var filteredData = filteredStores.Join(orders, s => s.Store_Name, o => o.Store_Name, (s, o) => new Report
            {
                Region = s.Region,
                Product_Name = s.Product_Name,
                Customer_Name = o.Customer_Name,
                Quantity = o.Quantity
            }).ToList();

            return View("Sales", filteredData);
        }
        public ActionResult Sales() {
            
            List<Order> orders = _dbContext.Order.ToList();
            List<Store> stores = _dbContext1.Store.ToList();

        var all = stores.Where(b => orders.Any(a => a.Store_Name == b.Store_Name))
                        .Select(s => new Report
                        {
                            Region = s.Region,
                            Product_Name = s.Product_Name,
                            Customer_Name = orders.First(o => o.Store_Name == s.Store_Name).Customer_Name,
                            Quantity = orders.First(o => o.Store_Name == s.Store_Name).Quantity
                        })
                        .ToList();


            return View("Sales", all);
        }
    }
}
    
