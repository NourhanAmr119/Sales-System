
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Data;
using Aspose.Pdf.Devices;
using iTextSharp.text;
using System.Reflection.Metadata;
using Document = Aspose.Pdf.Document;
using System.Data.SqlClient;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;
        List<Report> reports=new List<Report>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = "Data Source=.\\;Initial Catalog=Major;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=123";
        }
        private void FetchData()
        {
            if(reports.Count>0)
            {
                reports.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT O.Customer_Name, O.Quantity, S.Region, O.Product_Name FROM[Order] AS O INNER JOIN Store AS S ON O.Store_Name = S.Store_Name ORDER BY O.Order_Number";
                dr = com.ExecuteReader();
                while(dr.Read())
                {
                    reports.Add(new Report()
                    {
                        Customer_Name = dr["Customer_Name"].ToString()
                       ,Quantity = (int)dr["Quantity"]
                        ,Region = dr["Region"].ToString()
                       , Product_Name = dr["Product_Name"].ToString()
                    });
                }
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Index()

        {
            FetchData();
            return View(reports);
            var document = new Document
            {
                PageInfo = new PageInfo { Margin = new MarginInfo(28, 28, 28, 40) }
            };
            var pdePage = document.Pages.Add();
            Table table = new Table
            {
                ColumnWidths = "25% 25% 25% 25%",
                DefaultCellPadding =new MarginInfo(10, 5, 10, 5),
                Border = new BorderInfo(BorderSide.All, .5f, Color.Black),
                DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Color.Black),
            };
            DataTable dt = dbop.Getrecord();
            table.ImportDataTable(dt, true, 0, 0);
            document.Pages[1].Paragraphs.Add(table);
            using (var Streamout =new MemoryStream())
            {
                document.Save(Streamout);
                return new FileContentResult(Streamout.ToArray(), "application/pdf")
                {
                    FileDownloadName ="Sales.pdf"
                };
            }
         
        }

        public IActionResult salesInfo()
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
