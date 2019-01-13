using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// this methods passes the values on class of an objects
    /// </summary>
     class FactoryClass: Creator
    {
        /// <summary>
        /// this methods passes the shape of any objects.
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public override IShape getShape(string shapeType)
        {
            shapeType = shapeType.ToLower().Trim(); //you could argue that you want a specific word string to create an object but I'm allowing any case combination


            if (shapeType.Equals("circle"))
            {
                return new Circle();

            }
            else if (shapeType.Equals("rectangle"))
            {
                return new Rectangle();

            }
            else if (shapeType.Equals("3drectangle"))
            {
                return new _3DRectangle();

            }
            else if (shapeType.Equals("triangle"))
            {
                return new Rectangle();

            }
            else
            {
                //if we get here then what has been passed in is inkown so throw an appropriate exception
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }
        }
        }
}
