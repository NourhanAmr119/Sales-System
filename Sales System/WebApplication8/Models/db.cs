using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication8.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=.\\;Initial Catalog=Major;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=123");
        public DataTable Getrecord()
        {
            SqlCommand com = new SqlCommand("SELECT O.Customer_Name, O.Quantity, S.Region, O.Product_Name FROM[Order] AS O INNER JOIN Store AS S ON O.Store_Name = S.Store_Name ORDER BY O.Order_Number", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
