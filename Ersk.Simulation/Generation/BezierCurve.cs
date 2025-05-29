using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk.Simulation.Generation
{
    public class BezierCurve
    {
        /// <summary>
        /// 't' should be between 0 and 1
        /// </summary>
        /// <param name="t">between 0 and 1</param>
        /// <returns>A number between 0 and 1</returns>
        public static float GetValue(out float t, float weight = 0.5f)
        {
            t = new Random().NextSingle();

            //Console.WriteLine(" T  =  " + t);

            //Point p1 = new Point(0, 0);
            Point p4 = new Point(10, 10);

            // Linear 
            float x = 0;
            // Huge Middle 
            x = 10;



            x = 7;
            //float maxAdjustLeft = x;
            //float maxAdjustright = 10 - x;
            //float maxAdjust = maxAdjustLeft > maxAdjustright ? maxAdjustright : maxAdjustLeft;


            // expand the middle section
            float y = 10;

            // shrink the middle section
            y = 0;

            weight = Math.Clamp(weight, 0, 1);
            //float adjustmentRange;
            //float adjustment;
            //if (weight > 0.5)
            //{
            //    adjustmentRange = 10 - x;
            //    adjustment = adjustmentRange * weight;
            //}
            //else
            //{

            //    adjustmentAlt = x * weight;
            //}



            float p2x = 7;
            float p2y = 0;

            float p3x = 3;
            float p3y = 10;


            // Slide right
            if (weight > 0.5)
            {
                float fullWeight1 = (weight - 0.5f) * 2; // 0 - 1, where 1 is moving curve completely right

                float adjustmentRange1 = 10 - x;
                float adjustment1 = adjustmentRange1 * fullWeight1;
                p2x += adjustment1;

                float adjustmentRange2= 10 - p3x;
                float adjustment2 = adjustmentRange2 * fullWeight1;
                p3x += adjustment2;

            }
            else
            {
                //float fullWeight1 = weight * -2; // 0 - 1, where 1 is moving curve completely left

                //float adjustmentRange1 = p3x;
                float adjustment1 = p3x * (0.5f - weight) * 2;
                p3x += adjustment1;

                //float adjustmentRange2 = p2x;
                float adjustment2 = p2x * (weight - 0.5f) * 2;
                p2x += adjustment2;
            }




           
            //Point p2 = new Point(x, y);
            //Point p3 = new Point(y, x);


            t = Math.Clamp(t, 0, 1);

            //float t = 0.5f; // given example value
            float resultX = (1 - t) * (1 - t) * p2x + 2 * (1 - t) * t * p3x + t * t * p4.X;
            float resultY = (1 - t) * (1 - t) * p2y + 2 * (1 - t) * t * p3y + t * t * p4.Y;

            //Console.WriteLine(" resultX  =  " + resultX);
            return resultX / 10;
        }

        public static float GetValue()
        {
            return GetValue(out _);
        }

        public static int GetValue(int min, int range)
        {
            return min + (int)Math.Round(GetValue() * range, MidpointRounding.AwayFromZero);
        }
        public static int GetValue(int min, int range, out float t)
        {
            return min + (int)Math.Round(GetValue(out t) * range, MidpointRounding.AwayFromZero);
        }

        public static int GetValue(int min, int range, float weightT, out float t)
        {
            return min + (int)Math.Round(GetValue(out t, weightT) * range, MidpointRounding.AwayFromZero);
        }

        public static float GetTestValue(float t, float weight = 0.5f)
        {
            //Console.WriteLine(" T  =  " + t);

            //Point p1 = new Point(0, 0);
            Point p4 = new Point(10, 10);

            // Linear 
            float x = 0;
            // Huge Middle 
            x = 10;



            x = 7;
            //float maxAdjustLeft = x;
            //float maxAdjustright = 10 - x;
            //float maxAdjust = maxAdjustLeft > maxAdjustright ? maxAdjustright : maxAdjustLeft;


            // expand the middle section
            float y = 10;

            // shrink the middle section
            y = 0;

            weight = Math.Clamp(weight, 0, 1);
            //float adjustmentRange;
            //float adjustment;
            //if (weight > 0.5)
            //{
            //    adjustmentRange = 10 - x;
            //    adjustment = adjustmentRange * weight;
            //}
            //else
            //{

            //    adjustmentAlt = x * weight;
            //}



            float p2x = 7;
            float p2y = 0;

            float p3x = 3;
            float p3y = 10;


            // Slide right
            if (weight > 0.5)
            {
                float fullWeight1 = (weight - 0.5f) * 2; // 0 - 1, where 1 is moving curve completely right

                float adjustmentRange1 = 10 - x;
                float adjustment1 = adjustmentRange1 * fullWeight1;
                p2x += adjustment1;

                float adjustmentRange2 = 10 - p3x;
                float adjustment2 = adjustmentRange2 * fullWeight1;
                p3x += adjustment2;

            }
            else
            {
                //float fullWeight1 = weight * -2; // 0 - 1, where 1 is moving curve completely left

                //float adjustmentRange1 = p3x;
                float adjustment1 = p3x * (0.5f - weight) * 2;
                p3x += adjustment1;

                //float adjustmentRange2 = p2x;
                float adjustment2 = p2x * (weight - 0.5f) * 2;
                p2x += adjustment2;
            }





            //Point p2 = new Point(x, y);
            //Point p3 = new Point(y, x);


            t = Math.Clamp(t, 0, 1);

            //float t = 0.5f; // given example value
            float resultX = (1 - t) * (1 - t) * p2x + 2 * (1 - t) * t * p3x + t * t * p4.X;
            float resultY = (1 - t) * (1 - t) * p2y + 2 * (1 - t) * t * p3y + t * t * p4.Y;

            //Console.WriteLine(" resultX  =  " + resultX);
            return resultX;
        }
    }
}
