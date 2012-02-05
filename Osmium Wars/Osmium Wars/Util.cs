using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace OW
{
    class Util
    {
        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static float DegToRag(float degrees)
        {
            return degrees * (float) Math.PI / 180;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float RadToDeg(float radians)
        {
            return radians * (float) (180 / Math.PI);
        }

        /// <summary>
        /// Returns the direction (in radians) from point to another.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static float PointDirection(float x1, float y1, float x2, float y2)
        {
            return (float) Math.Atan2(y1 - y2, x2 - x1);
        }

        /// <summary>
        /// Returns the mouse X, Y and Z coordinates on the world so that the Y is always on ground zero (0).
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static Vector3 GetMouseWorldPosition(Game game)
        {
            GraphicsDevice graphicsDevice = game.GraphicsDevice;
            MouseState mouseState = Mouse.GetState();

            Vector3 nearSource = new Vector3((float) mouseState.X, (float) mouseState.Y, 0f);
            Vector3 farSource = new Vector3((float) mouseState.X, (float) mouseState.Y, 1f);
            Vector3 nearPoint = graphicsDevice.Viewport.Unproject(nearSource, game.Camera.Projection, game.Camera.View, Matrix.Identity);
            Vector3 farPoint = graphicsDevice.Viewport.Unproject(farSource, game.Camera.Projection, game.Camera.View, Matrix.Identity);

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

            return pickedPosition;
        }
    }
}
