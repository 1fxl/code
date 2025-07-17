using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss");
            timer1.Start();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Teachar";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                 string a,b,c,d;
                 a = dr["Id"].ToString();
                 b = dr["Name"].ToString();
                 c = dr["PassWord"].ToString();
                 d = dr["ZC"].ToString();  // 注意：可能是"Birthday"拼写错误
                 string[] str = { a, b, c, d, };  // 修正数组声明方式
                 dataGridView1.Rows.Add(str);
            }

            dr.Close();  // 关闭连接
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss");
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 f=new Form41(this);
            f.ShowDialog();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r=MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel);
            if (r==DialogResult.OK)
            {
                string tID = dataGridView1.SelectedCells[0].Value.ToString();
                string tName = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Teachar where Id='" + tID + "'and Name='" + tName + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                }
            
            }
            Table();
        }

        

        private void 修改学生信息(object sender, EventArgs e)
        {
            string a, b, c, d;
            a = dataGridView1.SelectedCells[0].Value.ToString();
            b = dataGridView1.SelectedCells[1].Value.ToString();
            c = dataGridView1.SelectedCells[2].Value.ToString();
            d = dataGridView1.SelectedCells[3].Value.ToString();
            string[] str = { a, b, c, d };
            Form41 f = new Form41(str,this);
            f.ShowDialog();
           
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
