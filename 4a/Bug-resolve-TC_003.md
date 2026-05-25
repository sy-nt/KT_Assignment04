Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_003
Test description: Kiểm thử trường hợp người dùng xóa rỗng ô "Số thứ nhất" hoặc "Số thứ hai" rồi chuyển focus sang control khác (Tab hoặc Click).
Cause of the bug:
`txtSo1` và `txtSo2` không kiểm tra nội dung rỗng khi mất focus. Người dùng 
có thể để trống một ô số và chuyển sang thao tác khác mà không được nhắc nhở. 
Chỉ khi bấm "Tính", `double.Parse("")` mới ném `FormatException` và làm 
chương trình treo, vi phạm yêu cầu đặc tả mục 3: phải thông báo lỗi ngay khi 
ô mất focus và yêu cầu điều chỉnh.
How to fix:
Trong handler `txtSo_Leave` (dùng chung với TC_002), kiểm tra 
`string.IsNullOrWhiteSpace(tb.Text)` trước khi parse. Nếu ô đang trống, hiển 
thị `MessageBox` ("Vui lòng nhập số thứ nhất." hoặc "Vui lòng nhập số thứ hai."), 
gọi `Focus()` và `SelectAll()` để người dùng nhập lại ngay tại ô đó. Không cho 
phép thực hiện thao tác khác cho đến khi ô được điền hợp lệ.
Note: Không
