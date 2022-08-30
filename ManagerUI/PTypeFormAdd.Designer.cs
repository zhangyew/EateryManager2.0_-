
namespace ManagerUI
{
    partial class PTypeFormAdd
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
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.cboLB = new System.Windows.Forms.ComboBox();
            this.txtJP = new System.Windows.Forms.TextBox();
            this.txtXS = new System.Windows.Forms.TextBox();
            this.txtMC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(239)))));
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.Location = new System.Drawing.Point(149, 232);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 30);
            this.button11.TabIndex = 29;
            this.button11.Text = "取消";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(239)))));
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.Location = new System.Drawing.Point(31, 232);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 30);
            this.button12.TabIndex = 28;
            this.button12.Text = "保存";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // cboLB
            // 
            this.cboLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLB.FormattingEnabled = true;
            this.cboLB.Location = new System.Drawing.Point(103, 181);
            this.cboLB.Name = "cboLB";
            this.cboLB.Size = new System.Drawing.Size(121, 28);
            this.cboLB.TabIndex = 27;
            // 
            // txtJP
            // 
            this.txtJP.Location = new System.Drawing.Point(103, 83);
            this.txtJP.Name = "txtJP";
            this.txtJP.ReadOnly = true;
            this.txtJP.Size = new System.Drawing.Size(119, 27);
            this.txtJP.TabIndex = 26;
            // 
            // txtXS
            // 
            this.txtXS.Location = new System.Drawing.Point(103, 132);
            this.txtXS.Name = "txtXS";
            this.txtXS.Size = new System.Drawing.Size(119, 27);
            this.txtXS.TabIndex = 25;
            this.txtXS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXS_KeyPress);
            // 
            // txtMC
            // 
            this.txtMC.Location = new System.Drawing.Point(103, 34);
            this.txtMC.Name = "txtMC";
            this.txtMC.Size = new System.Drawing.Size(119, 27);
            this.txtMC.TabIndex = 24;
            this.txtMC.TextChanged += new System.EventHandler(this.txtMC_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "销售价格：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "商品类别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "商品简拼：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "商品名称：";
            // 
            // PTypeFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(259, 292);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.cboLB);
            this.Controls.Add(this.txtJP);
            this.Controls.Add(this.txtXS);
            this.Controls.Add(this.txtMC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PTypeFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加商品";
            this.Load += new System.EventHandler(this.PTypeFormAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox cboLB;
        private System.Windows.Forms.TextBox txtJP;
        private System.Windows.Forms.TextBox txtXS;
        private System.Windows.Forms.TextBox txtMC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}