
namespace ManagerUI
{
    partial class VipFormAddUpdate
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
            this.cboXB = new System.Windows.Forms.ComboBox();
            this.cboDJ = new System.Windows.Forms.ComboBox();
            this.dtpRQ = new System.Windows.Forms.DateTimePicker();
            this.txtDH = new System.Windows.Forms.TextBox();
            this.txtXM = new System.Windows.Forms.TextBox();
            this.txtBH = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboXB
            // 
            this.cboXB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboXB.FormattingEnabled = true;
            this.cboXB.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboXB.Location = new System.Drawing.Point(306, 85);
            this.cboXB.Name = "cboXB";
            this.cboXB.Size = new System.Drawing.Size(158, 28);
            this.cboXB.TabIndex = 63;
            // 
            // cboDJ
            // 
            this.cboDJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDJ.FormattingEnabled = true;
            this.cboDJ.Location = new System.Drawing.Point(306, 27);
            this.cboDJ.Name = "cboDJ";
            this.cboDJ.Size = new System.Drawing.Size(158, 28);
            this.cboDJ.TabIndex = 62;
            // 
            // dtpRQ
            // 
            this.dtpRQ.Location = new System.Drawing.Point(306, 141);
            this.dtpRQ.Name = "dtpRQ";
            this.dtpRQ.Size = new System.Drawing.Size(158, 27);
            this.dtpRQ.TabIndex = 61;
            // 
            // txtDH
            // 
            this.txtDH.Location = new System.Drawing.Point(93, 143);
            this.txtDH.Name = "txtDH";
            this.txtDH.Size = new System.Drawing.Size(131, 27);
            this.txtDH.TabIndex = 60;
            // 
            // txtXM
            // 
            this.txtXM.Location = new System.Drawing.Point(93, 85);
            this.txtXM.Name = "txtXM";
            this.txtXM.Size = new System.Drawing.Size(131, 27);
            this.txtXM.TabIndex = 59;
            // 
            // txtBH
            // 
            this.txtBH.Location = new System.Drawing.Point(93, 27);
            this.txtBH.Name = "txtBH";
            this.txtBH.ReadOnly = true;
            this.txtBH.Size = new System.Drawing.Size(131, 27);
            this.txtBH.TabIndex = 58;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(239)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(371, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 27);
            this.button1.TabIndex = 57;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(239)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(251, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 27);
            this.button2.TabIndex = 56;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "到期时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 54;
            this.label5.Text = "会员性别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "会员等级";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "会员姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "联系电话";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "会员编号";
            // 
            // VipFormAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(495, 253);
            this.Controls.Add(this.cboXB);
            this.Controls.Add(this.cboDJ);
            this.Controls.Add(this.dtpRQ);
            this.Controls.Add(this.txtDH);
            this.Controls.Add(this.txtXM);
            this.Controls.Add(this.txtBH);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VipFormAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员编辑";
            this.Load += new System.EventHandler(this.VipFormAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboXB;
        private System.Windows.Forms.ComboBox cboDJ;
        private System.Windows.Forms.DateTimePicker dtpRQ;
        private System.Windows.Forms.TextBox txtDH;
        private System.Windows.Forms.TextBox txtXM;
        private System.Windows.Forms.TextBox txtBH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}