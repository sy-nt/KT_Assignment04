Developer's name: 22110334
Fix date: 2026-05-25
Test case ID: TC_004
Test description: Kiểm thử trường hợp người dùng đã bấm "Tính" và có kết quả hiển thị ở ô "Kết quả", sau đó cố gắng sửa trực tiếp nội dung ô "Kết quả".
Cause of the bug:
Trong `Form1.Designer.cs`, thuộc tính `Enabled` của `txtKq` không được đặt 
`false` (hoặc thiếu `ReadOnly = true`), nên ô kết quả vẫn cho phép người dùng 
chỉnh sửa sau khi tính toán. Điều này vi phạm đặc tả mục 6: nội dung ô kết 
quả không thể sửa đổi trong bất kỳ trường hợp nào, dẫn đến hiển thị sai lệch 
so với phép tính thực tế.
How to fix:
Trong `Form1.Designer.cs`, đặt `this.txtKq.Enabled = false;` khi khởi tạo 
`txtKq`. Ô kết quả chỉ được cập nhật bởi chương trình qua `txtKq.Text = ...` 
trong `btnTinh_Click`, người dùng không thể gõ hay thay đổi giá trị hiển thị.
Note: Không
