using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OW
{
    abstract class Entity : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public abstract void Draw();
    }
}
