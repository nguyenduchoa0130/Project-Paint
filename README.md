## Đề tài: Project Paint
### Họ và tên: Nguyễn Đức Hòa
### Mã số sinh viên: 21424019
Thư mục release nằm ở đường dẫn: 21424019\ProjectPaint\Paint\bin\Debug\net7.0-windows7.0
Các chức năng đã thực hiện:
1. Dynamically load all graphic objects that can be drawn from external DLL files
2. The user can choose which object to draw ( circle, ellipse, line, rectangle, square, triangle).
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


### Technical details
- C# Winform Net 7.0
- Design patterns: Singleton, Factory, Abstract factory, prototype
- Plugin architecture
- Delegate & event
### Install app:
1. Rum app
```
    ProjectPaint\Setup1\Debug\Setup1.msi
```

2. Copy folder shapes and place it on folder which was used to install app
```
    ProjectPaint\shapes
```
3. Run file .exe in install folder:
```
    Paint.exe
```
### Features:
1/ Draw shape:
  ![dashboard](./Overview/1.png)


2/ Edit mode: move, rotate
    ![dashboard](./Overview/2.png)

3/ Save image
    ![dashboard](./Overview/3.png)

4/ Edit with image which is imported by brower
    ![dashboard](./Overview/4.png)

Link github: https://github.com/nguyenduchoa0130/Project-Paint
