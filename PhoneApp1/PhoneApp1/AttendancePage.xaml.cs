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
    public partial class AttendancePagePage : PhoneApplicationPage
    {
        public AttendancePagePage()
        {
            InitializeComponent();
        }
        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
             rrs.GetAttendanceAsync(Login1Page.StudentUniversityID);
             rrs.GetAttendanceCompleted += new EventHandler<GetAttendanceCompletedEventArgs>(rrs_GetAttendanceCompleted);
        }

        void rrs_GetAttendanceCompleted(object sender, GetAttendanceCompletedEventArgs e)
        {
            if (e.Result.Count > 0)
            {
                listBoxAttendance.Items.Clear();
                foreach (var item in e.Result)
                {
                    listBoxAttendance.Items.Add(item.ToString());
                }
            }
        }
    }
}