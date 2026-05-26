Developer's name: Nguyen Tien Sy
Fix date: 2026-05-25
Test case ID: TC_010A
Test description: Kiểm tra thông báo cảnh báo khi ô nhập thứ nhất bị để trống.
Cause of the bug:
Ô "Số thứ nhất" chưa được kiểm tra dữ liệu rỗng khi mất focus. Người dùng có 
thể xóa toàn bộ nội dung trong ô rồi tiếp tục thao tác với các control khác. 
Khi thực hiện tính toán, chương trình chuyển đổi chuỗi rỗng bằng 
`double.Parse("")`, gây lỗi `FormatException`.
How to fix:
Bổ sung sự kiện `Validating` cho ô "Số thứ nhất". Trong handler, kiểm tra 
`string.IsNullOrWhiteSpace(txtSo1.Text)`. Nếu ô đang rỗng thì hiển thị thông 
báo "Vui lòng nhập số thứ nhất.", đặt `e.Cancel = true` để giữ focus tại ô 
"Số thứ nhất" và gọi `SelectAll()` để người dùng nhập lại ngay.
Note: Không
