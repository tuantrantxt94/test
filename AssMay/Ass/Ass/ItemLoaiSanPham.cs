using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ass.DataSetTableAdapters;
using System.Data;
namespace Ass
{
    public partial class ItemLoaiSanPham : Form
    {
        LoaiSanPhamTableAdapter _adapterLoaiSP = new LoaiSanPhamTableAdapter();
        DataSet.LoaiSanPhamDataTable _LoadLoaiSP = new DataSet.LoaiSanPhamDataTable();
        public bool ChekKq = false;
        string _MaLoaiSP = "";
        public ItemLoaiSanPham(string MaLoaiSP)
        {
            InitializeComponent();
            _MaLoaiSP = MaLoaiSP;
            LoadLoaiSanPham(MaLoaiSP);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        public void ThemLoaiSanPham() {
            DataRow rowCheck = _adapterLoaiSP.LayBangLoaiSanPham(_MaLoaiSP).FirstOrDefault();
            if (rowCheck == null) {
                _adapterLoaiSP.ThemLoaiSp(txtMaLoaiSP.Text, txtTenLoaiSP.Text, txtGhiChu.Text);
                MessageBox.Show("Thêm Thành Công");
                this.Close();
                ChekKq = true;
            }
            else
            {
         
                MessageBox.Show("Đã Tồn Tại Mã Loại Này !!!");
                txtMaLoaiSP.SelectAll();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SuaLoaiSanPham() {

            if (!string.IsNullOrEmpty(_MaLoaiSP))
            {
                _adapterLoaiSP.SuaLoaiSP(txtMaLoaiSP.Text, txtTenLoaiSP.Text, txtGhiChu.Text);
                MessageBox.Show("Sửa Thành Công");
                ChekKq = true;
                this.Close();
            }
            else
            {

                MessageBox.Show("Sửa Thất Bại");
            }

        }
        public void LoadLoaiSanPham(string maloaisp) {
            if (!string.IsNullOrEmpty(maloaisp)) {
              DataRow row = _adapterLoaiSP.LayBangLoaiSanPham(maloaisp).FirstOrDefault();
                if (row != null) {
                    txtMaLoaiSP.Enabled = false;
                    txtMaLoaiSP.Text = row[_LoadLoaiSP.MaLoaiSPColumn.ColumnName].ToString();
                    txtTenLoaiSP.Text = row[_LoadLoaiSP.TenLoaiSPColumn.ColumnName].ToString();
                    txtGhiChu.Text = row[_LoadLoaiSP.GhiChuColumn.ColumnName].ToString();
                }
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_MaLoaiSP))
            {
                ThemLoaiSanPham();
            }
            else
            {
                SuaLoaiSanPham();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtTenLoaiSP.Clear();
            txtMaLoaiSP.Clear();
            txtGhiChu.Clear();
        }
    }
}
