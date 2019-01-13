using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// this methods is used for delearing circle class
    /// </summary>
    public class Circle: IShape
    {
        public int x, y, radius;
        public Circle() : base()
        {

        }
        /// <summary>
        /// this methods calls the values of circle for x-axis, y-axis and radius
        /// </summary>
        /// <param name="x">x-axis</param>
        /// <param name="y">y-axis</param>
        /// <param name="radius">radius of a circle</param>
        public Circle(int x, int y, int radius)
        {

            this.radius = radius; //the only thingthat is different from shape
        }
        /// <summary>
        /// this methods draw the circle.
        /// </summary>
        /// <param name="g"> graphics parameter</param>
        public void draw(Graphics g)
        {
            try
            {
                Pen p = new Pen(Color.Black, 2);
                SolidBrush b = new SolidBrush(Color.Red);
                //g.FillEllipse(b, x, y, radius * 2, radius * 2);
                g.DrawEllipse(p, x - radius, y - radius, radius * 2, radius * 2);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        /// <summary>
        /// this methods sets the parameter of x-axis, y-axis and radius of a circle
        /// </summary>
        /// <param name="list"></param>
        public void set(params int[] list)
        {
            try
            {
                this.x = list[0];
                this.y = list[1];
                this.radius = list[2];

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
