using Microsoft.Xna.Framework;

namespace OW
{
    public class Camera : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Game game;
        protected Vector3 position;
        protected Matrix view;
        protected Matrix projection;

        /// <summary>
        /// Returns the position of the camera.
        /// </summary>
        public Vector3 Position
        {
            get { return this.position; }
        }

        /// <summary>
        /// Returns the view matrix of the camera.
        /// </summary>
        public Matrix View
        {
            get { return this.view; }
        }

        /// <summary>
        /// Returns the projection matrix of the camera.
        /// </summary>
        public Matrix Projection
        {
            get { return this.projection; }
        }

        public Camera(Game game) : base(game)
        {
            this.game = game;

            this.position = new Vector3(0.0f, 1000.0f, 300.0f);
            this.view = Matrix.CreateLookAt(this.position, Vector3.Zero, Vector3.Up);
            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), this.game.AspectRatio, 1.0f, 10000.0f);
        }
    }
}