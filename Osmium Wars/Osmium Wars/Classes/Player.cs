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
            MouseState mouseState = Mouse.GetState();

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

            Vector3 nearSource = new Vector3((float) mouseState.X, (float) mouseState.Y, 0f);
            Vector3 farSource = new Vector3((float) mouseState.X, (float) mouseState.Y, 1f);
            Vector3 nearPoint = GraphicsDevice.Viewport.Unproject(nearSource, this.game.Camera.Projection, this.game.Camera.View, Matrix.Identity);
            Vector3 farPoint = GraphicsDevice.Viewport.Unproject(farSource, this.game.Camera.Projection, this.game.Camera.View, Matrix.Identity);

            // Create a ray from the near clip plane to the far clip plane.
            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            // Create a ray.
            Ray ray = new Ray(nearPoint, direction);

            // Calculate the ray-plane intersection point.
            Vector3 n = new Vector3(0f, 1f, 0f);
            Plane p = new Plane(n, 0f);

            // Calculate distance of intersection point from r.origin.
            float denominator = Vector3.Dot(p.Normal, ray.Direction);
            float numerator = Vector3.Dot(p.Normal, ray.Position) + p.D;
            float t = -(numerator / denominator);

            // Calculate the picked position on the y = 0 plane.
            Vector3 pickedPosition = nearPoint + direction * t;

            float x2 = pickedPosition.X;
            float z2 = pickedPosition.Z;

            this.rotation = (float) Math.Atan2(z1 - z2, x2 - x1);
        }
    }
}
