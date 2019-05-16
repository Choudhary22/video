using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace video
{       
    class operationclass
    {
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        DataSet d = new DataSet();
        public string connectionstring()
        {
            return(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anilm\Desktop\video\video\Database2.mdf;Integrated Security=True");
        }

        
        public int getmaxmovieid()
        {
         
            con.Close();
            con.ConnectionString = connectionstring(); 
            com.CommandType = CommandType.Text;
            com.CommandText = "select max(MovieID) from Movies";
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            int id = Convert.ToInt16(d.Tables[0].Rows[0][0]);
            return (id);
        }
       
        public DataSet moviedata(string movieid)
        {
      
            con.Close();
            con.ConnectionString = connectionstring();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Movies where movieid=" + movieid;
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            return (d);
        }
   

       
      
      
        
         
        public DataSet showcurrent()
        {
  
            con.Close();
            con.ConnectionString = connectionstring();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Movies where year='2019'";
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            return (d);
        }
        public DataSet mostpopular()
        {
            
            con.Close();
            con.ConnectionString = connectionstring(); 
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Movies where  MovieID in (select MovieIDFK from RentedMovies)";
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            return (d);
        }
    }
}
