
namespace Draw
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.colorPicker = new System.Windows.Forms.Button();
            this.squSelected = new System.Windows.Forms.Button();
            this.circleSelected = new System.Windows.Forms.Button();
            this.LineSelected = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LineSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LineTypeList = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.colorPicker);
            this.groupBox1.Controls.Add(this.squSelected);
            this.groupBox1.Controls.Add(this.circleSelected);
            this.groupBox1.Controls.Add(this.LineSelected);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LineSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LineTypeList);
            this.groupBox1.Location = new System.Drawing.Point(2, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(117, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Color";
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(55, 253);
            this.colorPicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(27, 31);
            this.colorPicker.TabIndex = 0;
            this.colorPicker.UseVisualStyleBackColor = true;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // squSelected
            // 
            this.squSelected.Location = new System.Drawing.Point(75, 55);
            this.squSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.squSelected.Name = "squSelected";
            this.squSelected.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.squSelected.Size = new System.Drawing.Size(33, 44);
            this.squSelected.TabIndex = 1;
            this.squSelected.Text = "R";
            this.squSelected.UseVisualStyleBackColor = true;
            this.squSelected.Click += new System.EventHandler(this.squSelected_Click);
            // 
            // circleSelected
            // 
            this.circleSelected.Location = new System.Drawing.Point(42, 55);
            this.circleSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.circleSelected.Name = "circleSelected";
            this.circleSelected.Size = new System.Drawing.Size(32, 44);
            this.circleSelected.TabIndex = 1;
            this.circleSelected.Text = "C";
            this.circleSelected.UseVisualStyleBackColor = true;
            this.circleSelected.Click += new System.EventHandler(this.circleSelected_Click);
            // 
            // LineSelected
            // 
            this.LineSelected.Location = new System.Drawing.Point(6, 55);
            this.LineSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LineSelected.Name = "LineSelected";
            this.LineSelected.Size = new System.Drawing.Size(34, 44);
            this.LineSelected.TabIndex = 1;
            this.LineSelected.Text = "L";
            this.LineSelected.UseVisualStyleBackColor = true;
            this.LineSelected.Click += new System.EventHandler(this.LineSelected_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Shapes:";
            // 
            // LineSize
            // 
            this.LineSize.FormattingEnabled = true;
            this.LineSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.LineSize.Location = new System.Drawing.Point(7, 129);
            this.LineSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LineSize.Name = "LineSize";
            this.LineSize.Size = new System.Drawing.Size(81, 28);
            this.LineSize.TabIndex = 4;
            this.LineSize.SelectedValueChanged += new System.EventHandler(this.LineSize_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Line Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Line Type";
            // 
            // LineTypeList
            // 
            this.LineTypeList.FormattingEnabled = true;
            this.LineTypeList.Items.AddRange(new object[] {
            "Solid",
            "Dot",
            "Dash",
            "DashDot"});
            this.LineTypeList.Location = new System.Drawing.Point(7, 204);
            this.LineTypeList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LineTypeList.Name = "LineTypeList";
            this.LineTypeList.Size = new System.Drawing.Size(82, 28);
            this.LineTypeList.TabIndex = 1;
            this.LineTypeList.SelectedValueChanged += new System.EventHandler(this.LineTypeList_SelectedValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(139, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 480);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Drawings";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage1_Paint);
            this.tabPage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseDown);
            this.tabPage1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseMove);
            this.tabPage1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(735, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Source ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(27, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(445, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Syntax: Shape(x,y,width,height) ; Pen (Color,Thickness,Style,IsFilled)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Write your code here";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Location = new System.Drawing.Point(27, 65);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(673, 347);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button colorPicker;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LineTypeList;
        private System.Windows.Forms.ComboBox LineSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button squSelected;
        private System.Windows.Forms.Button circleSelected;
        private System.Windows.Forms.Button LineSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}

