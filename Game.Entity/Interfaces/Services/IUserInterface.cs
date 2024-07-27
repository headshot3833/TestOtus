using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Interfaces.Services
{
    public interface IUserInterface
    {
        public void ShowGameMessage(string message);

        string GetInput();
    }
}
