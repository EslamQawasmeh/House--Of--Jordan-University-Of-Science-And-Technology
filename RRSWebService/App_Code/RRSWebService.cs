using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for RRSWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RRSWebService : System.Web.Services.WebService {

    public RRSWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() 
    {
        return "Hello World";
    }
    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");
 

    [WebMethod]
    public int AddStudent(string StudentUniID, string StudentFullName, string StudentRegion, string StudentSpecialization, string StudentPlaceofBirth, string StudentBirthDate, string StudentMobile, string StudentFatherMobile, string StudentLevel, string StudentPassword)
    {
        int noofEffectedRows = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into Student (StudentUniID, StudentFullName, StudentRegion, StudentSpecialization, StudentPlaceofBirth, StudentBirthDate, StudentMobile, StudentFatherMobile, StudentLevel, StudentPassword) values (@StudentUniID, @StudentFullName, @StudentRegion, @StudentSpecialization, @StudentPlaceofBirth, @StudentBirthDate, @StudentMobile, @StudentFatherMobile, @StudentLevel, @StudentPassword)";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@StudentFullName", StudentFullName);
            com.Parameters.AddWithValue("@StudentRegion", StudentRegion);
            com.Parameters.AddWithValue("@StudentSpecialization", StudentSpecialization);
            com.Parameters.AddWithValue("@StudentPlaceofBirth", StudentPlaceofBirth);
            com.Parameters.AddWithValue("@StudentBirthDate", StudentBirthDate);
            com.Parameters.AddWithValue("@StudentMobile", StudentMobile);
            com.Parameters.AddWithValue("@StudentFatherMobile", StudentFatherMobile);
            com.Parameters.AddWithValue("@StudentLevel", StudentLevel);
            com.Parameters.AddWithValue("@StudentPassword", StudentPassword);
            noofEffectedRows = com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return noofEffectedRows;
    }
    [WebMethod]
    public string Login(string StudentUniID, string StudentPassword)
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
            com.CommandText = " select StudentFullName from Student where StudentUniID =@StudentUniID and StudentPassword = @StudentPassword";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@StudentPassword", StudentPassword);

            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {

                StudentFullName = reader["StudentFullName"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return StudentFullName;
    }

    ////////////


    [WebMethod]
    public string GetNotifications()
    {
        string Notifications = "";
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = " select NotificationTitle ,NotificationText from Notification where NotificationDate = @NotificationDate";
            com.Parameters.AddWithValue("@NotificationDate", DateTime.Now.Date.ToString("yyyy-MM-dd"));

            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {

                Notifications = reader["NotificationTitle"].ToString() + "?" + reader["NotificationText"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return Notifications;
    }

    [WebMethod]
    public List<string> GetBuildingIDs()
    {
        List<string> BuildingIDs = new List<string>();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select BuildingID from Building";

            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                BuildingIDs.Add(reader["BuildingID"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return BuildingIDs;
    }


    [WebMethod]
    public List<string> GetRoomIDs(string BuildingID)
    {
        List<string> RoomIDs = new List<string>();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = " select RoomID from Room where BuildingID = @BuildingID";
            com.Parameters.AddWithValue("@BuildingID", BuildingID);

            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                RoomIDs.Add(reader["RoomID"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return RoomIDs;
    }




    [WebMethod]

    public int GetRoomCapacity(string RoomID)
    {
        int RoomCapacity = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = " select RoomCapacity from Room where RoomID=@RoomID";
            com.Parameters.AddWithValue("@RoomID", RoomID);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {

                RoomCapacity = Convert.ToInt32(reader["RoomCapacity"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return RoomCapacity;
    }



    [WebMethod]

    public int GetStudentCount(string RoomID)
    {
        int StudentCount = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = " select Count(*) from RoomReservation where RoomID = @RoomID";
            com.Parameters.AddWithValue("@RoomID", RoomID);
            StudentCount = Convert.ToInt32(com.ExecuteScalar());

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return StudentCount;
    }



    [WebMethod]

    public int SendRoomReservationRequest(string StudentUniID, string RoomID, string ReservationState)
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
            com.CommandText = " Insert into RoomReservationRequest ( StudentUniID ,RoomID , ReservationState , RequestDate ) values (@StudentUniID , @RoomID , @ReservationState ,@RequestDate )";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@RoomID", RoomID);
            com.Parameters.AddWithValue("@ReservationState", ReservationState);
            com.Parameters.AddWithValue("@RequestDate", DateTime.Now.Date.ToString("yyyy-MM-dd"));
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



    [WebMethod]

    public int GetStudentRoomRequest(string StudentUniID)
    {
        int StudentRoomRequest = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = " select Count(*) from RoomReservationRequest where StudentUniID = @StudentUniID ";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            StudentRoomRequest = Convert.ToInt32(com.ExecuteScalar());

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return StudentRoomRequest;
    }


    [WebMethod]

    public int AddMessage(string StudentUniID, string StudentFullName, string MessageTitle, string MessageBody)
    {
        int noofEffectedRows = 0;
        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();


            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into SocialAdviserInbox (StudentUniID, StudentFullName, MessageTitle, MessageBody, MeesageDate) values (@StudentUniID, @StudentFullName, @MessageTitle, @MessageBody, @MeesageDate)";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@StudentFullName", StudentFullName);
            com.Parameters.AddWithValue("@MessageTitle", MessageTitle);
            com.Parameters.AddWithValue("@MessageBody", MessageBody);
            com.Parameters.AddWithValue("@MeesageDate", DateTime.Now.Date.ToString("yyyy-MM-dd"));
            noofEffectedRows = com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return noofEffectedRows;
    }

    [WebMethod]

    public List<string> GetAttendance(string StudentUniID)
    {
        List<string> AttendDates = new List<string>();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = " select AttendDate from StudentAttendance where StudentUniID = @StudentUniID and IsAttend = @IsAttend";
            com.Parameters.AddWithValue("@StudentUniID", StudentUniID);
            com.Parameters.AddWithValue("@IsAttend", "No");
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                AttendDates.Add(reader["AttendDate"].ToString());
            }
        }

        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        return AttendDates;
    }

}
