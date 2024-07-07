using game.Entity;
using Game.Domain.Entity;
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
    public interface IGenerateNumber
    {
        public EntityNumber GenerateNumber();
    }
}
