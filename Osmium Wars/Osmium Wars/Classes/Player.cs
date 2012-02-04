using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OW
{
    class Player : Infantry
    {
        public Player(Game game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            this.model = this.game.Content.Load<Model>("Units/Player");
            //this.rotation += (float)gameTime.TotalGameTime.Seconds / 100;
        }
    }
}
