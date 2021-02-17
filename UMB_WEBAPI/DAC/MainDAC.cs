using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMB_DAC;
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
                               select datepart(month,sales_date) as sales_date, product_name, format(sum(sales_price), '#,0') as sales_price,
                               format(100 *(sum(sales_price) - lag(sum(sales_price), 1, sum(sales_price)) over(order by datepart(month,sales_date))) / lag(sum(sales_price), 1, sum(sales_price)) over(order by datepart(month,sales_date)), '##0') as growth_rate
                               from salesList
                               group by product_name, datepart(month,sales_date))
                               as A
                               where sales_date = datepart(month, getdate()) and product_name = 'L_UMB1'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    Sales model = new Sales();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.product_name = reader["product_name"].ToString();
                        model.sales_date = Convert.ToInt32(reader["sales_date"]);
                        model.sales_price = reader["sales_price"].ToString();
                        model.growth_rate = Convert.ToInt32(reader["growth_rate"]);
                    }
                    conn.Close();
                    return model;
                }
            }
            catch(Exception err)
            {
                conn.Close();
                string msg = err.Message;
                return null;
            }
        }

        public Performance GetPerformance()
        {
            try
            {
                string sql = @"select *, (100 * performance_qty_ng / (performance_qty_ng + performance_qty_ok)) growth_rate from(
							   select datepart(month,production_edate) production_edate, sum(performance_qty_ng) performance_qty_ng, sum(performance_qty_ok) performance_qty_ok, (100 * sum(performance_qty_ng) / (sum(performance_qty_ng) + sum(performance_qty_ok))) ng_rate
							   from performanceList 
							   group by datepart(month,production_edate)
							   ) as A
							   where production_edate = datepart(month, getdate())";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    Performance model = new Performance();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.production_edate = reader["production_edate"].ToString();
                        model.performance_qty_ng = Convert.ToInt32(reader["performance_qty_ng"]);
                        model.performance_qty_ok = Convert.ToInt32(reader["performance_qty_ok"]);
                        model.ng_rate = Convert.ToInt32(reader["ng_rate"]);
                        model.growth_rate = Convert.ToInt32(reader["growth_rate"]);
                    }
                    conn.Close();
                    return model;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                string msg = err.Message;
                return null;
            }
        }

        public List<Performance> GetPerList()
        {
            string sql = @"select *, (100 * performance_qty_ng / (performance_qty_ng + performance_qty_ok)) growth_rate from(
						   select concat(datepart(YEAR, production_edate), datepart(MONTH, production_edate)) production_edate, sum(performance_qty_ng) performance_qty_ng, sum(performance_qty_ok) performance_qty_ok, (100 * sum(performance_qty_ng) / (sum(performance_qty_ng) + sum(performance_qty_ok))) ng_rate
						   from performanceList 
						   group by concat(datepart(YEAR, production_edate), datepart(MONTH, production_edate))
						   ) as A
						   order by production_edate";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Performance> list = Helper.DataReaderMapToList<Performance>(reader);
                conn.Close();
                return list;
            }
        }
    }
}