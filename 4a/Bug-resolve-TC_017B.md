Developer's name: Nguyen Tien Sy
Fix date: 2026-05-25
Test case ID: TC_017B
Test description: Kiểm tra hành vi quét chọn toàn bộ nội dung khi ô nhập thứ hai nhận focus.
Cause of the bug:
Ô "Số thứ hai" chưa được gắn sự kiện xử lý khi nhận focus. Vì vậy khi người 
dùng Tab hoặc Click vào ô, nội dung cũ không được chọn toàn bộ, khiến người 
dùng phải tự xóa hoặc bôi đen trước khi nhập giá trị mới.
How to fix:
Bổ sung sự kiện `Enter` cho ô "Số thứ hai". Trong handler, ép kiểu `sender` 
về `TextBox` rồi gọi `SelectAll()` để quét chọn toàn bộ nội dung khi ô nhận 
focus.
Note: Không
