using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                timer1.Stop();

                if (comboBox1.Text == "学生")
                {
                    string sql = $"SELECT * FROM Student WHERE Name='{textBox1.Text}' AND PassWord='{textBox2.Text}'";
                    Dao dao = new Dao();
                    IDataReader dr = dao.read(sql);

                    if (dr.Read())
                    {
                        // 登录成功逻辑
                        string sID = dr["Id"].ToString();
                        Form3 form3 = new Form3(sID);
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                    dr.Close();  // 关闭DataReader
                }
                else if (comboBox1.Text == "老师")
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "管理员")
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else
            {
                MessageBox.Show("登录失败，请检查用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool login()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBox1.Text == "学生")
            {
                string sql = $"SELECT * FROM Student WHERE Name='{textBox1.Text}' AND PassWord='{textBox2.Text}'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    dr.Close();
                    return true;
                }
                dr.Close();
                MessageBox.Show("用户名或密码错误");
                return false;
            }
            else if (comboBox1.Text == "老师")
            {
                string sql = $"SELECT * FROM Teachar WHERE Name='{textBox1.Text}' AND PassWord='{textBox2.Text}'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    dr.Close();
                    return true;
                }
                dr.Close();
                MessageBox.Show("用户名或密码错误");
                return false;
            }
            else if (comboBox1.Text == "管理员")
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    return true;
                }
                else 
                {
                    MessageBox.Show("用户名或密码错误");
                    return false;
                }
            }

            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }
    }
}