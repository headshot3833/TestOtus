using game.Entity;
using Game.Domain.Entity;
using Game.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Application.Services
{
    /// <summary>
    /// OCP открыты для расширения, но закрыты для изменения
    /// </summary>
    public class GenerateNumberService : IGenerateNumber
    {
        private readonly Settings<int> _settings;

        public GenerateNumberService(Settings<int> settings)
        {
            _settings = settings;
        }

        public EntityNumber GenerateNumber()
        {
            Random random = new Random();

            int number = random.Next(_settings.FirstRange, _settings.LastRange);
            return new EntityNumber { Number = number };
        }
    }
}
