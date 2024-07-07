
using Game.Domain.Entity;
using game.Entity;
using Game.Application.Services;
using Game.Domain.Interfaces.Services;
using Game.Domain.Configuration;

class Program
{
    static void Main(string[] args)
    {
        /// DIP: SettingsConfigurator и GenerateNumberService зависят от интерфейсов, а не от конкретных реализаций.

        ISettingsConfiguration settingsConfiguration = new SettingsConfigurator();
        Settings<int>  settings = settingsConfiguration.ConfigureSettings();

        IGenerateNumber numberService = new GenerateNumberService(settings);
        EntityNumber generatedNumber = numberService.GenerateNumber();

        int targetNumber = generatedNumber.Number;

        Console.WriteLine("попробуй угадай число");

        for(int i = 0; i < settings.ScoreTry; i++)
        {
            Console.Write($"попыток {i + 1}/{settings.ScoreTry}: пробуйте!: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int userGuess))
            {
                if (userGuess < targetNumber)
                {
                    Console.WriteLine("Введенное число меньше загаданного.");
                }
                else if(userGuess > targetNumber)
                {
                    Console.WriteLine("Введенное число больше загаданного");
                }
                if(userGuess == targetNumber)
                {
                    Console.WriteLine("вы угадали число!");
                    break;
                }
                else
                {
                    Console.WriteLine("не правильно пробуйте ещё!");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }

            if (i == settings.ScoreTry - 1)
            {
                Console.WriteLine($"Попытки закончились. Загаданное число было {targetNumber}.");
            }
        }

        Console.ReadLine();
    }
}