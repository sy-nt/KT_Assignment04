Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_002
Test description: Kiểm thử trường hợp người dùng nhập ký tự không phải số vào ô "Số thứ nhất" hoặc "Số thứ hai"; chương trình phải chặn ký tự sai ngay khi gõ và vô hiệu hóa nút "Tính" khi dữ liệu không hợp lệ.
Cause of the bug:
`txtSo1` và `txtSo2` không có ràng buộc đầu vào nào. Người dùng có thể gõ bất kỳ 
ký tự nào (chữ cái, ký hiệu, dấu cách...) và nút "Tính" vẫn ở trạng thái cho phép 
nhấn. Khi nhấn "Tính", lệnh `double.Parse(...)` ném ra `FormatException`, làm 
chương trình treo (unhandled exception) thay vì báo lỗi thân thiện cho người dùng.
How to fix:
Phương án 1: Bổ sung sự kiện `KeyPress` cho cả hai ô số (`txtSo_KeyPress`) để 
kiểm tra từng ký tự ngay khi gõ — chỉ cho phép phím điều khiển (Backspace, 
Ctrl+...), chữ số, một dấu thập phân theo `CultureInfo` hiện hành, và một dấu 
trừ đứng đầu chuỗi; mọi ký tự khác sẽ bị chặn bằng `e.Handled = true`.
Phương án 2: Bổ sung sự kiện `TextChanged` (`txtSo_TextChanged`) để kiểm tra 
tổng thể nội dung hai ô (xử lý cả trường hợp dán văn bản). Khi một trong hai ô 
không phải số hợp lệ hoặc rỗng, đặt `btnTinh.Enabled = false` để vô hiệu hóa 
nút "Tính"; chỉ kích hoạt lại khi cả hai ô đều hợp lệ. Cả hai sự kiện được nối 
trong `Form1.Designer.cs` cho `txtSo1` và `txtSo2`.
Note: Không
