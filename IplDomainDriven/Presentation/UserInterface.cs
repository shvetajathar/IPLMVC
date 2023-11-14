using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerIPL.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LayerIPL.DataAccess;
using LayerIPL.BusinessLayer;
using LayerIPL.Application;
namespace LayerIPL.Presentation{
    public class UserInterface{


     PlayerManager playerManager;

    public UserInterface()
    {
        playerManager = new PlayerManager();
      
    }
    public void Run()
    {
        int choice;

        do
        {
            Console.WriteLine("1. Find Player");
            Console.WriteLine("2. Add Player");
            Console.WriteLine("3. Edit Player");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        playerManager.FindPlayer();
                        break;
                    case 2:
                        playerManager.AddPlayer();
                        break;
                    case 3:
                        playerManager.EditPlayer();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 4);
    }

    }
}