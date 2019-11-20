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
    public partial class Login1Page : PhoneApplicationPage
    {
        public Login1Page()
        {
            InitializeComponent();
        }
        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();
        public static string StudentUniversityID = "";

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rrs.LoginAsync(textBoxStudentUniID.Text, passwordBox1.Password);
             rrs.LoginCompleted += new EventHandler<LoginCompletedEventArgs>(rrs_LoginCompleted);
        }

        void rrs_LoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            if (e.Result != "")
            {
                Login1Page.StudentUniversityID = textBoxStudentUniID.Text;
                StudentMainPage.StudentFullName = e.Result;
                NavigationService.Navigate(new Uri("/StudentMainPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Invalid StudentUID or Password");
            }
        }
    }
}