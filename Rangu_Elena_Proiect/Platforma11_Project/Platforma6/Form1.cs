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
public partial class Form1 : Form
{
   DataTable dt = new DataTable();
   public void LoadData()
   {
     SqlConnection conn = new SqlConnection(@"Data Source=WIN-AT32TJLFTU8\SQLEXPRESS;" +
         "Initial Catalog=Music;Integrated Security=SSPI;");
     SqlCommand cmd = new SqlCommand("SELECT Music.* FROM Music", conn);
     SqlDataAdapter sa = new SqlDataAdapter(cmd);
     conn.Open();
     sa.Fill(dt);
     conn.Close();
     sa.Dispose();
     cmd.Dispose();
     conn.Dispose();
   }

   public class MyMusic
   {
     public int id;
     public string title;
     public override string ToString()
     {
       return title;
     }
   }

   public void ShowMusic()
   {
     int i;
     for (i = 0; i < dt.Rows.Count; i++)
     {
       MyMusic music = new MyMusic();
       music.id = Convert.ToInt32(dt.Rows[i]["product_id"]);
       music.title = Convert.ToString(dt.Rows[i]["product_title"]);

       listBox1.Items.Add(music);
      }
    }
    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
       LoadData();
       ShowMusic();
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = listBox1.SelectedIndex;
      string info = "";
      int i;
      if(dt.Rows.Count > 0 && index >= 0)
      {
        for (i = 0; i < dt.Columns.Count; i++)
        {
          info += dt.Columns[i].ColumnName + ": " + 
              dt.Rows[index][dt.Columns[i].ColumnName] + "\r\n";
        }
      }
        textBox1.Text=info;
    }
    public void ClearAll()
    {
      dt = new DataTable();
      listBox1.Items.Clear();
      textBox1.Text = "";
    }
    private void btn_Add_Click(object sender, EventArgs e)
    {
      Form2 dialog = new Form2();
      dialog.ShowDialog();

      ClearAll();
      LoadData();
      ShowMusic();
    }
    private void btn_Remove_Click(object sender, EventArgs e)
    {
      int index = listBox1.SelectedIndex;
      if (index >= 0)
      {
        string song_id = dt.Rows[index][dt.Columns[0].ColumnName].ToString();
        SqlConnection conn = new SqlConnection(@"Data Source=WIN-AT32TJLFTU8\SQLEXPRESS;" +
            "Initial Catalog=Music;Integrated Security=SSPI;");
        SqlCommand cmd = new SqlCommand("DELETE FROM Music WHERE product_id="+ 
            song_id + ";", conn);
        conn.Open();
        cmd.ExecuteReader();
        conn.Close();
        cmd.Dispose();
        conn.Dispose();
        ClearAll();
        LoadData();
        ShowMusic();
      }
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
