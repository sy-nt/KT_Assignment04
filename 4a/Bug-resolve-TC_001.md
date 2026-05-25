Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_001
Test description: Kiểm thử trường hợp người dùng chọn phép chia và nhập "Số thứ hai" bằng 0 rồi bấm nút "Tính".
Cause of the bug: 
Trong sự kiện `btnTinh_Click`, điều kiện `else if (radChia.Checked && so2 != 0)` 
khiến chương trình bỏ qua phép tính khi chia cho 0 mà không phản hồi cho người dùng. 
Người dùng không biết lỗi đã xảy ra, ô kết quả vẫn hiển thị giá trị mặc định `0`, 
gây hiểu nhầm rằng phép tính đã được thực hiện hợp lệ.
How to fix:
Trước khi thực hiện phép tính, kiểm tra trường hợp `radChia.Checked && so2 == 0`. 
Nếu đúng, hiển thị `MessageBox` thông báo "Không thể chia cho 0. Vui lòng nhập lại 
số thứ hai.", sau đó đặt `Focus` lại vào ô `txtSo2` và gọi `txtSo2.SelectAll()` để 
quét chọn toàn bộ nội dung, giúp người dùng thay thế giá trị ngay lập tức. Lệnh 
`return;` chặn không cho phép tính tiếp tục để tránh ghi giá trị sai lên ô kết quả.
Note: Không
