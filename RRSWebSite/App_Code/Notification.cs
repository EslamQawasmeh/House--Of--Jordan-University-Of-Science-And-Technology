using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;



public class Notification
{
	public Notification()
	{	
	}

    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");


    public int AddNotification(string NotificationID, string NotificationTitle, string NotificationText, string NotificatinDate, string UserID)
    {
        int noofEffectedRows = 0;

        try

        {
            if(con.State ==ConnectionState.Closed )
                con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection =con;
            com.CommandType = CommandType .Text;
            com.CommandText=" insert into Notification (NotificationID ,NotificationTitle ,NotificationText ,NotificatinDate ,UserID ) values (@NotificationID ,@NotificationTitle ,@NotificationText ,@NotificatinDate ,@UserID )";
            com.Parameters.AddWithValue("@NotificationID" , NotificationID);
            com.Parameters.AddWithValue("@NotificationTitl" , NotificationTitle);
            com.Parameters.AddWithValue("@NotificationText" , NotificationText);
            com.Parameters.AddWithValue("@NotificatinDate" , NotificatinDate);
            com.Parameters.AddWithValue("@UserID" , UserID);
            noofEffectedRows=com.ExecuteNonQuery();

        }

        catch (Exception ex )
        {
            MessageBox.Show(ex.Message);
        }
                finally
        {
            con.Close();
        }
        return noofEffectedRows;
    }

        public int GetNotificationCount()
        {
            int NotificationCount=0;

            try
            
            {
                if  (con.State == ConnectionState.Closed )
                {
           


                con.Open();

            }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType=CommandType.Text;
                com.CommandText=" select count(*) from Notification ";
                NotificationCount = Convert.ToInt32(com.ExecuteScalar());
            }

                catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
                }

            finally{
                con.Close();
            }

            return NotificationCount;
        }


            public DataSet GetNotifications(string NotificationDate)
            {
                DataSet Notifications = new DataSet();

                try{
                    if(con.State ==ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = " select NotificationID , NotificationTitle , NotificationText , UserID from Notification where NotificationDate =@NotificationDate";
                    com.Parameters.AddWithValue("@NotificationDate" , NotificationDate );


                    SqlDataAdapter adapter = new SqlDataAdapter (com);
                    adapter.Fill(Notifications , "Notification" );


                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }
                finally{
                    con.Close();
                }
                return Notifications;
            }
}




           
