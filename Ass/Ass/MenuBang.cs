using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass
{
    public partial class MenuBang : Form
    {
        BangLoaiSanPham _tbLoaiSP = new BangLoaiSanPham();
        BangKhachHang _tbKhShow = new BangKhachHang();
        BangSanPham _tbSanPham = new BangSanPham();
        BangHoaDon _tbHoaDon = new BangHoaDon();

        public MenuBang()
        {
            InitializeComponent();
           
        }
       

        private void bảngKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nhâp đôi nó sẽ tự sinh ra 1 hàm tương tự onclick
            _tbKhShow = new BangKhachHang();
            _tbKhShow.Show();
        }

        private void bảngLoạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tbLoaiSP = new BangLoaiSanPham();
            _tbLoaiSP.Show();
        }

        private void bảngSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tbSanPham = new BangSanPham();
            _tbSanPham.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tbKhShow = new BangKhachHang();
            _tbKhShow.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tbHoaDon = new BangHoaDon();
            _tbHoaDon.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _tbLoaiSP = new BangLoaiSanPham();
            _tbLoaiSP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _tbSanPham = new BangSanPham();
            _tbSanPham.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _tbHoaDon = new BangHoaDon();
            _tbHoaDon.Show();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
