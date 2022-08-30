
namespace ManagerUI
{
    partial class RoomFormUpdate
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbDZ = new System.Windows.Forms.CheckBox();
            this.txtRS = new System.Windows.Forms.TextBox();
            this.txtXF = new System.Windows.Forms.TextBox();
            this.txtMC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "容纳人数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "最低消费：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "房间名称：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbDZ);
            this.panel1.Location = new System.Drawing.Point(9, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 50);
            this.panel1.TabIndex = 27;
            // 
            // cbDZ
            // 
            this.cbDZ.AutoSize = true;
            this.cbDZ.Location = new System.Drawing.Point(18, 13);
            this.cbDZ.Name = "cbDZ";
            this.cbDZ.Size = new System.Drawing.Size(211, 24);
            this.cbDZ.TabIndex = 19;
            this.cbDZ.Text = "消费时是否对会员开启折扣";
            this.cbDZ.UseVisualStyleBackColor = true;
            // 
            // txtRS
            // 
            this.txtRS.Location = new System.Drawing.Point(96, 124);
            this.txtRS.Name = "txtRS";
            this.txtRS.Size = new System.Drawing.Size(172, 27);
            this.txtRS.TabIndex = 26;
            // 
            // txtXF
            // 
            this.txtXF.Location = new System.Drawing.Point(96, 73);
            this.txtXF.Name = "txtXF";
            this.txtXF.Size = new System.Drawing.Size(172, 27);
            this.txtXF.TabIndex = 25;
            // 
            // txtMC
            // 
            this.txtMC.Location = new System.Drawing.Point(96, 21);
            this.txtMC.Name = "txtMC";
            this.txtMC.Size = new System.Drawing.Size(172, 27);
            this.txtMC.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(239)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(194, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 27);
            this.button1.TabIndex = 23;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(239)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(62, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 27);
            this.button2.TabIndex = 22;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RoomFormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(294, 291);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRS);
            this.Controls.Add(this.txtXF);
            this.Controls.Add(this.txtMC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomFormUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改房间类型";
            this.Load += new System.EventHandler(this.RoomFormUpdate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbDZ;
        private System.Windows.Forms.TextBox txtRS;
        private System.Windows.Forms.TextBox txtXF;
        private System.Windows.Forms.TextBox txtMC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}