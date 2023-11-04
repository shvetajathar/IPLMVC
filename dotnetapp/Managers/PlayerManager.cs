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
        public void FindPlayer()
        {
            
        }

        public void AddPlayerToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Player (Id, Name, Age, Category,BiddingPrice) " +
                            "OUTPUT INSERTED.Id " +
                            "VALUES (@Id, @Name, @Age, @Category,@BiddingPrice)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", instrument.Name);
                    command.Parameters.AddWithValue("@Type", instrument.Type);
                    command.Parameters.AddWithValue("@Price", instrument.Price);
                    command.Parameters.AddWithValue("@Manufacturer", instrument.Manufacturer);
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
