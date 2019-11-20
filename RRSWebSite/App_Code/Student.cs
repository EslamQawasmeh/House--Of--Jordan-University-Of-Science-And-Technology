using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;


public class Student
{


    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");
    public Student()
    {
    }

    public string GetStudentFullName(string StudentUniID)
    {
        string StudentFullName = "";
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select StudentFullName from Student where StudentUniID  = @StudentUniID";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                StudentFullName = reader["StudentFullName"].ToString();

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

        return StudentFullName;
    }




    public DataSet GetStudentDetails(string StudentUniID)
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
            com.CommandText = "select StudentFullName as [Full Name] , StudentRegion as [Region] , StudentSpecialization as [Specialization] , StudentPlaceofBirth as [Place of Birth] , StudentBirthDate as [Birth Date], StudentMobile as [Mobile] , StudentFatherMobile as [Father Mobile], StudentLevel as [Level] from Student where StudentUniID  = @StudentUniID";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(StudentDetails, "Student");
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