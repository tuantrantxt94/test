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
    public partial class IteamHoaDon : Form
    {
        string _Mahd = "";
        HoaDonTableAdapter _AdapterHoaDon = new HoaDonTableAdapter();
        ChiTietHoaDonTableAdapter _AdapterChitietHD = new ChiTietHoaDonTableAdapter();
        DataSet.HoaDonDataTable LoadHD = new DataSet.HoaDonDataTable();
        DataSet.ChiTietHoaDonDataTable loadChitietHD = new DataSet.ChiTietHoaDonDataTable();
        DataTable DTHDChiTiet = new DataTable();

        TB_KhachhangTableAdapter _adapterKh = new TB_KhachhangTableAdapter();
        SanPhamTableAdapter _adapterSP = new SanPhamTableAdapter();

        DataSet._TB_KhachhangDataTable loadKH = new DataSet._TB_KhachhangDataTable();
        DataSet.SanPhamDataTable loadSP = new DataSet.SanPhamDataTable();

        public bool check = false;

        public IteamHoaDon(string MaHD)
        {
            InitializeComponent();
            _Mahd = MaHD;
            LoadDataCBB();
            LoadData(_Mahd);
        }

        private void LoadData(string MaHD)
        {
            if (!string.IsNullOrEmpty(MaHD))
            {
                DataRow rowHD = _AdapterHoaDon.GetDatabyMaHD(MaHD).FirstOrDefault();
                if (rowHD != null)
                {
                    txtMaHD.Text = rowHD[LoadHD.MaHDColumn.ColumnName].ToString();
                    cbbMaKH.SelectedValue = rowHD[LoadHD.MaKHColumn.ColumnName].ToString();
                }
            }
            DTHDChiTiet = _AdapterChitietHD.GetDataChiTietByMaHD(MaHD);
            ChitietHD.DataSource = DTHDChiTiet.DefaultView;
        }

        private void LoadDataCBB()
        {
            DataTable DTKhachang = _adapterKh.GetData();
            cbbMaKH.DataSource = DTKhachang.DefaultView;
            cbbMaKH.ValueMember = loadKH.MaKHColumn.ColumnName;
            cbbMaKH.DisplayMember = loadKH.MaKHColumn.ColumnName;

            DataTable DTSP = _adapterSP.GetData();
            cbbSP.DataSource = DTSP.DefaultView;
            cbbSP.ValueMember = loadSP.MaSpColumn.ColumnName;
            cbbSP.DisplayMember = loadSP.TenSPColumn.ColumnName;
        }

        private void txtSL_Validated(object sender, EventArgs e)
        {
            int soluong = 0;
            int.TryParse(txtSL.Text, out soluong);
            DataRow row = DTHDChiTiet.Select(loadChitietHD.MaSpColumn.ColumnName + " ='" + cbbSP.SelectedValue.ToString() + "'").FirstOrDefault();
            if (row != null)
            {
                row[loadChitietHD.SoLuongColumn.ColumnName] = soluong;
            }
            else
            {
                DataRow rowThem = DTHDChiTiet.NewRow();
                rowThem[loadChitietHD.MaHDColumn.ColumnName] = txtMaHD.Text;
                rowThem[loadChitietHD.MaSpColumn.ColumnName] = cbbSP.SelectedValue.ToString();
                rowThem[loadSP.TenSPColumn.ColumnName] = cbbSP.Text;
                rowThem[loadChitietHD.SoLuongColumn.ColumnName] = soluong;
                DTHDChiTiet.Rows.Add(rowThem);
            }
            DTHDChiTiet.AcceptChanges();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_Mahd))
                themHD();
            else
                SuaHD();
        }

        private void themHD()
        {
            try
            {
                if (string.IsNullOrEmpty(_Mahd))
                {
                    _AdapterHoaDon.ThemHD(txtMaHD.Text, cbbMaKH.SelectedValue.ToString());
                    DataView dv = (DataView)ChitietHD.DataSource;
                    DataTable dt = dv.Table;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int soluong = 0;
                        int.TryParse(dt.Rows[i][loadChitietHD.SoLuongColumn.ColumnName].ToString(), out soluong);
                        _AdapterChitietHD.ThemHDChiTiet(txtMaHD.Text,
                            dt.Rows[i][loadChitietHD.MaSpColumn.ColumnName].ToString(),
                            soluong);
                    }
                    check = true;
                }
                MessageBox.Show("thêm thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show("thêm không thành công" + ex.Message);
            }

        }

        private void SuaHD()
        {
            try
            {
                if (!string.IsNullOrEmpty(_Mahd))
                {
                    _AdapterHoaDon.SuaHD(cbbMaKH.SelectedValue.ToString(), _Mahd);
                    DataView dv = (DataView)ChitietHD.DataSource;
                    DataTable dt = dv.Table;
                    _AdapterChitietHD.XoaChiTietHD(_Mahd);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int soluong = 0;
                        int.TryParse(dt.Rows[i][loadChitietHD.SoLuongColumn.ColumnName].ToString(), out soluong);
                        _AdapterChitietHD.ThemHDChiTiet(txtMaHD.Text,
                            dt.Rows[i][loadChitietHD.MaSpColumn.ColumnName].ToString(),
                            soluong);
                    }
                    check = true;
                }
                MessageBox.Show("Sửa thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công" + ex.Message);
            }

        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
