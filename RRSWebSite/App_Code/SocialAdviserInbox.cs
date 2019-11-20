using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;
public class SocialAdviserInbox
{
  public SocialAdviserInbox()
  {
  }
  SqlConnection con = new SqlConnection(@"Data Source=USER-PC\MSSQLSERVER2014;Initial Catalog=StudentRoomReservetion;User ID=sa;Password=123");  

public DataSet GetInbox(string StudentFullName)
{

DataSet Inbox = new DataSet();
try
{

   if(con.State == ConnectionState.Closed)
       {
       con.Open();
   }

 
    SqlCommand com = new SqlCommand();
       com.Connection = con;     
       com.CommandType = CommandType.Text;
       com.CommandText = "select StudentUniID as[Student University ID],MessageTitle as [Title],MessageBody as [Body],MessageDate as [Date] from SocialAdviserInbox where StudentFullName = @StudentFullName ";
com.Parameters.AddWithValue("@StudentFullName",StudentFullName);

SqlDataAdapter adapter = new SqlDataAdapter(com);
adapter.Fill( Inbox ,"SocialAdviserInbox");

}
catch(Exception ex )
{
    MessageBox.Show(ex.Message);
}

finally
{
  con.Close();
}
return Inbox;
}


public ArrayList GetStudentFullNames()
{
ArrayList StudentFullName = new ArrayList();
try
{
    
if(con.State == ConnectionState.Closed)
{
    con.Open();
}
       SqlCommand com = new SqlCommand();
       com.Connection = con;     
       com.CommandType = CommandType.Text;
       com.CommandText = "select distinct StudentFullName from SocialAdviserInbox ";
         SqlDataReader reader = com.ExecuteReader();
        while(reader.Read())
        {
          StudentFullName.Add(reader["StudentFullName"].ToString());

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
return StudentFullName;
}
}


