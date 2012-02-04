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
        private double angle;
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
            MouseState mouseState = Mouse.GetState();

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

            //Now make him look at the direction of the mouse
             
            angle = Math.Atan2((double)mouseState.Y - this.position.Y, (double)mouseState.X - this.position.X); //this will return the angle(in radians) from sprite to mouse.
            this.faceposition.X = (float)Math.Cos(angle);
            this.faceposition.Y = (float)Math.Sin(angle);
        }              
    }
}
