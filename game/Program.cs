using Game.Domain.Entity;
using game.Entity;
using Game.Application.Services;
using Game.Domain.Interfaces.Services;
using Game.Domain.Configuration;

class Program
{
    static void Main(string[] args)
    {
        UserInterface userInterface = new UserInterface();
        while (true)
        {
            GameRandomNumber gameRandomNumber = new GameRandomNumber(userInterface);
            gameRandomNumber.StartGame();
            gameRandomNumber.EndGame();
        }
    }
}