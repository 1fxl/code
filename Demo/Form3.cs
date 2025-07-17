using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form3 : Form
    {
        string SID;//记录登陆选课系统的学号
        public Form3(string sID)
        {
            SID = sID;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss");
            toolStripStatusLabel1.Text = "欢迎学号为" + SID + "的同学登录选课系统";
            timer1.Start();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Course";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);

            while (dr.Read())
            {
                string a = dr["Id"].ToString();
                string b = dr["Name"].ToString();
                string c = dr["Teacher"].ToString();
                string d = dr["Credit"].ToString();  // 注意：可能是"Birthday"拼写错误
                string[] str = { a, b, c, d, };  // 修正数组声明方式
                dataGridView1.Rows.Add(str);
            }

            dr.Close();  // 关闭连接
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序

        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cID = dataGridView1.SelectedCells[0].Value.ToString(); //获取选中的课程号
            string sql1 = "SELECT * FROM CourseRecord WHERE sId = '" + SID + "' AND cId = '" + cID + "'"; // 修正SQL语法
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql1);
            if (!dc.Read())
            {
                string sql = "INSERT INTO CourseRecord VALUES('" + SID + "','" + cID + "')"; // 修正INSERT语法
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("选课成功");
                }
            }
            else
            {
                MessageBox.Show("不允许重复选课");
            }
            dc.Close(); // 关闭DataReader
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(SID);
            f.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 f=new Form32(SID);
            f.Show();
        }
    }
}
