using LayerIPL.Models;
namespace LayerIPL.BusinessLayer
{
public class PlayerValidator
{
    public bool ValidatePlayerData(Player player)
    {
        // Example validation: Age must be between 18 and 40
        if (player.Age < 18 || player.Age > 40)
        {
            Console.WriteLine("Invalid age. Age must be between 18 and 40.");
            return false;
        }

        // Add more validation rules as needed

        return true;
    }
}
}