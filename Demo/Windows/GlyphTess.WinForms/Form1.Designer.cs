namespace Test_WinForm_TessGlyph
{
    partial class FormTess {
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
            this.cmdDrawGlyph = new System.Windows.Forms.Button();
            this.pnlGlyph = new System.Windows.Forms.Panel();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTranslate = new System.Windows.Forms.Panel();
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.statusStripOffset = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelOffset = new System.Windows.Forms.ToolStripStatusLabel();
            this.SuspendLayout();
            // 
            // cmdDrawGlyph
            // 
            this.cmdDrawGlyph.Location = new System.Drawing.Point(539, 13);
            this.cmdDrawGlyph.Name = "cmdDrawGlyph";
            this.cmdDrawGlyph.Size = new System.Drawing.Size(144, 39);
            this.cmdDrawGlyph.TabIndex = 0;
            this.cmdDrawGlyph.Text = "DrawGlyph";
            this.cmdDrawGlyph.UseVisualStyleBackColor = true;
            this.cmdDrawGlyph.Click += new System.EventHandler(this.cmdDrawGlyph_Click);
            // 
            // pnlGlyph
            // 
            this.pnlGlyph.Location = new System.Drawing.Point(7, 13);
            this.pnlGlyph.Name = "pnlGlyph";
            this.pnlGlyph.Size = new System.Drawing.Size(526, 526);
            this.pnlGlyph.TabIndex = 1;
            this.pnlGlyph.Paint += PnlGlyph_Paint;
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Location = new System.Drawing.Point(540, 59);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(53, 17);
            this.chkInvert.TabIndex = 2;
            this.chkInvert.Text = "Invert";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(540, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Single Char:";
            // 
            // pnlTranslate
            // 
            this.pnlTranslate.Location = new System.Drawing.Point(550, 225);
            this.pnlTranslate.Name = "pnlGlyph";
            this.pnlTranslate.Size = new System.Drawing.Size(150, 200);
            this.pnlTranslate.TabIndex = 5;
            this.pnlTranslate.Controls.Add(up);
            this.pnlTranslate.Controls.Add(down);
            this.pnlTranslate.Controls.Add(left);
            this.pnlTranslate.Controls.Add(right);
            this.pnlTranslate.Controls.Add(labelSpeed);
            this.pnlTranslate.Controls.Add(textSpeed);
            this.pnlTranslate.Controls.Add(statusStripOffset);
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(38, 10);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(25, 25);
            this.up.TabIndex = 6;
            this.up.Text = "^";
            this.up.UseVisualStyleBackColor = true;
            this.up.MouseUp += Up_MouseUp;
            this.up.MouseDown += Up_MouseDown;
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(38, 65);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(25, 25);
            this.down.TabIndex = 7;
            this.down.Text = "v";
            this.down.UseVisualStyleBackColor = true;
            this.down.MouseUp += Down_MouseUp;
            this.down.MouseDown += Down_MouseDown;
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(10, 38);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(25, 25);
            this.left.TabIndex = 8;
            this.left.Text = "<";
            this.left.UseVisualStyleBackColor = true;
            this.left.MouseUp += Left_MouseUp;
            this.left.MouseDown += Left_MouseDown;
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(65, 38);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(25, 25);
            this.right.TabIndex = 9;
            this.right.Text = ">";
            this.right.UseVisualStyleBackColor = true;
            this.right.MouseUp += Right_MouseUp;
            this.right.MouseDown += Right_MouseDown;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(0, 100);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(64, 13);
            this.labelSpeed.TabIndex = 10;
            this.labelSpeed.Text = "Speed:";
            // 
            // textSpeed
            // 
            this.textSpeed.Location = new System.Drawing.Point(0, 120);
            this.textSpeed.Name = "speedText";
            this.textSpeed.Size = new System.Drawing.Size(100, 20);
            this.textSpeed.TabIndex = 11;
            this.textSpeed.Text = speed.ToString();
            this.textSpeed.KeyUp += TextSpeed_KeyUp;
            // 
            // statusStripOffset
            // 
            statusStripOffset.AutoSize = true;
            statusStripOffset.Dock = System.Windows.Forms.DockStyle.Bottom;
            statusStripOffset.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            statusStripOffset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                toolStripStatusLabelOffset });
            statusStripOffset.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            statusStripOffset.Location = new System.Drawing.Point(0, 160);
            statusStripOffset.Name = "statusStripOffset";
            statusStripOffset.Size = new System.Drawing.Size(100, 50);
            statusStripOffset.ShowItemToolTips = false;
            statusStripOffset.SizingGrip = false;
            statusStripOffset.Stretch = false;
            statusStripOffset.TabIndex = 0;
            statusStripOffset.Text = "statusStripOffset";
            // 
            // toolStripStatusLabelOffset
            // 
            this.toolStripStatusLabelOffset.AutoSize = true;
            this.toolStripStatusLabelOffset.Name = "toolStripStatusLabelOffset";
            this.toolStripStatusLabelOffset.Size = new System.Drawing.Size(100, 10);
            this.toolStripStatusLabelOffset.Text = $"Offset: ({xAdj},{yAdj})";
            // 
            // FormTess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkInvert);
            this.Controls.Add(this.pnlGlyph);
            this.Controls.Add(this.cmdDrawGlyph);
            this.Controls.Add(this.pnlTranslate);
            this.Name = "FormTess";
            this.Text = "FormTess";
            this.Load += new System.EventHandler(this.FormTess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button cmdDrawGlyph;
        private System.Windows.Forms.Panel pnlGlyph;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel pnlTranslate;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.StatusStrip statusStripOffset;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOffset;
    }
}

