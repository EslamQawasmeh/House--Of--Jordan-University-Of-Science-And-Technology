using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;


public class Room
{
    public Room()
    {

    }



    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");

    public ArrayList GetRoomIDs(string BuildingID)
    {
        ArrayList RoomIDs = new ArrayList();
        try
        {

            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }



            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select RoomID from Room where BuildingID = @BuildingID";
            com.Parameters.AddWithValue("@BuildingID", BuildingID);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                RoomIDs.Add(reader["RoomID"].ToString());
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

        return RoomIDs;
    }
    public string GetRoomCapacity(string RoomID)
    {
        string RoomCapacity = "  ";
        try
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }



            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select RoomCapacity from Room where RoomID = @RoomID";
            com.Parameters.AddWithValue("@RoomID", RoomID);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {

                RoomCapacity = reader["RoomCapacity"].ToString();
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

        return RoomCapacity;
    }
}