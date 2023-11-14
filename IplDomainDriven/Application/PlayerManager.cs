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
namespace LayerIPL.Application
{
   public class PlayerManager
{
    PlayerValidator playerValidator;
    PlayerRepository playerRepository;

    public PlayerManager()
    {
        playerValidator = new PlayerValidator();
        playerRepository = new PlayerRepository();
    }

    public void FindPlayer()
    {
        // Implementation to find a player.
        Console.WriteLine("Enter player name to find:");
        string playerName = Console.ReadLine();
        var foundPlayer = playerRepository.FindPlayerByName(playerName);

        if (foundPlayer != null)
        {
            Console.WriteLine($"Player found: {foundPlayer.Name}, Age: {foundPlayer.Age}, Category: {foundPlayer.Category}");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
    }

    public void AddPlayer()
    {
        // Implementation to add a player.
        Player newPlayer = new Player();
        Console.WriteLine("Enter player name:");
        newPlayer.Name = Console.ReadLine();
        Console.WriteLine("Enter player age:");
        newPlayer.Age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter player category:");
        newPlayer.Category = Console.ReadLine();
        Console.WriteLine("Enter bidding price:");
        newPlayer.BiddingPrice = decimal.Parse(Console.ReadLine());

        // Validate player data
        if (playerValidator.ValidatePlayerData(newPlayer))
        {
            playerRepository.AddPlayer(newPlayer);
            Console.WriteLine("Player added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid player data. Please correct and try again.");
        }
    }

    public void EditPlayer()
    {
        // Implementation to edit a player.
        Console.WriteLine("Enter player name to edit:");
        string playerName = Console.ReadLine();
        var playerToEdit = playerRepository.FindPlayerByName(playerName);

        if (playerToEdit != null)
        {
            Console.WriteLine($"Editing player: {playerToEdit.Name}, Age: {playerToEdit.Age}, Category: {playerToEdit.Category}");

            // Allow user to modify player details
            Console.WriteLine("Enter new player name:");
            playerToEdit.Name = Console.ReadLine();
            Console.WriteLine("Enter new player age:");
            playerToEdit.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new player category:");
            playerToEdit.Category = Console.ReadLine();
            Console.WriteLine("Enter new bidding price:");
            playerToEdit.BiddingPrice = decimal.Parse(Console.ReadLine());

            // Validate edited player data
            if (playerValidator.ValidatePlayerData(playerToEdit))
            {
                playerRepository.UpdatePlayer(playerToEdit);
                Console.WriteLine("Player updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid player data. Edit canceled.");
            }
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
    }
}

}