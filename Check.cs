using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devic_Manage.Dbc;
using Devic_Manage.Devic_inform;

namespace Devic_Manage
{
    public partial class Check : Form
    {
       private string sql;
       private MS_dm ms;
       private int i;
       private string zd = null;
       private int pagecount = 10;
       private int k;
       private int j = 1;
        public Check()
        {
            InitializeComponent();
        }

        private void Check_Load(object sender, EventArgs e)
        {

           
            this.comboBox2.Items.Add("用户ID");
            this.comboBox2.Items.Add("车牌号");
            this.comboBox2.Items.Add("电话号");
            this.comboBox2.Items.Add("设备号");
            this.comboBox2.Items.Add("用户名");
            this.comboBox2.Items.Add("操作员姓名");
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text.ToString().Trim() == "")
            {
                ms = new MS_dm();
                sql = "select * from op_log limit " + pagecount + "";
                if (ms.Check(sql))
                {
                    ms.Read_info(sql, dataGridView1);
                    this.label9.Text = "1/" + fey.getPagecounts(pagecount, zd, this.textBox1.Text.ToString().Trim()) + "";
                }
                else
                {
                    MessageBox.Show("现在没有数据！");
                }
            }
            else {
                i = comboBox2.SelectedIndex;
                ms = new MS_dm();
                if (i == 0) { zd = "uid"; }
                if (i == 1) { zd = "plate_num"; }
                if (i == 2) { zd = "tel"; }
                if (i == 3) { zd = "imei"; }
                if (i == 4) { zd = "username"; }
                if (i == 5) { zd = "op_username"; }
                if (this.textBox1.Text.ToString().Trim() == "")
                {
                    sql = "select * from op_log where " + zd + " = '" + this.textBox2.Text.ToString().Trim() + "' limit " + pagecount + "";
                }
                else
                {
                    sql = "select * from op_log where " + zd + " = '" + this.textBox2.Text.ToString().Trim() + "' and op_username = '" + this.textBox1.Text.ToString().Trim() + "' limit " + pagecount + "";
                }

                if (ms.Check(sql))
                {
                    ms.Read_info(sql, dataGridView1);
                    this.label9.Text = "1/" + fey.getopPagecounts(pagecount, zd, this.textBox2.Text.ToString().Trim()) + "";
                }
                else
                {
                    MessageBox.Show("没有符合条件的信息");
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(e.ColumnIndex){
                case 0:
                    MessageBox.Show("修改成功！");break;
                case 1:
                    MessageBox.Show("删除成功！");break;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fey.Before_oppage(ref k, ref j, this.label9, this.dataGridView1, zd, this.textBox2.Text.ToString().Trim());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fey.Next_oppage(ref k, ref j, this.label9, this.dataGridView1, zd, this.textBox2.Text.ToString().Trim());
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fey.Jump_oppage(ref k, ref j, this.label9, this.dataGridView1, this.textBox9, zd, this.textBox2.Text.ToString().Trim());
        }

        
    }
}
