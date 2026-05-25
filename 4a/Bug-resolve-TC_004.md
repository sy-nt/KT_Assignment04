Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_004
Test description: Kiểm thử trường hợp người dùng đã nhấn "Tính" để xem kết quả, sau đó thay đổi giá trị ở ô "Số thứ nhất" hoặc "Số thứ hai"; ô "Kết quả" phải được làm trống để tránh hiển thị giá trị cũ không còn đúng với dữ liệu nhập mới.
Cause of the bug:
Sau khi gán `txtKq.Text = kq.ToString();`, ứng dụng không có cơ chế nào để 
phát hiện khi nội dung của `txtSo1` hoặc `txtSo2` thay đổi. Vì vậy ô kết quả 
vẫn giữ giá trị cũ; người dùng dễ hiểu nhầm rằng kết quả đó tương ứng với 
dữ liệu họ vừa chỉnh sửa, dẫn đến quyết định sai dựa trên kết quả lỗi thời.
How to fix:
Bổ sung sự kiện `TextChanged` cho `txtSo1` và `txtSo2` (`txtSo_TextChanged`) 
và trong handler đặt `txtKq.Text = string.Empty;`. Khi người dùng vừa gõ một 
ký tự vào bất kỳ ô số nào, kết quả cũ bị xóa ngay lập tức; người dùng phải 
bấm "Tính" lại để có kết quả mới khớp với dữ liệu hiện tại. Sự kiện này được 
đăng ký trong `Form1.Designer.cs` cùng với `KeyPress` (TC_002) để dùng chung 
một nơi kiểm soát đầu vào.
Note: Không
