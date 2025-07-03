using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_data_Click(object sender, EventArgs e)
        {

            string street = txt_street.Text;
            string city = txt_city.Text;
            string state = txt_state.Text;
            string zip = txt_zip.Text;

            try
            {
                StringBuilder queryadress = new StringBuilder();
                queryadress.Append("http://maps.google.com/maps?q=");

                if(street != String.Empty)
                {
                    queryadress.Append(street + "," + "+");
                }
                if (city != String.Empty)
                {
                    queryadress.Append(city + "," + "+");
                }
                if (state != String.Empty)
                {
                    queryadress.Append(state + "," + "+");
                }
                if (zip != string.Empty)
                {
                    queryadress.Append(zip + "," + "+");
                }
                webBrowser1.Navigate(queryadress.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
                    
             }

        }
    }
}
