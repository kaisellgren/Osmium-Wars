using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OW
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        protected float aspectRatio;
        protected Camera camera;

        /// <summary>
        /// Returns the camera instance.
        /// </summary>
        public Camera Camera
        {
            get { return this.camera; }
        }

        /// <summary>
        /// Returns the aspect ratio in float.
        /// </summary>
        public float AspectRatio
        {
            get { return this.aspectRatio; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                game.Run();
            }
        }

        public Game()
        {
            this.Content.RootDirectory = "Content";
            this.graphics = new GraphicsDeviceManager(this);

            //this.graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //this.graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //this.graphics.IsFullScreen = true;

            this.graphics.PreferredBackBufferWidth = 1024;
            this.graphics.PreferredBackBufferHeight = 768;

            this.graphics.PreferMultiSampling = true;
            this.graphics.ApplyChanges();

            this.aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            // Initialize the camera.
            this.camera = new Camera(this);
            this.Components.Add(this.camera);

            // Create one player instance.
            Player player = new Player(this);
            this.Components.Add(player);
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
