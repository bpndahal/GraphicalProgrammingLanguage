using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    abstract class Creator
    {
        public abstract IShape getShape(string ShapeType);

    }
}
