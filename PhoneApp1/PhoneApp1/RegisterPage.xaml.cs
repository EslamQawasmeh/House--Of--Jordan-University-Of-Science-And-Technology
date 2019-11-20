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
    public partial class RegisterPage : PhoneApplicationPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rrs.AddStudentAsync(textBoxStudentUniID.Text, textStudentFullName.Text, textBoxStudentRegion.Text, textBoxStudentSpecialization.Text, textBoxStudentPlaceofBirth.Text, textBoxStudentBirthDate.Text, textBoxStudentMobile.Text, textBoxStudentFatherMobile.Text, textBoxStudentLevel.Text, textBoxStudentPassword.Text);
            rrs.AddStudentCompleted += new EventHandler<AddStudentCompletedEventArgs>(rrs_AddStudentCompleted);

        }

        void rrs_AddStudentCompleted(object sender, AddStudentCompletedEventArgs e)
        {
            if (e.Result != 0)
            {
                MessageBox.Show("Done . . .  ");
            }
            else
            {
                MessageBox.Show("Error . . .  ");
            }
        }
    }
}
