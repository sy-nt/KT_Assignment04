Developer's name: Nguyen Tien Sy
Fix date: 2026-05-25
Test case ID: TC_010B
Test description: Kiểm tra thông báo cảnh báo khi ô nhập thứ hai bị để trống.
Cause of the bug:
Ô "Số thứ hai" chưa được kiểm tra dữ liệu rỗng khi mất focus. Người dùng có 
thể xóa toàn bộ nội dung trong ô rồi tiếp tục thao tác với các control khác. 
Khi thực hiện tính toán, chương trình chuyển đổi chuỗi rỗng bằng 
`double.Parse("")`, gây lỗi `FormatException`.
How to fix:
Bổ sung sự kiện `Validating` cho ô "Số thứ hai". Trong handler, kiểm tra 
`string.IsNullOrWhiteSpace(txtSo2.Text)`. Nếu ô đang rỗng thì hiển thị thông 
báo "Vui lòng nhập số thứ hai.", đặt `e.Cancel = true` để giữ focus tại ô 
"Số thứ hai" và gọi `SelectAll()` để người dùng nhập lại ngay.
Note: Không
