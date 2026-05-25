Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_005
Test description: Kiểm thử trường hợp người dùng Tab hoặc Click để đặt focus vào ô "Số thứ nhất" hoặc "Số thứ hai"; toàn bộ nội dung của ô đang focus phải được quét chọn.
Cause of the bug:
`txtSo1` và `txtSo2` không có sự kiện `Enter`, vì vậy khi người dùng chuyển 
focus vào ô số, văn bản cũ (ví dụ "0" mặc định) không được chọn. Người dùng 
phải tự bôi đen hoặc xóa thủ công trước khi gõ giá trị mới, dễ gây nhầm lẫn 
(ví dụ gõ thêm vào "0" thành "012"), vi phạm đặc tả mục 4.
How to fix:
Bổ sung sự kiện `Enter` chung (`txtSo_Enter`) cho `txtSo1` và `txtSo2`; trong 
handler ép kiểu `sender` về `TextBox` rồi gọi `tb.SelectAll()`. Người dùng chỉ 
cần Tab hoặc Click vào ô số là toàn bộ giá trị cũ được quét chọn, gõ phím số 
đầu tiên sẽ thay thế ngay. Sự kiện được đăng ký trong `Form1.Designer.cs`.
Note: Không
