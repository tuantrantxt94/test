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
    public partial class BangSanPham : Form
    {
        ItemSanPham _itemsp = new ItemSanPham("");
        SanPhamTableAdapter _adapterSp = new SanPhamTableAdapter();
        public BangSanPham()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable _data = _adapterSp.GetData();
            ShowSanPham.DataSource = _data.DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _itemsp = new ItemSanPham("");
            _itemsp.ShowDialog();
            if (_itemsp.CheckkQ == true) {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSP = ShowSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
            _itemsp = new ItemSanPham(maSP);
            _itemsp.ShowDialog();
            if (_itemsp.CheckkQ == true)
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = ShowSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
                if (!string.IsNullOrEmpty(maSP))
                {
                    _adapterSp.XoaSanPham(maSP);
                    MessageBox.Show("Xoa thanh cong");
                    LoadData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xoa khong thanh cong do: "+ex.Message);
            }
        }
        
    }
}
