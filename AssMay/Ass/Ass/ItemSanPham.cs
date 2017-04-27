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
    public partial class ItemSanPham : Form
    {
        SanPhamTableAdapter _adapterSP = new SanPhamTableAdapter();
        DataSet.SanPhamDataTable LoadFileSp = new DataSet.SanPhamDataTable();
        public bool CheckkQ = false;
        string _MaSp = "";
        LoaiSanPhamTableAdapter _loaiSP = new LoaiSanPhamTableAdapter();
        DataSet.LoaiSanPhamDataTable loaiSPFile = new DataSet.LoaiSanPhamDataTable();

        public ItemSanPham(string MaSp)
        {
            InitializeComponent();
            _MaSp = MaSp;
            LoadComboBox();
            Fildata(_MaSp);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_MaSp))
                ThemSanPham();
            else
                SuaSP();
        }
        public void ThemSanPham()
        {
            DataRow _rowCheck = _adapterSP.GetDataBase(_MaSp).FirstOrDefault();
            if (_rowCheck == null)
            {
                decimal dongia = 0;
                //chuyen text sang decimal(kieu so )
                decimal.TryParse(txtGiaSP.Text, out dongia);
                _adapterSP.ThemSanPham(txtMSP.Text, txtTenSP.Text, dongia, cbbLoaiSP.SelectedValue.ToString());
                MessageBox.Show("Thêm Thành Công Sản Phẩm");
                this.Close();
                CheckkQ = true;
            }
            else
            {
                MessageBox.Show("Mã Sản Phẩm Đã tồn tại");
            }
        }

        private void SuaSP()
        {
            if(!string.IsNullOrEmpty(_MaSp))
            {
                decimal dongia = 0;
                decimal.TryParse(txtGiaSP.Text, out dongia);
                _adapterSP.SuaSanPham(txtTenSP.Text, dongia, cbbLoaiSP.SelectedValue.ToString(), _MaSp);
                MessageBox.Show("Sua Thành Công Sản Phẩm");
                this.Close();
                CheckkQ = true;
            }
        }

        //load combobox
        public void LoadComboBox()
        {
            // Load Data len Combo box
            DataTable DTLOAISP = _loaiSP.GetData();
            cbbLoaiSP.DataSource = DTLOAISP.DefaultView;
            cbbLoaiSP.ValueMember = loaiSPFile.MaLoaiSPColumn.ColumnName;
            cbbLoaiSP.DisplayMember = loaiSPFile.MaLoaiSPColumn.ColumnName;

            // End Load Data
        }

        private void Fildata(string maSP)
        {
            //fill text để sau hàm load combobox
            if (!string.IsNullOrEmpty(maSP))
            {
                DataRow row = _adapterSP.GetDataBase(maSP).FirstOrDefault();
                if (row != null)
                {
                    txtMSP.Enabled = false;
                    txtMSP.Text = row[LoadFileSp.MaSpColumn.ColumnName].ToString();
                    txtTenSP.Text = row[LoadFileSp.TenSPColumn.ColumnName].ToString();
                    txtGiaSP.Text = row[LoadFileSp.GiaSpColumn.ColumnName].ToString();
                    cbbLoaiSP.SelectedValue = row[LoadFileSp.MaLoaiSPColumn.ColumnName];
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtTenSP.Clear();
            txtMSP.Clear();
            txtGiaSP.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
