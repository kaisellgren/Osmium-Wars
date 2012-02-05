using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
