using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenTrungVu_1951052244.Model;
using System.Data;
using System.Windows.Forms;

namespace NguyenTrungVu_1951052244
{
    class ProductBus
    {
        ProductDAL dal;
        public ProductBus()
        {
            dal = new ProductDAL();
        }

        public int UpdateProduct(Product p)
        {
            int res = 0;
            res=  dal.UpdateProduct(p);
            return res;
        }
        public int AddProduct(Product p)
        {
            int res = 0;
            res = dal.AddProduct(p);
            return res;
        }

        public DataTable GetProducts()//mô hình phi kết nối
        {
            DataTable dt = dal.GetProducts();
            return dt;
        }
        
        public DataTable GetCategories()//mô hình phi kết nối
        {
            DataTable dt = dal.GetCategories();
            return dt;
            
        }
        public void GetCategories(ComboBox cb)//mô hình phi kết nối
        {
            DataTable dt = dal.GetCategories();
            cb.DataSource = dt;
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }
        public DataTable GetSuplliers()//mô hình phi kết nối
        {
            DataTable dt = dal.GetSuplliers();
            return dt;
           
        }
        public void GetSuplliers(ComboBox cb)//mô hình phi kết nối
        {
            DataTable dt = dal.GetSuplliers();
            cb.DataSource = dt;
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }

    }
}
