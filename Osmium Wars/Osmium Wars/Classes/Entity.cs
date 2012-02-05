using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OW
{
    abstract public class Entity : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Game game;
        protected Model model;
        protected Vector3 position = Vector3.Zero;
        protected float rotation = 0.0f;
        protected float baseRotation = 0.0f;
        protected float size = 0.1f;

        /// <summary>
        /// The model instance.
        /// </summary>
        public Model Model
        {
            get { return this.model; }
        }

        /// <summary>
        /// The position of this entity.
        /// </summary>
        public Vector3 Position
        {
            get { return this.position; }
        }

        /// <summary>
        /// The rotation of this entire entity.
        /// </summary>
        public float Rotation
        {
            get { return this.rotation; }
        }

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

            ModelBone bone = this.model.Bones["AF_Helmet_Xmas_D.bmp"];
            //Matrix boneTransform = bone.Transform;
            bone.Transform *= Matrix.CreateRotationY(this.rotation / 30);

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
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateScale(this.size, this.size, this.size) * Matrix.CreateRotationY(this.rotation + this.baseRotation) * Matrix.CreateTranslation(this.position);
                    effect.View = this.game.Camera.View;
                    effect.Projection = this.game.Camera.Projection;
                }

                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}