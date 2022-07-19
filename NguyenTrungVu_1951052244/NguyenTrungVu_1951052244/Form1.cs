using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using NguyenTrungVu_1951052244.Model;

namespace NguyenTrungVu_1951052244
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            productBus = new ProductBus();
        }

        ProductBus productBus;

      
        

     
      

        //private void AddProduct(string ten, double gia, int ncc, int loai)
        //{
        //    try
        //    {

        //        string query = String.Format("insert into Products (ProductName, UnitPrice, SupplierID, CategoryID) values (N'{0}', {1}, {2}, {3})",
        //          ten, gia, ncc, loai);
        //        conn.Open();
        //        SqlCommand com = new SqlCommand(query, conn);
              
        //        com.ExecuteNonQuery();
        //        MessageBox.Show("Thêm thành công!!");
        //    }
        //    catch (SqlException e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //private void DeleteProduct(int ma)
        //{
        //    try
        //    {
        //        string query = String.Format("delete from Products where ProductID = {0}", ma);
        //        conn.Open();
        //        SqlCommand com = new SqlCommand(query, conn);
        //        com.ExecuteNonQuery();
        //        MessageBox.Show("Xóa thành công!!");
        //    }
        //    catch( SqlException e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            //KetNoiDB();
            //gvSanPham.DataSource = LayDSSP();
            //cbLoaiSP.DataSource = productBus.GetCategories();
            //cbLoaiSP.DisplayMember = "CategoryName";
            //cbLoaiSP.ValueMember = "CategoryID";
            //cbNCC.DataSource = productBus.GetSuplliers();
            //cbNCC.DisplayMember = "CompanyName";
            //cbNCC.ValueMember = "SupplierID";
            gvSanPham.DataSource = productBus.GetProducts();
            productBus.GetCategories(cbLoaiSP);
            productBus.GetSuplliers(cbNCC);


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            int kq = 0;
            p.ProductName = txtTenSP.Text;
            p.UnitPrice = double.Parse(txtDonGia.Text.Replace(".", ""));
            p.SupplierID = Int32.Parse(cbNCC.SelectedValue.ToString());
            p.CategoryID = Int32.Parse(cbLoaiSP.SelectedValue.ToString());

            kq = productBus.AddProduct(p);
            if (kq == 1)
            {
                gvSanPham.Columns.Clear();
                gvSanPham.DataSource = productBus.GetProducts();
                MessageBox.Show("Thêm thành công!");

            }
            else
                MessageBox.Show("Thêm không thành công!");

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //DeleteProduct();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            int kq = 0;
            p.ProductID = Int32.Parse(txtproId.Text);
            p.ProductName = txtTenSP.Text;
            p.UnitPrice = double.Parse(txtDonGia.Text.Replace(".",""));
            p.CategoryID = Int32.Parse(cbLoaiSP.SelectedValue.ToString());
            p.SupplierID = Int32.Parse(cbNCC.SelectedValue.ToString());

            kq = productBus.UpdateProduct(p);
            if (kq == 1)
            {
                gvSanPham.Columns.Clear();
                gvSanPham.DataSource = productBus.GetProducts();
                MessageBox.Show("Sửa thành công!");

            }
            else
                MessageBox.Show("Sửa không thành công!");
        }

        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0 && e.RowIndex < gvSanPham.Rows.Count)
                {
                    txtproId.Text = gvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTenSP.Text = gvSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDonGia.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    txtSoLuong.Text = gvSanPham.Rows[e.RowIndex].Cells["QuantityPerUnit"].Value.ToString();
                    cbLoaiSP.SelectedIndex = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
