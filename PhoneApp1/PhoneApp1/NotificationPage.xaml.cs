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
    public partial class NotificationPage : PhoneApplicationPage
    {
        public NotificationPage()
        {
            InitializeComponent();
        }
        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();
        void rrs_GetNotificationsCompleted(object sender, GetNotificationsCompletedEventArgs e)
        {
            if(e.Result != "")
            {
                string[] fulldata = e.Result.ToString().Split('?');
                if(fulldata.Length > 0)
                {
                    textBlockTitle.Text = fulldata[0];
                    textBlockBody.Text = fulldata[1];
                }
            }
            else
            {
                MessageBox.Show("No Notification to view ");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rrs.GetNotificationsAsync();
            rrs.GetNotificationsCompleted += new EventHandler<GetNotificationsCompletedEventArgs>(rrs_GetNotificationsCompleted);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            rrs.GetNotificationsAsync();
            rrs.GetNotificationsCompleted += new EventHandler<GetNotificationsCompletedEventArgs>(rrs_GetNotificationsCompleted);
        }
    }
}
