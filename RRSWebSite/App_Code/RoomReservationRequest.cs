using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;


public class RoomReservationRequest
{
	public RoomReservationRequest()
	{
	
	}
    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");

    public ArrayList GetStudentIDsRoomRequest()
{
ArrayList StudentIDs = new ArrayList();
try
{
if(con.State == ConnectionState.Closed)
{
con.Open();
}
SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select StudentUniID from RoomReservationRequest where ReservationState = @ReservationState";
            com.Parameters.AddWithValue("@ReservationState"," No");
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                StudentIDs.Add(reader["StudentUniID"].ToString());
            }

}
catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return StudentIDs;
}
public int UpdateRoomRequestState(string StudentUniID , string ReservationState)
{
int RoomRequestState = 0;
try
{
if(con.State == ConnectionState.Closed)
{
con.Open();
}
SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Update RoomReservationRequest set ReservationState = @ReservationState where StudentUniID = @StudentUniID";
            com.Parameters.AddWithValue("@StudentUniID",StudentUniID);
            com.Parameters.AddWithValue("@ReservationState",ReservationState);
            RoomRequestState = com.ExecuteNonQuery();
            

}
catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return RoomRequestState;
}

public string GetRequestedRoomID (string StudentUniID )

{
string RequestedRoomID = "";
try
{
if(con.State == ConnectionState.Closed)
{
con.Open();
}
SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select RoomID from RoomReservationRequest where StudentUniID = @StudentUniID ";
            com.Parameters.AddWithValue("@StudentUniID",StudentUniID);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                RequestedRoomID = reader["RoomID"].ToString();

            }
}
catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return RequestedRoomID;
}
}