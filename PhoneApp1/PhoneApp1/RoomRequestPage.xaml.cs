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
    public partial class RoomRequestPage : PhoneApplicationPage
    {
        public RoomRequestPage()
        {
            InitializeComponent();
        }
        RRSWebServiceSoapClient rrs = new RRSWebServiceSoapClient();
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            rrs.GetBuildingIDsAsync();
            rrs.GetBuildingIDsCompleted += new EventHandler<GetBuildingIDsCompletedEventArgs>(rrs_GetBuildingIDsCompleted);
        }
        void rrs_GetBuildingIDsCompleted(object sender, GetBuildingIDsCompletedEventArgs e)
        {
            if (e.Result.Count > 0)
            {
                foreach (var item in e.Result)
                {
                    listBoxBuilding.Items.Add(item);
                }
            }
        }

        private void listBoxBuilding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rrs.GetRoomIDsAsync(listBoxBuilding.SelectedItem.ToString());
            rrs.GetRoomIDsCompleted += new EventHandler<GetRoomIDsCompletedEventArgs>(rrs_GetRoomIDsCompleted);
        }

        void rrs_GetRoomIDsCompleted(object sender, GetRoomIDsCompletedEventArgs e)
        {
            listBoxRooms.Items.Clear();
            if (e.Result.Count > 0)
            {
                
                foreach (var item in e.Result)
                {
                    listBoxRooms.Items.Add(item);
                }
            }
        }

        private void listBoxRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rrs.GetRoomCapacityAsync(listBoxRooms.SelectedItem.ToString());
            rrs.GetRoomCapacityCompleted += new EventHandler<GetRoomCapacityCompletedEventArgs>(rrs_GetRoomCapacityCompleted);


            rrs.GetStudentCountAsync(listBoxRooms.SelectedItem.ToString());
            rrs.GetStudentCountCompleted += new EventHandler<GetStudentCountCompletedEventArgs>(rrs_GetStudentCountCompleted);

        }

        void rrs_GetRoomCapacityCompleted(object sender, GetRoomCapacityCompletedEventArgs e)
        {
            if (e.Result > 0)
            {
                textBlockCapacity.Text = e.Result.ToString();
            }
            else
            {
                textBlockCapacity.Text = "0";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (Convert.ToInt32(textBlockCapacity.Text) == Convert.ToInt32(textBlockStudents.Text))
            {
                MessageBox.Show("Room is Full");
            }
            else
            {
                rrs.SendRoomReservationRequestAsync(Login1Page.StudentUniversityID, listBoxRooms.SelectedItem.ToString(), "No");
                rrs.SendRoomReservationRequestCompleted += new EventHandler<SendRoomReservationRequestCompletedEventArgs>(rrs_SendRoomReservationRequestCompleted);
            }


        }

        void rrs_SendRoomReservationRequestCompleted(object sender, SendRoomReservationRequestCompletedEventArgs e)
        {
            if (e.Result > 0)
            {
                MessageBox.Show("Done . . .");
                NavigationService.Navigate(new Uri("/StudentMainPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Error . . .");
            }
        }

        void rrs_GetStudentCountCompleted(object sender, GetStudentCountCompletedEventArgs e)
        {
            if (e.Result > 0)
            {
                textBlockStudents.Text = e.Result.ToString();
            }
            else
            {
                textBlockStudents.Text = "0";
            }
        }
    }
}
    