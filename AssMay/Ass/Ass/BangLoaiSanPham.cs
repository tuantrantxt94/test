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
    public partial class BangLoaiSanPham : Form
    {
        LoaiSanPhamTableAdapter _adapterLoaiSP = new LoaiSanPhamTableAdapter();
        ItemLoaiSanPham _itemLoaiSP = new ItemLoaiSanPham("");
       
        public BangLoaiSanPham()
        {
            InitializeComponent();
            DataTable _dataLoaisp = _adapterLoaiSP.GetData();
            showLoaiSP.DataSource = _dataLoaisp.DefaultView;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void themLoaiSp_Click(object sender, EventArgs e)
        {
            _itemLoaiSP = new ItemLoaiSanPham("");
            _itemLoaiSP.ShowDialog();
            if (_itemLoaiSP.ChekKq == true) {
                DataTable _data = _adapterLoaiSP.GetData();
                showLoaiSP.DataSource = _data.DefaultView;
            }
        }

        private void SuaLoaiSP_Click(object sender, EventArgs e)
        {
            string maLoaiSp = showLoaiSP.CurrentRow.Cells["MaLoaiSP"].Value.ToString();
            _itemLoaiSP = new ItemLoaiSanPham(maLoaiSp);
            _itemLoaiSP.ShowDialog();
            if (_itemLoaiSP.ChekKq == true)
            {
                DataTable _data = _adapterLoaiSP.GetData();
                showLoaiSP.DataSource = _data.DefaultView;
            }
        }

        private void XoaLoaiSp_Click(object sender, EventArgs e)
        {
            string maloaisp = showLoaiSP.CurrentRow.Cells["MaLoaiSP"].Value.ToString();
            _itemLoaiSP = new ItemLoaiSanPham(maloaisp);
            _adapterLoaiSP.XoaLoaiSP(maloaisp);
            MessageBox.Show("Xóa Thành Công");
            DataTable _data = _adapterLoaiSP.GetData();
            showLoaiSP.DataSource = _data.DefaultView;
        }
    }
}
