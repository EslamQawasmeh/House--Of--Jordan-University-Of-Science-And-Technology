using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PhoneApp1.RRSServiceReference;
namespace PhoneApp1
{
    public partial class ContactUsPage1 : PhoneApplicationPage
    {
        public ContactUsPage1()
        {
            InitializeComponent();
        }
        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rrs.AddMessageAsync(Login1Page.StudentUniversityID, StudentMainPage.StudentFullName, textBox1.Text, textBox2.Text);
            rrs.AddMessageCompleted += new EventHandler<AddMessageCompletedEventArgs>(rrs_AddMessageCompleted);
        }

        void rrs_AddMessageCompleted(object sender, AddMessageCompletedEventArgs e)
        {
            if (e.Result > 0)
            {
                MessageBox.Show("Done . . .");
            }
            else
            {
                MessageBox.Show("Error . . .");
            }
        }
    }
}