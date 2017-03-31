using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Databaseconnectivity
{
    public partial class Form1 : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dtb;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = mydb; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM mytb where ID='" + id.Text + "'", con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            try
            {
                id.Text = dtb.Rows[0][0].ToString();
                name.Text = dtb.Rows[0][1].ToString();
                age.Text = dtb.Rows[0][2].ToString();
            }
            catch(Exception )
            {

            }
           


        }

        private void insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand scom = new SqlCommand("INSERT INTO mytb (id,name,age) VALUES(@id,@name,@age)", con);
                scom.Parameters.Add("id", SqlDbType.Int);
                scom.Parameters["id"].Value = id.Text;

                scom.Parameters.Add("name", SqlDbType.VarChar);
                scom.Parameters["name"].Value = name.Text;

                scom.Parameters.Add("age", SqlDbType.Int);
                scom.Parameters["age"].Value = age.Text;


                scom.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

            }


        }

        private void view_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=True");
            sda = new SqlDataAdapter(@"SELECT * FROM mytb", con);
            dtb = new DataTable();
            sda.Fill(dtb);
            dataGridView1.DataSource = dtb;
            MessageBox.Show("The datagrid lists all your data");

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=True");
                con.Open();

                SqlCommand scom =
                                new SqlCommand("UPDATE mytb SET name=@name, age=@age, salary=@salary WHERE id=@id", con);
                
                {
                    scom.Parameters.Add("id", SqlDbType.Int).Value = id.Text;

                    scom.Parameters.Add("name", SqlDbType.VarChar).Value = name.Text;

                    scom.Parameters.Add("age", SqlDbType.Int).Value = age.Text;


                    
                    scom.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
                
            

                

            }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=True");

                con.Open();
                SqlCommand scom =
                                new SqlCommand("DELETE FROM mytb WHERE id=@id", con);
                
                {
                    scom.Parameters.Add("id", SqlDbType.Int).Value = id.Text;

                   


                    
                    scom.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("pls fill in the form");
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            try
            {
                
                id.Text = string.Empty;
                name.Text = string.Empty;
                age.Text = string.Empty;
                
            }
            catch (Exception ex)
            {
               
            }
        }
    }
    }

