using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;

namespace Loop_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://modify-this.com/check.php?username=" + textBox1.Text + "&password=" + textBox2.Text);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);

            string server_response = reader.ReadToEnd();

            if (server_response != "1") MessageBox.Show("Wrong credentials.");
            else
            {
                Form1 frm1 = new Form1();
                Form2 frm2 = new Form2();

                frm1.Close();
                frm2.Show();
            }
        }
    }
}
