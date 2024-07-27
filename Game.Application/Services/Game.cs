using Game.Domain.Configuration;
using Game.Domain.Entity;
using game.Entity;
using Game.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Services
{
    public class GameRandomNumber : IGame
    {
        private readonly Settings _settings;
        private int _targetNumber;
        private readonly UserInterface _userInterface;

        public GameRandomNumber(UserInterface userInterface)
        {
            ISettingsConfiguration settingsConfiguration = new SettingsConfigurator();
            _settings = settingsConfiguration.ConfigureSettings();
            _userInterface = userInterface;
        }

        public void EndGame()
        {
            _userInterface.ShowGameMessage("Если хотите ещё, нажмите Enter, подсказка число 0 до 100");
            _userInterface.GetInput();
        }

        public void StartGame()
        {
            ISettingsConfiguration settingsConfiguration = new SettingsConfigurator();
            Settings settings = settingsConfiguration.ConfigureSettings();

            IGenerateNumber numberService = new GenerateNumberService(settings);
            EntityNumber generatedNumber = numberService.GenerateNumber();

            int targetNumber = generatedNumber.Number;

            _userInterface.ShowGameMessage("попробуй угадай число");

            for (int i = 0; i < settings.ScoreTry; i++)
            {
                _userInterface.ShowGameMessage($"попыток {i + 1}/{settings.ScoreTry}: пробуйте!: ");
                string userInput = _userInterface.GetInput();
                if (int.TryParse(userInput, out int userGuess))
                {
                    if (userGuess < targetNumber)
                    {
                        _userInterface.ShowGameMessage("Введенное число меньше загаданного.");
                    }
                    else if (userGuess > targetNumber)
                    {
                        _userInterface.ShowGameMessage("Введенное число больше загаданного");
                    }
                    if (userGuess == targetNumber)
                    {
                        _userInterface.ShowGameMessage("вы угадали число!");
                        break;
                    }
                    else
                    {
                        _userInterface.ShowGameMessage("не правильно пробуйте ещё!");
                    }
                }
                else
                {
                    _userInterface.ShowGameMessage("Некорректный ввод. Пожалуйста, введите целое число.");
                }

                if (i == settings.ScoreTry - 1)
                {
                    _userInterface.ShowGameMessage($"Попытки закончились. Загаданное число было {targetNumber}.");
                }
            }

            _userInterface.GetInput();
        }
    }
}
