using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// this methods is decleared for rectangle class
    /// </summary>
    public class Rectangle: IShape
    {
        /// <summary>
        /// this methods decleare the integer type for x-axis, y-axis, width and height for rectangle
        /// </summary>
        public int x, y, width, height;
        public Rectangle() : base()
        {
            width = 0;
            height = 0;
        }
        /// <summary>
        /// this methods passes the values of x-axis, y-axis, height and width of rectangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(int x, int y, int width, int height)
        {

            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }
        /// <summary>
        /// this methods draw the rectangle
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            try
            {
                Pen p = new Pen(Color.Black, 2);
                g.DrawRectangle(p, x - (width / 2), y - (height / 2), width * 2, height * 2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        /// <summary>
        /// this methods sets the values of x-axis, y-axis, width and height of 3drectamngle
        /// </summary>
        /// <param name="list">set parameter</param>
        public void set(params int[] list)
        {
            try
            {
                this.x = list[0];
                this.y = list[1];
                this.width = list[2];
                this.height = list[3];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
