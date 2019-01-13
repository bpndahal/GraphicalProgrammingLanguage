using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// this methods passes the values of 3DRectangle
    /// </summary>
    public class _3DRectangle : IShape
    {
        public int x, y, width, height;

        /// <summary>
        /// this methods passes the values of width and height
        /// </summary>
        public _3DRectangle() : base()
        {
            width = 0;
            height = 0;
        }

        /// <summary>
        /// thi methods passes the integer values of x-axis, y-axis, width and height of 3drectangle
        /// </summary>
        /// <param name="x">x-axis</param>
        /// <param name="y">y-axis</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public _3DRectangle(int x, int y, int width, int height)
        {

            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }

        /// <summary>
        /// this method is used to draw the 3drectangle
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, x - (width / 2), y - (height / 2), width * 2, height * 2);
        }
        /// <summary>
        /// this methods sets the values of x-axis, y-axis, width and height of 3drectamngle
        /// </summary>
        /// <param name="list"></param>
        public void set(params int[] list)
        {
            this.x = list[0];
            this.y = list[1];
            this.width = list[2];
            this.height = list[3];
        }
    }
}
