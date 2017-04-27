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

namespace Ass
{
    public partial class BangHoaDon : Form
    {
        HoaDonTableAdapter _adapterHD = new HoaDonTableAdapter();
        ChiTietHoaDonTableAdapter _adapterCTHD = new ChiTietHoaDonTableAdapter();
        public BangHoaDon()
        {
            InitializeComponent();
            DataTable DT = _adapterHD.GetData();
            showHD.DataSource = DT.DefaultView;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            IteamHoaDon frm = new IteamHoaDon("");
            frm.ShowDialog();
            if(frm.check == true)
            {
                DataTable DT = _adapterHD.GetData();
                showHD.DataSource = DT.DefaultView;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string maHD = showHD.CurrentRow.Cells["MaHD"].Value.ToString();
            IteamHoaDon frm = new IteamHoaDon(maHD);
            frm.ShowDialog();
            if (frm.check == true)
            {
                DataTable DT = _adapterHD.GetData();
                showHD.DataSource = DT.DefaultView;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHD = showHD.CurrentRow.Cells["MaHD"].Value.ToString();
            _adapterCTHD.XoaChiTietHD(maHD);
            _adapterHD.XoaHD(maHD);
            DataTable DT = _adapterHD.GetData();
            showHD.DataSource = DT.DefaultView;
        }
    }
}
