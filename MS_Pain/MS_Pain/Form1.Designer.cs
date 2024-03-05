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
            this.buttonPen = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonArrow = new System.Windows.Forms.Button();
            this.buttonEllipse = new System.Windows.Forms.Button();
            this.buttonScrap = new System.Windows.Forms.Button();
            this.buttonEraser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonPen
            // 
            this.buttonPen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPen.Location = new System.Drawing.Point(12, 12);
            this.buttonPen.Name = "buttonPen";
            this.buttonPen.Size = new System.Drawing.Size(50, 50);
            this.buttonPen.TabIndex = 0;
            this.buttonPen.Text = "✎";
            this.buttonPen.UseVisualStyleBackColor = true;
            this.buttonPen.Click += new System.EventHandler(this.buttonPen_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRectangle.Location = new System.Drawing.Point(68, 12);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(50, 50);
            this.buttonRectangle.TabIndex = 1;
            this.buttonRectangle.Text = "⬜";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonArrow
            // 
            this.buttonArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonArrow.Location = new System.Drawing.Point(180, 12);
            this.buttonArrow.Name = "buttonArrow";
            this.buttonArrow.Size = new System.Drawing.Size(50, 50);
            this.buttonArrow.TabIndex = 2;
            this.buttonArrow.Text = "⇨";
            this.buttonArrow.UseVisualStyleBackColor = true;
            this.buttonArrow.Click += new System.EventHandler(this.buttonArrow_Click);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEllipse.Location = new System.Drawing.Point(124, 12);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Size = new System.Drawing.Size(50, 50);
            this.buttonEllipse.TabIndex = 3;
            this.buttonEllipse.Text = "⭘";
            this.buttonEllipse.UseVisualStyleBackColor = true;
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipse_Click);
            // 
            // buttonScrap
            // 
            this.buttonScrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonScrap.Location = new System.Drawing.Point(292, 12);
            this.buttonScrap.Name = "buttonScrap";
            this.buttonScrap.Size = new System.Drawing.Size(50, 50);
            this.buttonScrap.TabIndex = 4;
            this.buttonScrap.Text = "🗑";
            this.buttonScrap.UseVisualStyleBackColor = true;
            this.buttonScrap.Click += new System.EventHandler(this.buttonScrap_Click);
            // 
            // buttonEraser
            // 
            this.buttonEraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEraser.Location = new System.Drawing.Point(236, 12);
            this.buttonEraser.Name = "buttonEraser";
            this.buttonEraser.Size = new System.Drawing.Size(50, 50);
            this.buttonEraser.TabIndex = 5;
            this.buttonEraser.Text = "🧼";
            this.buttonEraser.UseVisualStyleBackColor = true;
            this.buttonEraser.Click += new System.EventHandler(this.buttonEraser_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 600);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 702);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonEraser);
            this.Controls.Add(this.buttonScrap);
            this.Controls.Add(this.buttonEllipse);
            this.Controls.Add(this.buttonArrow);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonPen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPen;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonArrow;
        private System.Windows.Forms.Button buttonEllipse;
        private System.Windows.Forms.Button buttonScrap;
        private System.Windows.Forms.Button buttonEraser;
        private System.Windows.Forms.Panel panel1;
    }
}

