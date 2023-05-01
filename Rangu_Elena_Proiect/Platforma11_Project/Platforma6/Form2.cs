using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Platforma6
{
 public partial class Form2 : Form
 {
   public Form2()
   {
     InitializeComponent();
   }

   private void btn_OK_Click(object sender, EventArgs e)
   {
     if (textBox1.Text != "" && 
       textBox2.Text != "" && 
       textBox3.Text != "" && 
       textBox4.Text != "" && 
       textBox5.Text != "" && 
       textBox6.Text != "")
     {
       SqlConnection conn = new SqlConnection(@"Data Source=WIN-AT32TJLFTU8\SQLEXPRESS;" +
           "Initial Catalog=Music;Integrated Security=SSPI;");
       string query = "INSERT INTO Music " +
                    "(product_title, product_producer, product_type, product_description," +
                    " product_benefits, product_price, product_promotion, product_availability ) " +
                    "values ('" + textBox1.Text +
                     "', '" + textBox6.Text +
                    "', '" + textBox7.Text +
                    "', '" + textBox2.Text +
                    "', '" + textBox3.Text +
                    "', '" + textBox4.Text +
                    "', '" + textBox5.Text +
                     "', '" + textBox8.Text + "');";
       SqlCommand cmd = new SqlCommand(query,conn);
       conn.Open();
       cmd.ExecuteReader();
       conn.Close();
       cmd.Dispose();
       conn.Dispose();
       this.Close();
     }
     else
     {
       MessageBox.Show("Introduceti date in toate campurile!",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);
     }
   }

   private void btn_Cancel_Click(object sender, EventArgs e)
   {
     this.Close();
   }

   private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
   {
     if (!char.IsControl(e.KeyChar)
         && !char.IsDigit(e.KeyChar))
     {
       e.Handled = true;
     }
   }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
