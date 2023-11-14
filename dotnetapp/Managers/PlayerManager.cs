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
         public string ConnectionString{get;set;}= "User ID=sa;password=examlyMssql@123; server=localhost;Database=PlayerDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        // Write your fuctions here...
        // DisplayAllPlayers
        // AddPlayer
        // EditPlayer
        // DeletePlayer
        // ListPlayers
        // FindPlayer
        // DisplayAllPlayers

//Connected Database


    public void DisplayAllPlayers(){

        string cmdtext = "select * from Players";
        SqlConnection conn = null;
        try{
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            Console.WriteLine("Connection opened successfully");
            SqlCommand command = new SqlCommand(cmdtext,conn);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
        {   
          Console.WriteLine($"{reader["Id"]}-----{reader["Name"]}---{reader["Age"]}---{reader["Category"]}---{reader["BiddingPrice"]}");  
        }
            conn.Close();

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        
        }

        public void AddPlayerToDatabase(Player p){

            Console.WriteLine("-----------------ADD-----------------------");

            int id = p.Id;
            string name = p.Name;
            int age = p.Age;
            string category = p.Category;
            decimal biddingAmount = p.BiddingPrice;


        SqlConnection conn = null;
        try
        {

            conn = new SqlConnection(ConnectionString);
            conn.Open();
            string qureryStr="insert into Players values(@id,@name,@age,@category,@bidding)";
            SqlCommand cmd=new SqlCommand(qureryStr,conn);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.Parameters.AddWithValue("@age",age);
            cmd.Parameters.AddWithValue("@category",category);
            cmd.Parameters.AddWithValue("@bidding",biddingAmount);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception e)
        {
        
        Console.WriteLine("Failed to connect to the database. Error message: " + e);

        }

        }

        public void EditPlayer(Player p){

            SqlConnection con=null;
            SqlDataAdapter adapter=null;
            DataSet ds=null;
            try{

                con=new SqlConnection(ConnectionString);
                adapter=new SqlDataAdapter("select * from Players",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"playTable");
                foreach(DataRow dr in ds.Tables["playTable"].Rows)
                {
                    if(Convert.ToInt32(dr[0])==p.Id)
                    {
                        dr[1]=p.Name;
                        dr[2]=p.Age;
                        dr[3]=p.Category;
                        dr[4]=p.BiddingPrice;
                        break;
                    }
                }
                adapter.Update(ds,"playTable");
        }
        catch(Exception e)
        {
            Console.WriteLine("Failed to connect to the database. Error message: " + e);
        }
        }

        public void AddPlayer(){
            
        }


        public void AddPlayer(Player p){
                SqlConnection con=null;
            SqlDataAdapter adapter=null;    
            DataSet ds=null;
            try{

                con=new SqlConnection(ConnectionString);
                adapter=new SqlDataAdapter("select * from Players",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"playTable");
                DataRow dr=ds.Tables["playTable"].NewRow();
                dr[0]=p.Id;
                dr[1]=p.Name;
                dr[2]=p.Age;
                dr[3]=p.Category;
                dr[4]=p.BiddingPrice;
                ds.Tables["playTable"].Rows.Add(dr);
                adapter.Update(ds,"playTable");
            }

            catch(Exception e)
            {

                Console.WriteLine("Failed to connect to the database. Error message: " + e);

            }
        }
        public void DeletePlayer(int id){


        Console.WriteLine("DELETE--------------------------");

        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
    

        DataSet ds = null;
        try{

            conn = new SqlConnection(ConnectionString);
            adapter = new SqlDataAdapter("select * from Players",conn);
            ds = new DataSet();
            adapter.Fill(ds,"playTable");

          
            foreach(DataRow dr in ds.Tables["playTable"].Rows)
            {
                if(Convert.ToInt32(dr[0])==id)
                {   
                    dr.Delete();
                    SqlCommandBuilder cms = new SqlCommandBuilder(adapter);
                    adapter.Update(ds,"playTable");
                    Console.WriteLine("DELETED SUCCESSFULLY--------------------------");

                    break;

                }

            }



        }catch(Exception ex){
        
        Console.WriteLine("Failed to connect to the database. Error message: " + ex);


        }





        }

        public void FindPlayer(string Name){

            Player p = new Player();

            SqlConnection con=null;
            SqlDataAdapter adapter=null;
            DataSet ds=null;

            try{

                con = new SqlConnection(ConnectionString);
                adapter = new SqlDataAdapter("Select * from Players",con);
             
                SqlCommandBuilder cms = new SqlCommandBuilder(adapter);
                ds = new DataSet();
                adapter.Fill(ds,"playTable");

                foreach(DataRow dr in ds.Tables["playTable"].Rows)
                {

                    if(Convert.ToString(dr[1]) ==Name)
                    {

                        Console.WriteLine("Player Details for Name : "+Name);

                        Console.WriteLine("Id: "+dr[0]+"\nName: "+dr[1]+"\nAge: "+dr[2]+"\nCategory: "+dr[3]+"\nBiddingPrice: "+dr[4]);

                    }



                }


            }catch(Exception ex)
            {
        Console.WriteLine("Failed to connect to the database. Error message: " + ex);


            }







        }
        public void ListPlayers(){

              SqlConnection con=null;
             SqlDataAdapter adapter=null; 
             DataSet ds=null;
            try{
                con=new SqlConnection(ConnectionString);
               adapter=new SqlDataAdapter("select * from Players",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"t");
                foreach(DataRow dr in ds.Tables["t"].Rows)
                {
                        Console.WriteLine("Id: "+dr[0]+"\nName: "+dr[1]+"\nAge: "+dr[2]+"\nCategory: "+dr[3]+"\nBiddingPrice: "+dr[4]);
                }
            }catch(Exception e)
                {
                    Console.WriteLine("Failed to connect to the database. Error message: " + e);
                }


        }
    }
}
//PlayerDB Players