﻿using Game.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Interfaces.Services
{
    /// <summary>
    /// Принцип разделения интерфейса
    /// </summary>
    public interface ISettingsConfiguration
    {
        Settings ConfigureSettings();
    }
}
