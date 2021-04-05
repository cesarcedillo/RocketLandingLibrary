using System;
using System.Drawing;

namespace RocketLandingLibrary
{
    public class Landing
    {
        private static Point[] LandingArea = { new Point(0, 0), new Point(100, 100) };
        private static Rectangle LandingPlatform = new Rectangle(5,5,10,10);
        private static Point LastPostion;

        /// <summary>
        /// Possible values ​​of states of a rocket landing
        /// </summary>
        public enum LandingState
        {
            OkForLanding,
            OutOfPlatform,
            Clash
        }

        /// <summary>
        /// Checks the status of a landing platform position
        /// </summary>
        /// <param name="x">X coordinate that defines the position of the point to check</param>
        /// <param name="y">Y coordinate that defines the position of the point to check</param>
        /// <returns>Value that describes the state of the position for a possible landing</returns>
        public static LandingState CheckPosition(int x, int y)
        {
            var point = new Point(x, y);
            if (LandingPlatform.Contains(point))
            {
                var allocatedArea = GetAllocatedArea(new Point(LastPostion.X - 1, LastPostion.Y - 1) , LandingPlatform,new Size(3, 3));
                if (allocatedArea.Contains(point))
                {
                    return LandingState.Clash;
                }
                LastPostion = point;
                return LandingState.OkForLanding;
            }
            return LandingState.OutOfPlatform;
        }

        /// <summary>
        /// returns a portion of area of ​​another larger area defined by a point on the plane and its size, both in height and width
        /// </summary>
        /// <param name="point">Point defining the upper left corner of the area</param>
        /// <param name="area">Main area from which a portion is to be taken</param>
        /// <param name="areaSize">Size of the area is to be taken</param>
        /// <returns>It is a Rectagle defined by the intersection between the main area and the subarea defined with the point and size</returns>
        private static Rectangle GetAllocatedArea(Point point, Rectangle area, Size areaSize)
        {
            var allocatedArea = new Rectangle(point, areaSize);

            area.Intersect(allocatedArea);

            return area;
        }
    }
}
