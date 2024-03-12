namespace MS_Pain
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelPaint = new System.Windows.Forms.Panel();
            this.radioButtonPen = new System.Windows.Forms.RadioButton();
            this.radioButtonEraser = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonSpray = new System.Windows.Forms.RadioButton();
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonSize = new System.Windows.Forms.Button();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.radioButtonEllipse = new System.Windows.Forms.RadioButton();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonPalette = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaint
            // 
            this.panelPaint.BackColor = System.Drawing.Color.White;
            this.panelPaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPaint.Location = new System.Drawing.Point(9, 61);
            this.panelPaint.Name = "panelPaint";
            this.panelPaint.Size = new System.Drawing.Size(600, 325);
            this.panelPaint.TabIndex = 0;
            this.panelPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPaint_Paint);
            this.panelPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseDown);
            this.panelPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseMove);
            this.panelPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseUp);
            // 
            // radioButtonPen
            // 
            this.radioButtonPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonPen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPen.Location = new System.Drawing.Point(2, 2);
            this.radioButtonPen.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonPen.Name = "radioButtonPen";
            this.radioButtonPen.Size = new System.Drawing.Size(38, 41);
            this.radioButtonPen.TabIndex = 1;
            this.radioButtonPen.TabStop = true;
            this.radioButtonPen.Text = "✎";
            this.radioButtonPen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.radioButtonPen, "Pencil");
            this.radioButtonPen.UseVisualStyleBackColor = true;
            this.radioButtonPen.CheckedChanged += new System.EventHandler(this.Radio_Switch);
            // 
            // radioButtonEraser
            // 
            this.radioButtonEraser.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonEraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEraser.ForeColor = System.Drawing.Color.Red;
            this.radioButtonEraser.Location = new System.Drawing.Point(212, 2);
            this.radioButtonEraser.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonEraser.Name = "radioButtonEraser";
            this.radioButtonEraser.Size = new System.Drawing.Size(38, 41);
            this.radioButtonEraser.TabIndex = 6;
            this.radioButtonEraser.Text = "🧼";
            this.radioButtonEraser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.radioButtonEraser, "Eraser");
            this.radioButtonEraser.UseVisualStyleBackColor = true;
            this.radioButtonEraser.CheckedChanged += new System.EventHandler(this.Radio_Switch);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonSpray);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.buttonSize);
            this.panel1.Controls.Add(this.radioButtonText);
            this.panel1.Controls.Add(this.radioButtonEllipse);
            this.panel1.Controls.Add(this.radioButtonRectangle);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.buttonPalette);
            this.panel1.Controls.Add(this.radioButtonEraser);
            this.panel1.Controls.Add(this.radioButtonPen);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 46);
            this.panel1.TabIndex = 1;
            // 
            // radioButtonSpray
            // 
            this.radioButtonSpray.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonSpray.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSpray.Location = new System.Drawing.Point(170, 2);
            this.radioButtonSpray.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonSpray.Name = "radioButtonSpray";
            this.radioButtonSpray.Size = new System.Drawing.Size(38, 41);
            this.radioButtonSpray.TabIndex = 5;
            this.radioButtonSpray.TabStop = true;
            this.radioButtonSpray.Text = "🖼";
            this.radioButtonSpray.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.radioButtonSpray, "Import an image");
            this.radioButtonSpray.UseVisualStyleBackColor = true;
            this.radioButtonSpray.CheckedChanged += new System.EventHandler(this.Radio_Switch);
            // 
            // buttonFill
            // 
            this.buttonFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonFill.ForeColor = System.Drawing.Color.Black;
            this.buttonFill.Location = new System.Drawing.Point(427, 3);
            this.buttonFill.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(38, 41);
            this.buttonFill.TabIndex = 9;
            this.buttonFill.Text = "⬜";
            this.toolTip1.SetToolTip(this.buttonFill, "Fill / No fill");
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // buttonSize
            // 
            this.buttonSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonSize.ForeColor = System.Drawing.Color.Black;
            this.buttonSize.Location = new System.Drawing.Point(343, 3);
            this.buttonSize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSize.Name = "buttonSize";
            this.buttonSize.Size = new System.Drawing.Size(38, 41);
            this.buttonSize.TabIndex = 7;
            this.buttonSize.Text = "↔";
            this.toolTip1.SetToolTip(this.buttonSize, "Choose size");
            this.buttonSize.UseVisualStyleBackColor = true;
            this.buttonSize.Click += new System.EventHandler(this.buttonSize_Click);
            // 
            // radioButtonText
            // 
            this.radioButtonText.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonText.Location = new System.Drawing.Point(128, 2);
            this.radioButtonText.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(38, 41);
            this.radioButtonText.TabIndex = 4;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "A";
            this.radioButtonText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.radioButtonText, "Write text");
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.Radio_Switch);
            // 
            // radioButtonEllipse
            // 
            this.radioButtonEllipse.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEllipse.Location = new System.Drawing.Point(86, 2);
            this.radioButtonEllipse.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonEllipse.Name = "radioButtonEllipse";
            this.radioButtonEllipse.Size = new System.Drawing.Size(38, 41);
            this.radioButtonEllipse.TabIndex = 3;
            this.radioButtonEllipse.TabStop = true;
            this.radioButtonEllipse.Text = "⬭";
            this.radioButtonEllipse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.radioButtonEllipse, "Ellipse");
            this.radioButtonEllipse.UseVisualStyleBackColor = true;
            this.radioButtonEllipse.CheckedChanged += new System.EventHandler(this.Radio_Switch);
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRectangle.Location = new System.Drawing.Point(44, 2);
            this.radioButtonRectangle.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(38, 41);
            this.radioButtonRectangle.TabIndex = 2;
            this.radioButtonRectangle.TabStop = true;
            this.radioButtonRectangle.Text = "▭";
            this.radioButtonRectangle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.radioButtonRectangle, "Rectangle");
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            this.radioButtonRectangle.CheckedChanged += new System.EventHandler(this.Radio_Switch);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonClear.ForeColor = System.Drawing.Color.Red;
            this.buttonClear.Location = new System.Drawing.Point(560, 2);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(38, 41);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "🗑";
            this.toolTip1.SetToolTip(this.buttonClear, "Clear canvas");
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonPalette
            // 
            this.buttonPalette.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonPalette.ForeColor = System.Drawing.Color.Black;
            this.buttonPalette.Location = new System.Drawing.Point(385, 3);
            this.buttonPalette.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPalette.Name = "buttonPalette";
            this.buttonPalette.Size = new System.Drawing.Size(38, 41);
            this.buttonPalette.TabIndex = 8;
            this.buttonPalette.Text = "🎨";
            this.toolTip1.SetToolTip(this.buttonPalette, "Choose color");
            this.buttonPalette.UseVisualStyleBackColor = true;
            this.buttonPalette.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel1.Text = "Tool selected: ";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 25;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.png|*.jpg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 417);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPaint);
            this.Name = "Form1";
            this.Text = "Microsoft Pain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelPaint;
        private System.Windows.Forms.RadioButton radioButtonPen;
        private System.Windows.Forms.RadioButton radioButtonEraser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonPalette;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonSize;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.RadioButton radioButtonSpray;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

