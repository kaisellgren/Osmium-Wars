using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace OW
{
    public class Player : Infantry
    {
        protected float speed = 4;

        public Player(Game game) : base(game)
        {
            this.game = game;
            this.baseRotation = Util.DegToRag(90);
        }

        protected override void LoadContent()
        {
            this.model = this.game.Content.Load<Model>("Units/Player");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            // Implement movement with WASD controls.
            if (keyState.IsKeyDown(Keys.W))
            {
                this.position.X += (float) Math.Cos(this.rotation) * this.speed;
                this.position.Z += -(float) Math.Sin(this.rotation) * this.speed;
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                this.position.X += (float) Math.Cos(this.rotation) * -this.speed / 2;
                this.position.Z += -(float) Math.Sin(this.rotation) * -this.speed / 2;
            }
            else if (keyState.IsKeyDown(Keys.A))
            {
                this.position.X += (float) Math.Cos(this.rotation + Util.DegToRag(-90)) * -this.speed / 2;
                this.position.Z += -(float) Math.Sin(this.rotation + Util.DegToRag(-90)) * -this.speed / 2;
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                this.position.X += (float) Math.Cos(this.rotation + Util.DegToRag(90)) * -this.speed / 2;
                this.position.Z += -(float) Math.Sin(this.rotation + Util.DegToRag(90)) * -this.speed / 2;
            }

            // Calculate the direction the player should look at (mouse cursor).
            float x1 = this.position.X;
            float z1 = this.position.Z;

            Vector3 mouseWorldPosition = Util.GetMouseWorldPosition(this.game);
            float x2 = mouseWorldPosition.X;
            float z2 = mouseWorldPosition.Z;

            this.rotation = Util.PointDirection(x1, z1, x2, z2);
        }
    }
}
