using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OW
{
    class Vehicle : Entity
    {
        public Vehicle(Game game) : base(game)
        {
            this.game = game;
        }
    }
}
