using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// this methods is used to decleare the class of triangle.
    /// </summary>
    public class Triangle: IShape
    {
        public int x, y, width, height;
        /// <summary>
        /// width and height of triangle is decleared.
        /// </summary>
        public Triangle() : base()
        {
            width = 0;
            height = 0;
        }
        /// <summary>
        /// this methods passes the values of x-asis, y-axis, width and height of triangle
        /// /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Triangle(int x, int y, int width, int height)
        {

            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }
        /// <summary>
        /// this methods draws the triangle through a values of x-axis, y-axis height and width.
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            try
            {
                Point[] p = new Point[3];
                p[0].X = x;
                p[0].Y = y - (height / 2);

                p[1].X = x - (width / 2);
                p[1].Y = y + (height / 2);

                p[2].X = x + (width / 2);
                p[2].Y = y + (height / 2);
                Pen po = new Pen(Color.Red);
                g.DrawPolygon(po, p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }



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
