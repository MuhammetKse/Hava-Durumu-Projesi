using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Hava_Durumu_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            label2.Text = DateTime.Now.ToShortDateString();
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid=7a92ce2a13a8e0b383dc773223ce2f86";
            XDocument hava = XDocument.Load(connection);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            label5.Text = sicaklik.ToString();
            var rüzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            label7.Text = rüzgar + " m/s";
            var nem= hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            label8.Text =nem+" %";
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            durum = "bulutlu";
            if (durum=="açık")
            {
                pictureBox1.ImageLocation = @"C:\\Users\\kickb\\OneDrive\\Masaüstü\\sun-7098480_1280.png";
            }
            else if (durum=="bulutlu")
            {
                pictureBox1.ImageLocation = "C:\\Users\\kickb\\OneDrive\\Masaüstü\\3295537.png";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
