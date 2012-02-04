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
        private static int SPEED = 10;
        public Player(Game game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            this.model = this.game.Content.Load<Model>("Units/Player");
            //this.rotation += (float)gameTime.TotalGameTime.Seconds / 100;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            //Implement movement with WASD controls
            if (keyState.IsKeyDown(Keys.W))
            {
                this.position.Z -= SPEED;
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                this.position.Z += SPEED;
            }
            else if (keyState.IsKeyDown(Keys.A))
            {
                this.position.X -= SPEED;
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                this.position.X += SPEED;
            }
        }
                
    }
}
