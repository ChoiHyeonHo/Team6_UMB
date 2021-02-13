using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMB_DAC;
using UMB_WEB.Models;
using UMB_WEBAPI.Models;

namespace UMB_WEBAPI.DAC
{
    public class MainDAC : Connection, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public MainDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public Sales GetSales()
        {
            try
            {
                string sql = @"select * from(
                               select datepart(month,sales_date) as sales_date, product_name, sum(sales_price) as sales_price,
                               format(100 *(sum(sales_price) - lag(sum(sales_price), 1, sum(sales_price)) over(order by datepart(month,sales_date))) / lag(sum(sales_price), 1, sum(sales_price)) over(order by datepart(month,sales_date)), '##0') as growth_rate
                               from salesList
                               group by product_name, datepart(month,sales_date))
                               as A
                               where sales_date = datepart(month, getdate())";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection = conn;

                    conn.Open();
                    Sales model = new Sales();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.product_name = reader["product_name"].ToString();
                        model.sales_date = Convert.ToInt32(reader["sales_date"]);
                        model.sales_price = Convert.ToInt32(reader["sales_price"]);
                        model.growth_rate = Convert.ToInt32(reader["growth_rate"]);
                    }

                    conn.Close();
                    return model;
                }
            }
            catch(Exception err)
            {
                string msg = err.Message;
                return null;
            }
        }
    }
}