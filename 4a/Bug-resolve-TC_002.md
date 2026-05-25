Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_002
Test description: Kiểm thử trường hợp người dùng nhập ký tự lạ (không phải số) vào ô "Số thứ nhất" hoặc "Số thứ hai" (ví dụ "abc", "12a3"), sau đó chuyển focus sang control khác (Tab hoặc Click).
Cause of the bug:
`txtSo1` và `txtSo2` không có xử lý khi mất focus. Người dùng có thể để lại 
nội dung không hợp lệ trong ô số; chương trình không báo lỗi ngay lúc đó và 
vẫn cho phép thực hiện các thao tác khác. Khi bấm "Tính", lệnh `double.Parse(...)` 
ném ra `FormatException` không được bắt, làm chương trình treo thay vì yêu cầu 
người dùng điều chỉnh ngay tại ô đang sai (theo yêu cầu đặc tả mục 3).
How to fix:
Bổ sung sự kiện `Leave` chung (`txtSo_Leave`) cho `txtSo1` và `txtSo2`. Khi ô 
mất focus, dùng `double.TryParse` kiểm tra nội dung. Nếu không phải số hợp lệ, 
hiển thị `MessageBox` cảnh báo ("Số thứ nhất không hợp lệ." hoặc "Số thứ hai 
không hợp lệ."), sau đó gọi `Focus()` và `SelectAll()` để giữ người dùng ở ô 
đó và buộc chỉnh sửa, không cho tiếp tục thao tác khác cho đến khi dữ liệu hợp lệ. 
Sự kiện được đăng ký trong `Form1.Designer.cs` cho cả hai ô số.
Note: Không
