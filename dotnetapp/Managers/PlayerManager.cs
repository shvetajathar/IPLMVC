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
            while(reader.Read())
            {
                console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Age"]} {reader["Category"]} {reader["BiddingPrice"]}");
            }

        }
        public void AddPlayer(Player p)
        {
            Team T=new Team();
            T.Players.Add(p);

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
        

        public void AddPlayerToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Player VALUES (@Id, @Name, @Age, @Category,@BiddingPrice)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Player.Id);
                    command.Parameters.AddWithValue("@Name", Player.Name);
                    command.Parameters.AddWithValue("@Age", Player.Age);
                    command.Parameters.AddWithValue("@Category", Player.Category);
                    command.Parameters.AddWithValue("@BiddingPrice", Player.BiddingPrice);
                    
                    return (int)command.ExecuteScalar();
                }
            }
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
