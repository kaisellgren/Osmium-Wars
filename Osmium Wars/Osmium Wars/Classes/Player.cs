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
                angle = Math.Atan2((double)mouseState.Y - this.position.Y, (double)mouseState.X - this.position.X); //this will return the angle(in radians) from sprite to mouse.
                this.position.Z -= SPEED* (float)Math.Cos(angle);
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                angle = Math.Atan2((double)mouseState.Y - this.position.Y, (double)mouseState.X - this.position.X); //this will return the angle(in radians) from sprite to mouse.
                this.position.Z += SPEED * (float)Math.Cos(angle);
            }
            else if (keyState.IsKeyDown(Keys.A))
            {
                angle = Math.Atan2((double)mouseState.Y - this.position.Y, (double)mouseState.X - this.position.X); //this will return the angle(in radians) from sprite to mouse.
                this.position.X -= SPEED * (float)Math.Sin(angle);
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                angle = Math.Atan2((double)mouseState.Y - this.position.Y, (double)mouseState.X - this.position.X); //this will return the angle(in radians) from sprite to mouse.
                this.position.X += SPEED * (float)Math.Sin(angle);
            }

            //Now make him look at the direction of the mouse
             
            angle = Math.Atan2((double)mouseState.Y - this.position.Y, (double)mouseState.X - this.position.X); //this will return the angle(in radians) from sprite to mouse.
            this.faceposition.X = (float)Math.Cos(angle);
            this.faceposition.Y = (float)Math.Sin(angle);
        }              
    }
}
