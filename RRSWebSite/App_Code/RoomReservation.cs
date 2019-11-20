using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;



public class RoomReservation
{
    public RoomReservation()
    {
    }
    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");

    public ArrayList GetStudentIDs(string RoomID)
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
            com.CommandText = "select StudentID from RoomReservation where RoomID = @RoomID";
            com.Parameters.AddWithValue("@RoomID", RoomID);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                RoomIDs.Add(reader["StudentID"].ToString());
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
    public int AddRoomReservation(string StudentUniID, string RoomID)
    {
        int Count = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into RoomReservation (StudentUniID , RoomID) values (@StudentUniID , @RoomID)";
            com.Parameters.AddWithValue("StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@RoomID", RoomID);

            Count = com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
        return Count;
    }
    public DataSet GetStudentDetails(string RoomID)
    {
        DataSet StudentDetails = new DataSet();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select StudentUniID from RoomReservation where RoomID = @RoomID";
            com.Parameters.AddWithValue("@RoomID", RoomID);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(StudentDetails, "RoomReservation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return StudentDetails;
    }

}