using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;


public class Building
{
    public Building()
    {

    }

    SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");

    public ArrayList GetBuildingIDs()
    {
        ArrayList BuildingIDs = new ArrayList();
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
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return BuildingIDs;
    }
    public string GetUserID(string BuildingID)
    {
        string UserID = "  ";
        try
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }



            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select UserID from Building where BuildingID = @BuildingID";
            com.Parameters.AddWithValue("@BuildingID", BuildingID);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {

                UserID = reader["UserID"].ToString();
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

        return UserID;
    }



    public ArrayList GetBuildingIDsforUser(String UserID)
    {
        ArrayList BuildingIDs = new ArrayList();
        try
        {


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select BuildingID from Building where UserID = @UserID";
            com.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                BuildingIDs.Add(reader["BuildingID"].ToString());
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

        return BuildingIDs;
    }
}

