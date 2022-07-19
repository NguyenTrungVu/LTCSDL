using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenTrungVu_1951052244.Model;
using System.Data;

namespace NguyenTrungVu_1951052244
{
    class ProductDAL
    {
        #region Biến toàn cục
        SqlConnection conn;
        #endregion

        public ProductDAL()
        {
            KetNoiDB();
        }
        private void KetNoiDB()
        {
            string kt = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            conn = new SqlConnection(kt);
        }

        public DataTable GetProducts()//mô hình phi kết nối
        {
            DataTable dt = new DataTable();
            string query = "select ProductID, ProductName, UnitPrice, QuantityPerUnit, CategoryID, SupplierID from Products";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetCategories()//mô hình phi kết nối
        {
            DataTable dt = new DataTable();
            string query = "select CategoryID, CategoryName from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
       public DataTable GetSuplliers()//mô hình phi kết nối
        {
            DataTable dt = new DataTable();
            string query = "select SupplierID, CompanyName from Suppliers";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }
        public int UpdateProduct(Product p)
        {
            int res = 0;
            try
            {
                string query = String.Format(
                    "update products set ProductName = N'{0}', UnitPrice = {1}, CategoryID= {2} where ProductId = {3}", p.ProductName, p.UnitPrice, p.CategoryID, p.ProductID);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
                res = 1;
            }
            catch(SqlException)
            {
                res = 0;
            }
            finally
            {
                conn.Close();
            }
            return res;
           
        }
        public int AddProduct(Product p)
        {
            int res = 0;
            try
            {

                string query = String.Format("insert into Products (ProductName, UnitPrice, SupplierID, CategoryID) values (N'{0}', {1}, {2}, {3})",
                  p.ProductName, p.UnitPrice, p.SupplierID, p.CategoryID);
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);

                com.ExecuteNonQuery();
                res = 1;
            }
            catch (SqlException e)
            {
                res = 0;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

    }
}
