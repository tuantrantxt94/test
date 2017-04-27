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
    public partial class BangKhachHang : Form
    {//cái này là hàm do nãy chúng ta tạo ra không hiểu thì back lại tý đại loại nó 
        // tạo ra 1 cái adapter cho từng bảng 
        ItemBangKhachHang _itembangKH;
        TB_KhachhangTableAdapter _tbKH_Adapter = new TB_KhachhangTableAdapter();
        public BangKhachHang()
        {
            InitializeComponent();
            // giống oncreat của JAva khi chạy nó gọi thằng này đầu tiên 
            DataTable data_KH = _tbKH_Adapter.GetData();
            bangKH.DataSource = data_KH.DefaultView;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //hàm exit mặc định
            this.Close();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            _itembangKH = new ItemBangKhachHang("");
            //show dialog lấy giá trị trả về nhớ là phải ShowDialog show là sai nhé
            _itembangKH.ShowDialog();
            //bên item trả về kết quả  bên này nhận
            if (_itembangKH.checkKQ == true) {
                // nếu kêt quả trả về true thì load lại bảng để người dùng thấy cái mình 
                //vừa thêm
                DataTable data_KH = _tbKH_Adapter.GetData();
                bangKH.DataSource = data_KH.DefaultView;
            } else {
                    
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            //lấy lại cái item cũ mà truyên MaKH vào
            string makh = bangKH.CurrentRow.Cells["MaKH"].Value.ToString();
            _itembangKH = new ItemBangKhachHang(makh);
            _itembangKH.ShowDialog();
            if (_itembangKH.checkKQ == true) {
                DataTable data_KH = _tbKH_Adapter.GetData();
                bangKH.DataSource = data_KH.DefaultView;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string makh = bangKH.CurrentRow.Cells["MaKH"].Value.ToString();
            _tbKH_Adapter.XoaKh(makh);
            MessageBox.Show("Xóa Thành Công");
            // Load Lại Bảng sau khi xóa Xong
            DataTable _dataloadlai = _tbKH_Adapter.GetData();
            bangKH.DataSource = _dataloadlai.DefaultView;
        }
    }
}
