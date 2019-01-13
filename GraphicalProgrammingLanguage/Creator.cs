using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// this methods is used for creating an objects.
    /// </summary>
    abstract class Creator
    {
        /// <summary>
        /// this methods is used for shaping an objects.
        /// </summary>
        /// <param name="ShapeType"></param>
        /// <returns></returns>
        public abstract IShape getShape(string ShapeType);

    }
}
