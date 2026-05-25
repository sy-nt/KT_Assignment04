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
            // TC_003: Kiểm tra ô nhập rỗng trước khi tính toán
            if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show("Vui lòng nhập số thứ nhất.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo1.Focus();
                txtSo1.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show("Vui lòng nhập số thứ hai.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo2.Focus();
                txtSo2.SelectAll();
                return;
            }

            // Dùng TryParse để tránh ngoại lệ khi dữ liệu không hợp lệ
            double so1, so2, kq = 0;
            if (!double.TryParse(txtSo1.Text, NumberStyles.Float,
                                 CultureInfo.CurrentCulture, out so1))
            {
                MessageBox.Show("Số thứ nhất không hợp lệ.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo1.Focus();
                txtSo1.SelectAll();
                return;
            }
            if (!double.TryParse(txtSo2.Text, NumberStyles.Float,
                                 CultureInfo.CurrentCulture, out so2))
            {
                MessageBox.Show("Số thứ hai không hợp lệ.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo2.Focus();
                txtSo2.SelectAll();
                return;
            }

            // TC_001: Không cho phép chia cho 0
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

        // TC_002: Chỉ cho phép nhập ký tự số, dấu trừ đứng đầu và một dấu thập phân
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            char c = e.KeyChar;
            if (char.IsControl(c)) return;            // cho phép Backspace, Ctrl+...
            if (char.IsDigit(c)) return;

            string decSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (c.ToString() == decSep && !tb.Text.Contains(decSep)) return;

            if (c == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-")) return;

            e.Handled = true;
        }

        // TC_002 + TC_004: Vô hiệu hóa nút Tính khi dữ liệu không hợp lệ,
        // đồng thời xóa kết quả cũ khi người dùng chỉnh sửa số nhập.
        private void txtSo_TextChanged(object sender, EventArgs e)
        {
            txtKq.Text = string.Empty;

            double tmp;
            bool ok1 = !string.IsNullOrWhiteSpace(txtSo1.Text)
                       && double.TryParse(txtSo1.Text, NumberStyles.Float,
                                          CultureInfo.CurrentCulture, out tmp);
            bool ok2 = !string.IsNullOrWhiteSpace(txtSo2.Text)
                       && double.TryParse(txtSo2.Text, NumberStyles.Float,
                                          CultureInfo.CurrentCulture, out tmp);
            btnTinh.Enabled = ok1 && ok2;
        }

        // TC_005: Khi focus vào ô số, tự chọn toàn bộ nội dung để dễ chỉnh sửa
        private void txtSo_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null) tb.SelectAll();
        }
    }
}
