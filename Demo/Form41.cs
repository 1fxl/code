using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demo
{
    public partial class Form41 : Form
    {
        Form4 f;
        string[] str=new string[4];

        //插入
        public Form41(Form4 form4)
        {
            InitializeComponent();
            this.f = form4;
            this.button3.Visible = false;
        }

        //修改按钮
        public Form41(string[] str, Form4 form4)
        {
            InitializeComponent();
            this.f = form4;
            for (int i = 0; i < str.Length; i++)
            {
                this.str[i] = str[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            this.button1.Visible = false;


        }

        private void Form41_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {

                string sql = "INSERT INTO Teachar VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i == 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;


                }
                f.Table();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                string sql="delete from Teachar where Id='"+str[0]+"'and Name='" + str[1] + "'";
                string sql2= "INSERT INTO Teachar VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                Dao dao = new Dao();
                dao.Excute(sql);
                dao.Excute(sql2);
                f.Table();  
            }
        }
    }
}
