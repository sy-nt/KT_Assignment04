using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            double so1, so2, kq = 0;
            if (!double.TryParse(txtSo1.Text, NumberStyles.Float,
                                 CultureInfo.CurrentCulture, out so1))
                return;
            if (!double.TryParse(txtSo2.Text, NumberStyles.Float,
                                 CultureInfo.CurrentCulture, out so2))
                return;

            // TC_006: Không cho phép chia cho 0
            if (radChia.Checked && so2 == 0)
            {
                MessageBox.Show("Không thể chia cho 0. Vui lòng nhập lại số thứ hai.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo2.Focus();
                txtSo2.SelectAll();
                return;
            }

            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        // TC_010A + TC_010B: Kiểm tra rỗng và ký tự lạ khi ô số mất focus (Validating)
        private void txtSo_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            bool isSo1 = tb == txtSo1;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show(isSo1 ? "Vui lòng nhập số thứ nhất." : "Vui lòng nhập số thứ hai.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                tb.SelectAll();
                return;
            }

            double tmp;
            if (!double.TryParse(tb.Text, NumberStyles.Float,
                                 CultureInfo.CurrentCulture, out tmp))
            {
                MessageBox.Show(isSo1 ? "Số thứ nhất không hợp lệ." : "Số thứ hai không hợp lệ.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                tb.SelectAll();
            }
        }

        // TC_017A + TC_017B: Khi focus vào ô số, tự chọn toàn bộ nội dung để dễ chỉnh sửa
        private void txtSo_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null) tb.SelectAll();
        }
    }
}
