Họ và tên: Nguyễn Đức Hòa
Mã số sinh viên: 21424019
Đề tài: Project Paint
Thư mục release nằm ở đường dẫn: 21424019\ProjectPaint\Paint\bin\Debug\net7.0-windows7.0
Các chức năng đã thực hiện:
1. Dynamically load all graphic objects that can be drawn from external DLL files
2. The user can choose which object to draw ( circle, ellipse, line, rectangle, square).
3. The user can see the preview of the object they want to draw
4. The user can finish the drawing preview and their change becomes permanent with previously drawn objects
5. The list of drawn objects can be saved and loaded again for continuing later
    
6. Save and load all drawn objects as an image in bmp/png/jpg format (rasterization). Just one format is fine. No need to save in all three formats.
7. Function improvement:
- Allow the user to change the color, pen width, stroke type (dash, dot, dash dot dot
- Select a single element for editing again Transforming horizontally and vertically Rotate the image
- Cut / Copy / Paste / Delete
- Undo, Redo (Command)
- Use Visitor design pattern (Suggestion: save objects into text file / xml file / json file / binary file)
- Import / export / new file