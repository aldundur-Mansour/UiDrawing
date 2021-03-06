using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        //global variables
        private List<Shape> shapes;
        private Shape shape = null;
        private Pen pen;
        public DashStyle style = DashStyle.Solid;
        string type = "Line";
        bool shapeSelected = false;
        Shape selectedShape = null;
        Point captcured = new Point();
        int dx;
        int dy;
        int lineDx;
        int lineDy;
        bool isMoving = false;
        string sourceString = "";  // to be tokenized 
        bool error = false;
        bool ismoving = false;
        bool isResize = false;
        bool resizeLeft = false;
        bool resizeTop = false;
        bool resizeRight = false;
        bool resizeBottom = false;
        public Form1()
        {
            InitializeComponent();

            //default setup
            this.shapes = new List<Shape>();
            LineTypeList.SelectedIndex = 0;
            LineSize.SelectedIndex = 0;
            colorPicker.BackColor = colorDialog1.Color;
            colorDialog1.Color = Color.Black;
            pen = new Pen(colorDialog1.Color, Convert.ToInt32(LineSize.SelectedItem.ToString()));
            pen.DashStyle = DashStyle.Solid;
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (shapeSelected)
                {
                    selectedShape.penColor = colorDialog1.Color;
                    tabPage1.Invalidate();
                }
                colorPicker.BackColor = colorDialog1.Color;
                colorPicker.BackColor = colorDialog1.Color;
                pen = new Pen(colorDialog1.Color, 3);
            }
        }

        public void fileSave()
        {
            try
            {
                FileStream fs = new FileStream("draw.drw", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, shapes);
            fs.Close();
            }
            catch
            {
                MessageBox.Show("Error in file path");
            }

        }
        public void fileLoad()
        {
            try
            {
                FileStream fs = new FileStream("draw.drw", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                shapes = (List<Shape>)bf.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Error in file path");
            }
        }

        //Shape s = null;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void LineSize_SelectedValueChanged(object sender, EventArgs e)
        {
            pen = new Pen(colorDialog1.Color, Convert.ToInt32(LineSize.SelectedItem.ToString()));
        }

        private void LineTypeList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LineTypeList.SelectedItem.ToString() == "Solid")
            {
                style = DashStyle.Solid;
                
            }
            else if (LineTypeList.SelectedItem.ToString() == "Dash")
            {
                style =DashStyle.Dash;
            }
            else if (LineTypeList.SelectedItem.ToString() == "Dot")
            {
                style = DashStyle.Dot;
            }
            else if (LineTypeList.SelectedItem.ToString() == "DashDot")
            {
                style = DashStyle.DashDot;
            }
        }

        private void LineSelected_Click(object sender, EventArgs e)
        {
            type = "Line";
        }

        private void circleSelected_Click(object sender, EventArgs e)
        {
            type = "Circle";
        }

        private void squSelected_Click(object sender, EventArgs e)
        {
            type = "Rect";
        }

        private void selectShape(Graphics g, Shape shape)
        {

            if (shape.type == "Line")
            {
                Rectangle rec = new Rectangle(shape.startPoint.X, shape.startPoint.Y, 2, 2);
                Rectangle rec2 = new Rectangle(shape.endPoint.X, shape.endPoint.Y, 2, 2);
                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = DashStyle.Solid;
                g.DrawRectangle(pen, rec);
                g.DrawRectangle(pen, rec2);
            }
            else
            {
                Rectangle rec = new Rectangle(shape.startPoint.X, shape.startPoint.Y, shape.width, shape.height);
                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = DashStyle.Dot;
                g.DrawRectangle(pen, rec);
            }
        }

        public bool isActive(Point p)
        {
            foreach (var s in shapes)
            {
                if (s.bounds.Contains(p))
                {
                    selectedShape = s;
                    return true;
                }
            }
            return false;
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            //draw all shapes 
            Graphics g = e.Graphics;
            foreach (var s in shapes)
            {
                s.Draw(g);
            }

            //draw a rectangle around the selected shape
            if (shapeSelected)
            {
                selectShape(g, selectedShape);
            }
        }
         
        private void tabPage1_MouseDown(object sender, MouseEventArgs e)
        {
            captcured.X = e.X;
            captcured.Y = e.Y;
            Point p = new Point();
            p.X = e.X;
            p.Y = e.Y;
            if (isActive(captcured))
            {
                if (selectedShape.getLeftBorder().Contains(p))
                {
                    isResize = true;
                    resizeLeft = true;
                    resizeTop = false;
                    resizeRight = false;
                    resizeBottom = false;
                    ismoving = false;
                }
                else if (selectedShape.getTopBorder().Contains(p))
                {
                    isResize = true;
                    resizeTop = true;
                    resizeRight = false;
                    resizeLeft = false;
                    resizeBottom = false;
                    ismoving = false;
                }
                else if (selectedShape.getBottomBorder().Contains(p))
                {
                    isResize = true;
                    resizeBottom = true;
                    resizeTop = false;
                    resizeRight = false;
                    resizeLeft = false;
                    ismoving = false;
                }
                else if (selectedShape.getRightBorder().Contains(p))
                {
                    isResize = true;
                    resizeRight = true;
                    resizeBottom = false;
                    resizeTop = false;
                    resizeLeft = false;
                    ismoving = false;
                }
                else
                {
                    shapeSelected = true;
                    ismoving = true;
                }
                selectedShape.dx = e.X - selectedShape.startPoint.X;
                selectedShape.dy = e.Y - selectedShape.startPoint.Y;
                selectedShape.lineDx = e.X - selectedShape.endPoint.X;
                selectedShape.lineDy = e.Y - selectedShape.endPoint.Y;
                tabPage1.Invalidate();
            }
            else
            {
                shapeSelected = false;
                selectedShape = null;
                ismoving = false;
                tabPage1.Invalidate();
            }
            if (!ismoving)
            {
                if (type == "Line")
                {
                    shape = new Line();
                    shape.type = "Line";
                }
                else if (type == "Rect")
                {
                    shape = new Rect();
                    shape.type = "Rect";
                }
                else if (type == "Circle")
                {
                    shape = new Circle();
                    shape.type = "Circle";
                }
                shape.penColor = colorDialog1.Color;
                shape.thickness = Convert.ToInt32(LineSize.SelectedItem.ToString());
                shape.startPoint.X = e.X;
                shape.startPoint.Y = e.Y;
            }
            else
            {
                shape = null;
            }



        }

        private void tabPage1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isMoving && !shapeSelected)
            {
                shape.endPoint.X = e.X;
                shape.endPoint.Y = e.Y;
                shape.width = shape.endPoint.X - shape.startPoint.X;
                shape.height = shape.endPoint.Y - shape.startPoint.Y;
                shape.style = style;
                if(shape.startPoint != shape.endPoint)
                {
                    shapes.Add(shape);
                }
                

            }
            ismoving = false;
            isResize = false;
            resizeLeft = false;
            resizeTop = false;
            resizeBottom = false;
            resizeRight = false;
           
            
            isMoving = false;
         
            

            tabPage1.Invalidate();
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point();
            p.X = e.X;
            p.Y = e.Y;
            if (ismoving)
            {
                selectedShape.move(p);
                tabPage1.Invalidate();
            }
            if (shapeSelected)
            {
                if (selectedShape.getLeftBorder().Contains(p) || selectedShape.getRightBorder().Contains(p))
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else if (selectedShape.getTopBorder().Contains(p) || selectedShape.getBottomBorder().Contains(p))
                {
                    this.Cursor = Cursors.SizeNS;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
                if (isResize)
                {
                    if (resizeLeft)
                    {
                        selectedShape.resizeFromLeft(p);
                        tabPage1.Invalidate();
                    }
                    if (resizeTop)
                    {
                        selectedShape.resizeFromTop(p);
                        tabPage1.Invalidate();
                    }
                    if (resizeRight)
                    {
                        selectedShape.resizeFromRight(p);
                        tabPage1.Invalidate();
                    }
                    if (resizeBottom)
                    {
                        selectedShape.resizeFromBottom(p);
                        tabPage1.Invalidate();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sourceString = textBox1.Text; // we take th strinf from the textbox 
         //   Debug.WriteLine(sourceString);

        }

        public List<Shape> lsShapes(string s)
        {
                s = s.TrimEnd(); 
                Debug.WriteLine(s);
                List<Shape> ls5 = new List<Shape>();
                //string s5 = "rec(0,0,0,0)Pen(blue,5,dot,true);\r\nrec(100,100,200,200)Pen(blue,5,dot,true);";
                List<string> ls = new List<string>();
                string dim = "";
                foreach (var item in s.Split(Environment.NewLine))
                {
                    ls.Add(item);
                }
                Shape sh = new Circle();
                foreach (var item in ls)
                {
           
                    string st = item[0..3];
                    if (st.ToUpper() == "REC")
                    {
                        sh = new Rect();
                    }
                    else if (st.ToUpper() == "LIN")
                    {
                        sh = new Line();
                    }
                    else if (st.ToUpper() == "CRC")
                    {
                        sh = new Circle();
                    }
                    int i = 4;
                    dim = "";
                    while (item[i] != ')')
                    {
                        dim += item[i];
                        i++;
                    }
                    string[] str = dim.Split(',');
                    sh.startPoint.X = Convert.ToInt32(str[0]);
                    sh.startPoint.Y = Convert.ToInt32(str[1]);
                    sh.endPoint.X = Convert.ToInt32(str[2]);
                    sh.endPoint.Y = Convert.ToInt32(str[3]);
                    i += 5;
                    string str2 = "";
                    while (item[i] != ')')
                    {
                        str2 += item[i];
                        i++;
                    }
                    string[] str3 = str2.Split(',');
                    sh.penColor = Color.FromName(str3[0]); //to be fixed to get from hex
                    sh.thickness = Convert.ToInt32(str3[1]);
                    if (str3[2].ToUpper() == "DOT")
                    {
                        sh.style = DashStyle.Dot;
                    }
                    else if (str3[2].ToUpper() == "DASH")
                    {
                        sh.style = DashStyle.Dash;
                    }
                    else if (str3[2].ToUpper() == "SOLID")
                    {
                        sh.style = DashStyle.Solid;
                    }
                    else if (str3[2].ToUpper() == "DASHDOT")
                    {
                        sh.style = DashStyle.DashDot;
                    }
                    sh.fill = bool.Parse(str3[3]);
                    sh.width = sh.endPoint.X - sh.startPoint.X;
                    sh.height = sh.endPoint.Y - sh.startPoint.Y;
                    Debug.WriteLine("mr" + sh.style);
                    ls5.Add(sh);
                    
                    //shapes.Add(sh); 
                    //Console.WriteLine($"{color} , {thikness} , {style} , {fill}");
                
                }
           
            return ls5;
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                Debug.WriteLine(sourceString);
                if (sourceString.Length > 5)
                {
                    try
                    {
                        List<Shape> ehj = lsShapes(sourceString);
                        textBox1.Text = str;
                        shapes = new List<Shape>();
                        foreach (var item in ehj)
                        {
                            shapes.Add(item);

                        }
                    }catch
                    {

                    }
                 
                    tabPage1.Invalidate();
                }
                
                
                //  sourceString = sourceString.Trim();
                Tokenizer t = new Tokenizer(new Input(sourceString.Trim()), new Tokenizable[] {
                     new NewLineTokenizer(true),
                     new sourceCodeTokenozer()
               
            });
                Token token = t.tokenize();
                error = false;
                while (token != null && t.input.hasMore())
                {
                    if(token.Value == "invalid" && t.input.hasMore())
                    {
                     
                       
                        MessageBox.Show("ERROR! in the source code at line :" + token.LineNumber);
                        error = true;
                        tabPage1.Hide();
                        break; 

                    }
                     
                   
                    token = t.tokenize();
                }



            }
            else
            {
                textBox1.Text = str;
                if (!error)
                {
                    textBox1.Clear();
             
                    foreach (var s in shapes)
                    {

                        string sourceCode = "";

                        if (s is Line)
                        {

                            sourceCode += $"Lin({s.startPoint.X},{s.startPoint.Y},{s.endPoint.X},{s.endPoint.Y})Pen({s.penColor.Name},{s.thickness},{s.style},{s.fill});";

                            textBox1.AppendText(sourceCode + Environment.NewLine);
                            sourceCode = "";
                        }
                        else if (s is Circle)
                        {
                            sourceCode += $"Crc({s.startPoint.X},{s.startPoint.Y},{s.endPoint.X},{s.endPoint.Y})Pen({s.penColor.Name},{s.thickness},{s.style},{s.fill});";
                            textBox1.AppendText(sourceCode + Environment.NewLine);
                            sourceCode = "";
                        }
                        else
                        {
                            sourceCode += $"Rec({s.startPoint.X},{s.startPoint.Y},{s.endPoint.X},{s.endPoint.Y})Pen({s.penColor.Name},{s.thickness},{s.style},{s.fill});";
                            textBox1.AppendText(sourceCode + Environment.NewLine);
                            sourceCode = "";
                        }
                    }
                    textBox1.Invalidate();
                    if (str == "")
                    {
                        str = sourceString;
                    }
                    
                }
                

                  
                
            }
        }
        string str = "";
        private void clear_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            tabPage1.Invalidate();
        }

        private void fill_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                selectedShape.fill = true;
            }
            tabPage1.Invalidate();
        }

        private void save_Click(object sender, EventArgs e)
        {
            fileSave();
        }

        private void open_Click(object sender, EventArgs e)
        {
            fileLoad();
            tabPage1.Invalidate();
        }
    }
    [Serializable()]
    public abstract class Shape
    {
        public Color penColor;
        public bool fill;
        public int thickness;
        public DashStyle style;
        public Point startPoint;
        public Point endPoint;
        public RectangleF bounds;
        public string type;
        public int width;
        public int height;
        public int dx;
        public int dy;
        public int lineDx;
        public int lineDy;
        public bool isFill;
        public List<Point> linePoints { set; get; }
        public abstract void Draw(Graphics g);
        public abstract void move(Point point);
        public void resizeFromLeft(Point point)
        {
            if (point.X < this.startPoint.X)
            {
                int dif = this.startPoint.X - point.X;
                this.startPoint.X = point.X;
                this.width += dif;
            }
            else if (point.X > this.startPoint.X)
            {
                int dif = point.X - this.startPoint.X;
                this.startPoint.X = point.X;
                this.width -= dif;
            }
        }
        public void resizeFromRight(Point point)
        {
            this.endPoint.X = point.X;
            this.width = this.endPoint.X - this.startPoint.X; ;
            //this.height = this.endPoint.Y - this.startPoint.Y;
        }
        public void resizeFromTop(Point point)
        {
            this.startPoint.Y = point.Y;
            //this.width = this.endPoint.X - this.startPoint.X;
            this.height = this.endPoint.Y - this.startPoint.Y;
        }
        public void resizeFromBottom(Point point)
        {
            this.endPoint.Y = point.Y;
            //this.width = this.endPoint.X - this.startPoint.X;
            this.height = this.endPoint.Y - this.startPoint.Y;
        }
        public List<Point> getLeftBorder()
        {
            List<Point> leftBorderPoints = new List<Point>();
            Point point = new Point();
            int i = 0;
            while (i < this.height)
            {
                point.X = this.startPoint.X;
                point.Y = this.startPoint.Y + i;
                leftBorderPoints.Add(point);
                i++;
            }
            return leftBorderPoints;
        }
        public List<Point> getRightBorder()
        {
            List<Point> RightBorderPoints = new List<Point>();
            Point point = new Point();
            int i = 0;
            while (i < this.startPoint.Y + this.height)
            {
                point.X = (this.startPoint.X + this.width) - 2;
                point.Y = this.startPoint.Y + i;
                RightBorderPoints.Add(point);
                i++;
            }
            return RightBorderPoints;
        }
        public List<Point> getTopBorder()
        {
            List<Point> topBorderPoints = new List<Point>();
            Point point = new Point();
            int i = 0;
            while (i < (this.startPoint.X + this.width))
            {
                point.X = this.startPoint.X + i;
                point.Y = this.startPoint.Y;
                topBorderPoints.Add(point);
                i++;
            }
            return topBorderPoints;
        }
        public List<Point> getBottomBorder()
        {
            List<Point> topBorderPoints = new List<Point>();
            Point point = new Point();
            int i = 0;
            while (i < (this.startPoint.X + this.width))
            {
                point.X = this.startPoint.X + i;
                point.Y = this.startPoint.Y + this.height - 2;
                topBorderPoints.Add(point);
                i++;
            }
            return topBorderPoints;
        }
    }
    [Serializable()]
    public class Line : Shape
    {
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(this.penColor, this.thickness);
            pen.DashStyle = this.style;
            g.DrawLine(pen, this.startPoint.X, this.startPoint.Y, this.endPoint.X, this.endPoint.Y);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(this.startPoint, this.endPoint);
            bounds = path.GetBounds();
        }
        public override void move(Point point)
        {
            this.startPoint.X = point.X - this.dx;
            this.startPoint.Y = point.Y - this.dy;
            this.endPoint.X = point.X - this.lineDx;
            this.endPoint.Y = point.Y - this.lineDy;
        }
    }
    [Serializable()]
    public class Circle : Shape
    {
        public override void Draw(Graphics g)
        {
            Rectangle rec = new Rectangle(this.startPoint.X, this.startPoint.Y, this.width, this.height);
            Pen pen = new Pen(this.penColor, this.thickness);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rec);
            bounds = path.GetBounds();
            pen.DashStyle = this.style;
            g.DrawEllipse(pen, rec);
            if (this.fill)
            {
                g.FillEllipse(new SolidBrush(this.penColor), rec);
            }


        }
        public override void move(Point point)
        {
            this.startPoint.X = point.X - this.dx;
            this.startPoint.Y = point.Y - this.dy;
        }

    }
    [Serializable()]
    public class Rect : Shape
    {
        public override void Draw(Graphics g)
        {

            Rectangle rec = new Rectangle(this.startPoint.X, this.startPoint.Y, this.width, this.height);
            Pen pen = new Pen(this.penColor, this.thickness);
            pen.DashStyle = this.style;
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rec);
            bounds = path.GetBounds();
            g.DrawRectangle(pen, rec);
            if (this.fill)
            {
                g.FillRectangle(new SolidBrush(this.penColor), rec);
                
            }

        }
        public override void move(Point point)
        {
            this.startPoint.X = point.X - this.dx;
            this.startPoint.Y = point.Y - this.dy;
        }
    }


}
