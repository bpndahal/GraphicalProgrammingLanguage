using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    public interface IShape
    {
        void draw(Graphics g);

        void set(params int[] list);
    }
}
