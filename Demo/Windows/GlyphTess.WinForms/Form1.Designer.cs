﻿namespace Test_WinForm_TessGlyph
{
    partial class FormTess
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
            this.cmdDrawGlyph = new System.Windows.Forms.Button();
            this.pnlGlyph = new System.Windows.Forms.Panel();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // FormTess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkInvert);
            this.Controls.Add(this.pnlGlyph);
            this.Controls.Add(this.cmdDrawGlyph);
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
    }
}

