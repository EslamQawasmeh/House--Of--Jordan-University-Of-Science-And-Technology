using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
  public class User
  {
public User()
{
}
SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");
public string Login(string UserID, string UserType , string UserPassword)
{
string UserFullName = "";
try
{
    if(con.State == ConnectionState.Closed)
    {
        con.Open();
    }
     SqlCommand com = new SqlCommand();
com.Connection=con;
com.CommandType = CommandType.Text;
com.CommandText = "select UserFullName from Users where UserID = @UserID and UserPassword = @UserPassword and UserType = @UserType";
com.Parameters.AddWithValue("@UserID",UserID);
com.Parameters.AddWithValue("@UserPassword",UserPassword );
com.Parameters.AddWithValue("@UserType",UserType );
SqlDataReader reader = com.ExecuteReader();
if(reader.Read())
{
    UserFullName= reader["UserFullName"].ToString();
}


}

 catch(Exception ex)
{
     MessageBox.Show(ex.Message);
 }
finally
{
    con.Close();
}
return UserFullName;

}

public string GetUserFullName(string UserID){

   string UserFullName = "";
   try{if(con.State == ConnectionState.Closed){
            con.Open();}
       SqlCommand com = new SqlCommand();
       com.Connection = con;     
       com.CommandType = CommandType.Text;
       com.CommandText = "select UserFullName from Users where UserID = @UserID";
com.Parameters.AddWithValue("@UserID",UserID);
SqlDataReader reader = com.ExecuteReader();
if(reader.Read())
{
    UserFullName= reader["UserFullName"].ToString();
}

}
catch(Exception ex )
   {
    MessageBox.Show(ex.Message);
}
finally
   {
       con.Close();
   }
return UserFullName;

}
}
