using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Entity
{
    public class Settings<T>
    {
        public T FirstRange { get; set; }

        public T LastRange { get; set; }

        public T ScoreTry { get; set; }
    }
}
