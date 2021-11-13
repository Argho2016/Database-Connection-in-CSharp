using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=;Initial Catalog=USER_TABLE;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM member", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=;Initial Catalog=USER_TABLE;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO member(ID, Name, Age) VALUES (@ID,@Name,@Age)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Successfully Inserted");
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=;Initial Catalog=USER_TABLE;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE member SET Name=@Name, Age=@Age WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Successfully Updated");
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=;Initial Catalog=USER_TABLE;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE member WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Successfully Deleted");
            BindData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=;Initial Catalog=USER_TABLE;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM member WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            BindData();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=;Initial Catalog=USER_TABLE;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM member", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
