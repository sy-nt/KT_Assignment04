Developer's name: Nguyen Tien Sy
Fix date: 2026-05-25
Test case ID: TC_006
Test description: Kiểm thử phép chia khi số chia bằng 0.
Cause of the bug:
Trong sự kiện `btnTinh_Click`, chương trình chỉ xử lý phép chia khi 
`radChia.Checked && so2 != 0`. Trường hợp `so2 == 0` không có nhánh xử lý 
riêng, nên chương trình bỏ qua phép tính mà không hiển thị thông báo lỗi 
cho người dùng.
How to fix:
Trước khi thực hiện phép chia, kiểm tra điều kiện `radChia.Checked && so2 == 0`. 
Nếu đúng, hiển thị `MessageBox` thông báo "Không thể chia cho 0. Vui lòng nhập 
lại số thứ hai.", đặt `Focus` về ô "Số thứ hai", gọi `SelectAll()` để quét chọn 
nội dung, sau đó dùng `return;` để dừng việc tính toán.
Note: Không
