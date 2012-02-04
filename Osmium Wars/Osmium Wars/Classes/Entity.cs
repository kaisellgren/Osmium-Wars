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
    abstract class Entity : Microsoft.Xna.Framework.DrawableGameComponent
    {
        /// <summary>
        /// The actual model instance for this entity.
        /// </summary>
        protected Model model;

        protected Vector3 position = Vector3.Zero;
        protected float rotation = 0.0f;

        /// <summary>
        /// The instance of the game.
        /// </summary>
        protected Game game;

        public Entity(Game game) : base(game)
        {
            this.game = game;
        }

        /// <summary>
        /// Draw the model.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[this.model.Bones.Count];
            this.model.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in this.model.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.AmbientLightColor = new Vector3(255, 255, 255);
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateScale(0.2f, 0.2f, 0.2f) * Matrix.CreateRotationY(this.rotation) * Matrix.CreateTranslation(this.position);
                    effect.View = Matrix.CreateLookAt(this.game.cameraPosition, Vector3.Zero, Vector3.Forward);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), this.game.aspectRatio, 1.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}
