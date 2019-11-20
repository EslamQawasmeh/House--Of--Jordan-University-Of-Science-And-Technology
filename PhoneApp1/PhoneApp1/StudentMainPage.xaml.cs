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
    public partial class StudentMainPage : PhoneApplicationPage
    {
        public StudentMainPage()
        {
            InitializeComponent();
        }
        public static string StudentFullName;
        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ContactUsPage.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RoomRequestPage.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NotificationPage.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AttendancePage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
             textBlock1.Text="Welcome : " + StudentFullName;
            rrs.GetStudentRoomRequestAsync(Login1Page.StudentUniversityID);
            rrs.GetStudentRoomRequestCompleted += new EventHandler<GetStudentRoomRequestCompletedEventArgs>(rrs_GetStudentRoomRequestCompleted);
        }

        void rrs_GetStudentRoomRequestCompleted(object sender, GetStudentRoomRequestCompletedEventArgs e)
        {
            if (e.Result > 0)
            {
                buttonRoomRequset.IsEnabled = false;
            }
            else
            {
                buttonRoomRequset.IsEnabled = true;
            }
        }
    }
}