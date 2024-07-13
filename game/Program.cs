using Game.Domain.Entity;
using game.Entity;
using Game.Application.Services;
using Game.Domain.Interfaces.Services;
using Game.Domain.Configuration;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            GameRandomNumber gameRandomNumber = new GameRandomNumber();
            gameRandomNumber.StartGame();
            gameRandomNumber.EndGame();
        }
    }
}