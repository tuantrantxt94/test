using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ass.DataSetTableAdapters;
using System.Windows.Forms;

namespace Ass
{
    public partial class ItemBangKhachHang : Form
    {//khai báo biến toàn cục trên này
        TB_KhachhangTableAdapter _adapterKH = new TB_KhachhangTableAdapter();
        DataSet._TB_KhachhangDataTable _LoadfileKH = new DataSet._TB_KhachhangDataTable();
        //bool là keieu true fale;
        public bool checkKQ = false;
        string _MaKh = "";
        public ItemBangKhachHang(string MaKH)
        {
            InitializeComponent();
            _MaKh = MaKH;
            LoadMaKH(MaKH);
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtMaKh.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_MaKh))
                ThemKH();
            else { SuaKH(); }
        }
        public void ThemKH()
        {

            DataRow rowChekc = _adapterKH.getDataBangKhachHang(_MaKh).FirstOrDefault();
            if (rowChekc == null)
            {
                _adapterKH.ThemKhachHang(
                    txtMaKh.Text,
                    txtTenKH.Text,
                    txtSDT.Text,
                    txtDiaChi.Text,
                    txtEmail.Text
                    );
                MessageBox.Show("Thêm Thành Công");
                checkKQ = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại" + txtMaKh.Text);
                txtMaKh.SelectAll();
                return;
            }
        }
        public void SuaKH()
        {
            if (!string.IsNullOrEmpty(_MaKh))
            {
                _adapterKH.SuaKhachHang(
                      txtMaKh.Text,
                      txtTenKH.Text,
                      txtSDT.Text,
                      txtDiaChi.Text,
                      txtEmail.Text
                      );
                checkKQ = true;
                this.Close();
                MessageBox.Show("Sửa Thành Công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");

            }

        }
        public void LoadMaKH(string makh)
        {
            if (!string.IsNullOrEmpty(makh))
            {
                DataRow row = _adapterKH.getDataBangKhachHang(makh).FirstOrDefault();
                if (row != null)
                {
                    txtMaKh.Enabled = false;
                    txtMaKh.Text = row[_LoadfileKH.MaKHColumn.ColumnName].ToString();
                    txtTenKH.Text = row[_LoadfileKH.TenKHColumn.ColumnName].ToString();
                    txtEmail.Text = row[_LoadfileKH.EmailColumn.ColumnName].ToString();
                    txtDiaChi.Text = row[_LoadfileKH.DiaChiColumn.ColumnName].ToString();
                    txtSDT.Text = row[_LoadfileKH.SdtColumn.ColumnName].ToString();

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

