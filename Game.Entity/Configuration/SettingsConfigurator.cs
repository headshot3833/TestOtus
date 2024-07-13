using Game.Domain.Entity;
using Game.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Configuration
{
    /// <summary>
    /// OCP открыты для расширения, но закрыты для изменения
    /// </summary>
    public class SettingsConfigurator : ISettingsConfiguration
    {
       protected static Settings _settings;
       static SettingsConfigurator()
        {
            _settings = new Settings
            {
                FirstRange = 0,
                LastRange = 100,
                ScoreTry = 10
            };
        }

        public Settings ConfigureSettings()
        {
            return _settings;
        }
    }
}
