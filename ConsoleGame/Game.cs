using System;

namespace ConsoleGame
{
    class Game : SuperGame
    {
        // Update position of a cursor according to the last pressed key
        public new static void UpdatePosition(string key, out int xChange, out int yChange)
        {
            // Set current position
            xChange = 0;
            yChange = 0;

            switch (key)
            {
                case "RightArrow":
                    xChange += 1;
                    break;
                case "LeftArrow":
                    xChange -= 1;
                    break;
                case "UpArrow":
                    yChange -= 1;
                    break;
                case "DownArrow":
                    yChange += 1;
                    break;
                default:
                    xChange += 0;
                    yChange += 0;
                    break;
            }
        }

        // Update cursor symbol according to the last pressed key 
        public new static char UpdateCursor(string key)
        {
            switch (key)
            {
                case "RightArrow":
                    return '>';
                case "LeftArrow":
                    return '<';
                case "UpArrow":
                    return '^';
                case "DownArrow":
                    return 'v';
                default:
                    return '<';
            }
        }

        public new static int KeepInBounds(int dimension, int max)
        {
            /* 
            // Keep in the bounds of the screen
             if (dimension >= max)
             {
               return max - 1;
             }
             else if (dimension < 0)
             {
               return 0;
             }
             else 
             {
               return dimension;
             }
             */

            // "Loop around" the bounds of the screen.

            if (dimension >= max)
            {
                return 0;
            }
            else if (dimension < 0)
            {
                return max - 1;
            }
            else
            {
                return dimension;
            }
        }

        // Return true when player's positon matches position of the fruit 
        public new static bool DidScore(int x1, int y1, int x2, int y2) => (x1 == x2 && y1 == y2);

    }
}