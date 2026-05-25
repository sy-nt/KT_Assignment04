Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_003
Test description: Kiểm thử trường hợp người dùng xóa rỗng ô "Số thứ nhất" và/hoặc "Số thứ hai" rồi bấm nút "Tính".
Cause of the bug:
`btnTinh_Click` gọi trực tiếp `double.Parse(txtSo1.Text)` và 
`double.Parse(txtSo2.Text)` mà không kiểm tra chuỗi rỗng trước. Khi ô nhập rỗng, 
`double.Parse("")` ném `FormatException` không được bắt, gây crash ứng dụng và 
không có thông điệp nào hướng dẫn người dùng nhập lại.
How to fix:
Ở đầu `btnTinh_Click`, kiểm tra `string.IsNullOrWhiteSpace(txtSo1.Text)` và 
`string.IsNullOrWhiteSpace(txtSo2.Text)`. Nếu một trong hai ô rỗng, hiển thị 
`MessageBox` cảnh báo cụ thể ("Vui lòng nhập số thứ nhất." hoặc "Vui lòng nhập 
số thứ hai."), đặt `Focus` về ô đang trống và gọi `SelectAll()` để người dùng 
có thể gõ lại ngay. Dùng `return;` để dừng việc tính toán. Ngoài ra, thay 
`double.Parse` bằng `double.TryParse` để phòng vệ thêm cho mọi đầu vào lạ còn 
sót lại sau bước kiểm tra rỗng.
Note: Không
