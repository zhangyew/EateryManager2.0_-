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
    public partial class OpenForm : Form
    {
        public OpenForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 房间编号
        /// </summary>
        public string id { set; get; }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenForm_Load(object sender, EventArgs e)
        {
            Looking();
        }
        /// <summary>
        /// 加载对用餐台基本信息
        /// </summary>
        private void Looking()
        {
            RoomType_BLL bll = new RoomType_BLL();

            foreach (var item in bll.LookKaiDangXX(id))
            {
                lblBH.Text = item.TableName;
                lblLX.Text = item.RTName;
                lblXF.Text = item.RTMin.ToString();
            }

        }
        
        /// <summary>
        /// 开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string rq = DateTime.Now.ToString("yyyyMMdd");
            Random rd = new Random();
            string bh = "ZY" + $"{rq}" + rd.Next(1, 9999);
            string rs = txtRS.Text;

            ConsumerBill_BLL bll = new ConsumerBill_BLL();
            Tables_BLL _bll = new Tables_BLL();
            //开单成功后进行餐台状态的更改，并判断是否直接进行消费

            if (bll.KaiDan(bh, Convert.ToInt32(id), rs, rq) == true)
            {
                if (_bll.XiuGaiCT(id) == true)
                {
                    if (MainForm.mainForm != null)
                    {
                        MainForm.mainForm.BinRoomType();
                    }
                }
                 MessageBox.Show("顾客开单成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("顾客开单失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //开单成功后打开增加消费界面，并将所获取的餐台号传给增加消费界面 

            if (cbXF.Checked == true)
            {
                AddConsume tj = new AddConsume();
                tj.id = id;
                // tj.name = lblBH.Text;
                tj.ShowDialog();
                this.Hide();
            }
            this.Hide();
        }
    }
}
