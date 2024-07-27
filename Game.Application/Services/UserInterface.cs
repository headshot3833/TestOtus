using Game.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Services
{
    public class UserInterface : IUserInterface
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }


        public void ShowGameMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
