using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LayerIPL.Models;
namespace LayerIPL.DataAccess{
public class PlayerRepository
{
    private readonly List<Player> players;

    public PlayerRepository()
    {
        players = new List<Player>();
    }

    public Player FindPlayerByName(string playerName)
    {
        return players.FirstOrDefault(p => p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
    }

    public void AddPlayer(Player player)
    {
      
        player.Id = players.Count + 1;
        players.Add(player);
    }

    public void UpdatePlayer(Player player)
    {
       
        var existingPlayer = players.FirstOrDefault(p => p.Id == player.Id);
        if (existingPlayer != null)
        {
            existingPlayer.Name = player.Name;
            existingPlayer.Age = player.Age;
            existingPlayer.Category = player.Category;
            existingPlayer.BiddingPrice = player.BiddingPrice;
        }
    }
}
}