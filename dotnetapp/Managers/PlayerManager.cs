using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetapp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace dotnetapp.Managers
{
    public class PlayerManager
    {
        
        public void DisplayAllPlayers()
        {
            string constr="User ID =sa;password=examlyMssql@123;server=localhost;Database=DbName;trusted_connection=false;Persist Security Info=False;Encrypt=False";
            SqlConnection con=new SqlConnection(constr);
            SqlCommand cmd=new SqlCommand("select * from Player",con);
            con.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            console.WriteLine({reader.Id} {reader.Name} {reader.Age} )

        }
        public void AddPlayer()
        {
            players.Add(new Player{})
        }
        public void DeletePlayer()
        {
            
        }
        public void EditPlayer()
        {
            
        }
        public void ListPlayers()
        {
            
        }
        public void FindPlayer()
        {
            
        }
        public void FindPlayer()
        {
            
        }
        
        // Write your fuctions here...
        // DisplayAllPlayers
        // AddPlayer
        // EditPlayer
        // DeletePlayer
        // ListPlayers
        // FindPlayer
        // DisplayAllPlayers
    }
}
