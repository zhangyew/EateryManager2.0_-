using EateryManager.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerUI
{
    public partial class EndConsumeForm : Form
    {
        public EndConsumeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 餐台编号
        /// </summary>
        public string id { set; get; }

        private void EndConsumeForm_Load(object sender, EventArgs e)
        {
            //加载隐藏面板信息
            LookingYinChang();
            //加载单号基本信息
            LookingDainDan();

        }
        /// <summary>
        /// 加载单号基本信息
        /// </summary>
        private void LookingDainDan()
        {
            Tables_BLL bll = new Tables_BLL();
            ConsumerBill_BLL _bll = new ConsumerBill_BLL();
            txtBH.Text = bll.ChaXunCanTai(id);
            lblDH.Text = _bll.lookDingDanHao(id);
            double zje = _bll.LookJE(id);
            lblYS.Text = zje.ToString("f2");
            lblJE.Text = zje.ToString("f2");


            double dz = double.Parse(lblDZ.Text);

            double YH =((zje * dz));

            lblYH.Text = YH.ToString("f2");

            double ss = (zje - YH);

            lblSS.Text = ss.ToString("f2");

            //txtYHZF.Text = zje.ToString();


            try
            {
                int zf = Convert.ToInt32(txtYHZF.Text);
                lblZQ.Text = (zf - ss).ToString("f2");
            }
            catch (Exception)
            {
            }
            lvXX.Items.Clear();
            foreach (var item in _bll.LookDianDanCP(_bll.lookDingDanHao(id)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.name;
                lvi.SubItems.AddRange(new[] { 
                item.CDPrice.ToString(),
                lblDZ.Text,
                item.CDPrice.ToString(),
                0.ToString(),
                item.CDMoney.ToString(),
                item.CDMoney.ToString(),
                item.CDDate.ToString()
                });
                lvXX.Items.Add(lvi);
            }



        }

        Vips_BLL bll = new Vips_BLL();
        /// <summary>
        /// 加载隐藏面板信息
        /// </summary>
        private void LookingYinChang()
        {
            lvYC.Items.Clear();
            string x = txtHY.Text;
            foreach (var item in bll.Looking(null))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.VipID.ToString();
                lvi.SubItems.AddRange(
                    new[]
                    {
                        item.VipName.ToString(),
                        item.VGID,
                        item.VGDiscount.ToString("f2"),
                    }
                    );
                lvYC.Items.Add(lvi);
            }
            LookingDainDan();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pVIP.Visible = true;
        }

        private void txtHY_Click(object sender, EventArgs e)
        {
            pVIP.Visible = true;
        }

        private void EndConsumeForm_Click(object sender, EventArgs e)
        {
            pVIP.Visible = false;
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pVIP.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiackClick();
        }
        /// <summary>
        /// 添加会员信息
        /// </summary>
        private void DiackClick()
        {
            if (lvYC.SelectedItems.Count == 0)
            {
                return;
            }
            string id = lvYC.SelectedItems[0].SubItems[1].Text;
            foreach (var item in bll.Looking(id))
            {
                lblXM.Text = item.VipName;
                lblDJ.Text = item.VGID;
                lblDZ.Text = item.VGDiscount.ToString("f2");
                txtHY.Text = item.VGID;
            }
            pVIP.Visible = false;
        }

        private void lvYC_DoubleClick(object sender, EventArgs e)
        {
            DiackClick();
        }

        private void txtYHZF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string z = txtYHZF.Text;
                double zf = double.Parse(z);
                string zy = lblSS.Text;
                double ss = double.Parse(zy);
                double zq = zf - ss;
                lblZQ.Text = zq.ToString("f2");
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label42_Click(object sender, EventArgs e)
        {
            ConsumerBill_BLL bll = new ConsumerBill_BLL();

            if (lvYC.SelectedItems.Count > 0)
            {
                string vid = lvYC.SelectedItems[0].SubItems[0].Text;
                string dz = lvYC.SelectedItems[0].SubItems[3].Text;
                if (bll.JieZang(bll.lookDingDanHao(id),vid, dz, id) == true)
                {
                    MessageBox.Show("结账成功，欢迎下次光临！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if (MainForm.mainForm != null)
                    {
                        MainForm.mainForm.BinRoomType();
                    }

                    this.Close();
                    Close();
                }
                else
                {
                    MessageBox.Show("结账失败!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            if(bll.JieZang(bll.lookDingDanHao(id), null, null,id) == true)
            {
                MessageBox.Show("结账成功，欢迎下次光临！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                if (MainForm.mainForm != null)
                {
                    MainForm.mainForm.BinRoomType();
                }

                this.Close();
                Close();
            }
            else
            {
                MessageBox.Show("结账失败!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
    }
}
