using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;


public class StudentAttendance
{
    public StudentAttendance()
    {
    }

    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");

    public int AddAttendance(string StudentUniID, string StudentFullName, string AttendDate, string IsAttend, string UserID)
    {
        int EffectedRows = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Insert into StudentAttendance (StudentUniID , StudentFullName , AttendDate , IsAttend , UserID ) values (@StudentUniID , @StudentFullName , @AttendDate , @IsAttend , @UserID)";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@StudentFullName", StudentFullName);
            com.Parameters.AddWithValue("@AttendDate", AttendDate);
            com.Parameters.AddWithValue("@IsAttend", IsAttend);
            com.Parameters.AddWithValue("@UserID", UserID);


            EffectedRows = com.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return EffectedRows;
    }

    public DataTable GetAttendance(string AttendanceDate, string UserID)
    {
        DataTable Attendance = new DataTable();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select StudentUniID , StudentFullName , IsAttend from StudentAttendance where AttendDate = @AttendDate and UserID = @UserID";
            com.Parameters.AddWithValue("@AttendDate", AttendanceDate);
            com.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter Adapter = new SqlDataAdapter(com);
            Adapter.Fill(Attendance);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return Attendance;
    }
}

            




