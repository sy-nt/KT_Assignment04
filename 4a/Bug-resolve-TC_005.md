Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_005
Test description: Kiểm thử trải nghiệm bàn phím: (1) sau khi nhập xong số, nhấn phím Enter phải kích hoạt nút "Tính"; (2) khi Tab/Click vào ô "Số thứ nhất" hoặc "Số thứ hai", toàn bộ nội dung của ô phải được quét chọn để dễ thay thế.
Cause of the bug:
Trong `Form1.Designer.cs`, thuộc tính `AcceptButton` của Form không được gán 
cho `btnTinh`, nên nhấn Enter không kích hoạt nút "Tính" — người dùng buộc phải 
dùng chuột. Đồng thời `txtSo1` và `txtSo2` không có sự kiện `Enter`, vì vậy khi 
chuyển focus vào ô số, văn bản cũ không được chọn; người dùng phải tự bôi đen 
hoặc xóa thủ công trước khi gõ giá trị mới, dễ gây nhầm lẫn (ví dụ gõ thêm vào 
chuỗi "0" mặc định thành "012").
How to fix:
Phương án 1 (phím Enter): Trong `Form1.Designer.cs`, đặt 
`this.AcceptButton = this.btnTinh;` ở phần khởi tạo Form. Khi đó, ở bất kỳ ô 
nào (trừ control nuốt phím Enter), nhấn Enter sẽ gọi `btnTinh.PerformClick()` 
và thực hiện tính toán cùng các bước kiểm tra của TC_001/TC_002/TC_003.
Phương án 2 (quét chọn nội dung): Bổ sung sự kiện `Enter` chung 
(`txtSo_Enter`) cho `txtSo1` và `txtSo2`; trong handler ép kiểu sender về 
`TextBox` rồi gọi `tb.SelectAll()`. Người dùng chỉ cần Tab hoặc Click vào ô 
số là toàn bộ giá trị cũ được chọn, gõ phím số đầu tiên sẽ thay thế ngay.
Note: Không
