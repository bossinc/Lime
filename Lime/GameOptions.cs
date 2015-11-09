using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    public class GameOptions
    {
        /// <summary>
        /// Determines the rate at which to scale the virtual resolution
        /// </summary>
        public static float V_SCREEN_FACTOR = 1f;

        /// <summary>
        /// The width of the game screen
        /// </summary>
        public static int SCREEN_WIDTH = 1024;

        /// <summary>
        /// The height of the game screen
        /// </summary>
        public static int SCREEN_HEIGHT = 768;

        /// <summary>
        /// Not yet implemented
        /// </summary>
        public static bool FULL_SCREEN = false;

        /// <summary>
        /// The color used to clear the screen
        /// </summary>
        public static Color BACK_COLOR = Color.Lime;

        /// <summary>
        /// The most frames per second allowed for drawing the game
        /// </summary>
        public static double MAX_DRAW_FPS = 60;

        /// <summary>
        /// The most frames per second allowed for updating the game
        /// </summary>
        public static double MAX_UPDATE_FPS = 60;
    }
}
