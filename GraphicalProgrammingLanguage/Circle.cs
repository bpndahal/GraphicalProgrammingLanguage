using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    public class Circle: IShape
    {
        int x, y, radius;
        public Circle() : base()
        {

        }
        public Circle(int x, int y, int radius)
        {

            this.radius = radius; //the only thingthat is different from shape
        }
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillEllipse(b, x, y, radius * 2, radius * 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        public void set(params int[] list)
        {
            this.x = list[0];
            this.y = list[1];
            this.radius = list[2];
        }
    }
}
