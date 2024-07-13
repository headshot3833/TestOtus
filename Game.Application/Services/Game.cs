﻿using Game.Domain.Configuration;
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
        public GameRandomNumber()
        {
            ISettingsConfiguration settingsConfiguration = new SettingsConfigurator();
            _settings = settingsConfiguration.ConfigureSettings();

        }

        public void EndGame()
        {
            Console.WriteLine("Если хотите ещё, нажмите Enter.");
            Console.ReadLine();
        }

        public void StartGame()
        {
            ISettingsConfiguration settingsConfiguration = new SettingsConfigurator();
            Settings settings = settingsConfiguration.ConfigureSettings();

            IGenerateNumber numberService = new GenerateNumberService(settings);
            EntityNumber generatedNumber = numberService.GenerateNumber();

            int targetNumber = generatedNumber.Number;

            Console.WriteLine("попробуй угадай число");

            for (int i = 0; i < settings.ScoreTry; i++)
            {
                Console.Write($"попыток {i + 1}/{settings.ScoreTry}: пробуйте!: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userGuess))
                {
                    if (userGuess < targetNumber)
                    {
                        Console.WriteLine("Введенное число меньше загаданного.");
                    }
                    else if (userGuess > targetNumber)
                    {
                        Console.WriteLine("Введенное число больше загаданного");
                    }
                    if (userGuess == targetNumber)
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
}