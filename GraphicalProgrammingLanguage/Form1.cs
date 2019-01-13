using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class GraphicsProgram : Form
    {
        public GraphicsProgram()
        {
            InitializeComponent();
        }

        Creator factory = new FactoryClass();
        Pen myPen = new Pen(Color.Red);
        int x = 0, y = 0, width, height, radius, point, repeatval, counter;
        int loop = 0, kStart = 0, ifcounter = 0;
        private bool loopcheck;
        public void moveTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }

        public void drawTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }
        public int getX()
        {
            return x;
        }


        public int getY()
        {
            return y;
        }

        public void drawLine(int toX, int toY)
        {
            Graphics g = pnlOutput.CreateGraphics();
            g.DrawLine(myPen, x, y, toX, toY);
            moveTo(toX, toY);
        }

        public void drawRectangle(int width, int height)
        {
            Graphics g = pnlOutput.CreateGraphics();
            g.DrawRectangle(myPen, x - width, y - height, width * 2, height * 2);

        }

        public void drawCircle(int radius)
        {
            Graphics g = pnlOutput.CreateGraphics();
            Rectangle rect = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(myPen, rect);
        }
        public void drawTriangle(int width, int height)
        {
            Graphics g = pnlOutput.CreateGraphics();
            Point[] p = new Point[3];
            p[0].X = x;
            p[0].Y = y - (height / 2);

            p[1].X = x - (width / 2);
            p[1].Y = y + (height / 2);

            p[2].X = x + (width / 2);
            p[2].Y = y + (height / 2);

            g.DrawPolygon(myPen, p);
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            Graphics g = pnlOutput.CreateGraphics();



            string command = txtInput.Text.ToLower();
            string[] commandline = command.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < commandline.Length; k++)
            {

                string[] cmd = commandline[k].Split(' ');
                if (cmd[0].Equals("moveto") == true)
                {
                    pnlOutput.Refresh();
                    string[] param = cmd[1].Split(',');

                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {

                        Int32.TryParse(param[0], out x);
                        Int32.TryParse(param[1], out y);
                        moveTo(x, y);
                    }


                }
                else if (cmd[0].Equals("radius") == true)
                {

                    int r;
                    if (cmd[1].Equals("=") == true)
                    {
                        Int32.TryParse(cmd[2], out radius);
                    }
                    else if (cmd[1].Equals("+") == true)
                    {
                        Int32.TryParse(cmd[2], out r);
                        radius = radius + r;
                    }
                    else if (cmd[1].Equals("-") == true)
                    {
                        for (int rc = 0; rc < repeatval; rc++)
                        {
                            Int32.TryParse(cmd[2], out r);
                            radius = radius - r;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Syntax Error");
                    }
                }
                else if (cmd[0].Equals("width") == true)
                {

                    int w;
                    if (cmd[1].Equals("=") == true)
                    {
                        Int32.TryParse(cmd[2], out width);
                    }
                    else if (cmd[1].Equals("+") == true)
                    {
                        Int32.TryParse(cmd[2], out w);
                        width = width + w;

                    }
                    else if (cmd[1].Equals("-") == true)
                    {
                        for (int rc = 0; rc < repeatval; rc++)
                        {
                            Int32.TryParse(cmd[2], out w);
                            width = width - w;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Syntax Error");
                    }
                }
                else if (cmd[0].Equals("height") == true)
                {

                    int h;
                    if (cmd[1].Equals("=") == true)
                    {
                        Int32.TryParse(cmd[2], out height);
                    }
                    else if (cmd[1].Equals("+") == true)
                    {
                        Int32.TryParse(cmd[2], out h);
                        height = height + h;

                    }
                    else if (cmd[1].Equals("-") == true)
                    {
                        for (int rc = 0; rc < repeatval; rc++)
                        {
                            Int32.TryParse(cmd[2], out h);
                            height = height - h;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Syntax Error");
                    }
                }
                else if (cmd[0].Equals("drawto") == true)
                {
                    string[] param = cmd[1].Split(',');
                    int x = 0, y = 0;
                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {
                        Int32.TryParse(param[0], out x);
                        Int32.TryParse(param[1], out y);
                        drawTo(x, y);
                    }

                }
                else if (cmd[0].Equals("drawline") == true)
                {
                    string[] param = cmd[1].Split(',');
                    int toX = 0, toY = 0;
                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {
                        Int32.TryParse(param[0], out toX);
                        Int32.TryParse(param[1], out toY);
                        IShape line = factory.getShape("line");
                        line.set(x, y, toX, toY);
                        line.draw(g);
                    }

                }
                else if (cmd[0].Equals("circle") == true)
                {
                    if (cmd.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {

                        if (cmd[1].Equals("radius") == true)
                        {
                            IShape circle = factory.getShape("circle");
                            Circle c = new Circle();
                            c.set(x, y, radius);
                            c.draw(g);

                        }
                        else
                        {


                            Int32.TryParse(cmd[1], out radius);
                            IShape circle = factory.getShape("circle");
                            Circle c = new Circle();
                            c.set(x, y, radius);
                            c.draw(g);
                        }
                    }

                }
                else if (cmd[0].Equals("rectangle") == true)
                {
                    if (cmd.Length < 2)
                    {
                        MessageBox.Show("Invalid Parameter ");
                    }
                    else
                    {
                        string[] param = cmd[1].Split(',');
                        if (param.Length < 2)
                        {
                            MessageBox.Show("Invalid Parameter ");
                        }
                        else
                        {
                            Int32.TryParse(param[0], out width);
                            Int32.TryParse(param[1], out height);
                            IShape circle = factory.getShape("rectangle");
                            Rectangle r = new Rectangle();
                            r.set(x, y, width, height);
                            r.draw(g);
                        }
                    }
                }
                else if (cmd[0].Equals("3drectangle") == true)
                {
                    if (cmd.Length < 2)
                    {
                        MessageBox.Show("Invalid Parameter ");
                    }
                    else
                    {
                        string[] param = cmd[1].Split(',');
                        if (param.Length < 2)
                        {
                            MessageBox.Show("Invalid Parameter ");
                        }
                        else
                        {
                            Int32.TryParse(param[0], out width);
                            Int32.TryParse(param[1], out height);
                            IShape circle = factory.getShape("3drectangle");
                            _3DRectangle r = new _3DRectangle();
                            r.set(x, y, width, height);
                            r.draw(g);
                        }
                    }
                }
                else if (cmd[0].Equals("triangle") == true)
                {
                    string[] param = cmd[1].Split(',');
                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {

                        Int32.TryParse(param[0], out width);
                        Int32.TryParse(param[1], out height);
                        IShape circle = factory.getShape("triangle");
                        Triangle r = new Triangle();
                        r.set(x, y, width, height);
                        r.draw(g);
                    }

                }
                else if (cmd[0].Equals("repeat") == true)
                {
                    Int32.TryParse(cmd[1], out repeatval);

                    if (cmd[2].Equals("circle") == true)
                    {
                        int r;
                        Int32.TryParse(cmd[4], out r);
                        if (cmd[3].Equals("+") == true)
                        {

                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                radius = radius + r;
                                IShape circle = factory.getShape("circle");
                                Circle c = new Circle();
                                c.set(x, y, radius);
                                c.draw(g);
                            }
                        }
                        else if (cmd[3].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                radius = radius - r;
                                IShape circle = factory.getShape("circle");
                                Circle c = new Circle();
                                c.set(x, y, radius);
                                c.draw(g);
                            }

                        }
                    }
                    else if (cmd[2].Equals("rectangle") == true)
                    {
                        int increment;
                        Int32.TryParse(cmd[4], out increment);
                        if (cmd[3].Equals("+") == true)
                        {

                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                width = width + increment;
                                height = height + increment;
                                IShape rectangle = factory.getShape("rectangle");
                                Rectangle rec = new Rectangle();
                                rec.set(x, y, width, height);
                                rec.draw(g);
                            }
                        }
                        else if (cmd[3].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                width = width - increment;
                                height = height - increment;
                                IShape rectangle = factory.getShape("rectangle");
                                Rectangle rec = new Rectangle();
                                rec.set(x, y, width, height);
                                rec.draw(g);
                            }

                        }
                    }

                    else if (cmd[2].Equals("triangle") == true)
                    {
                        int increment;
                        Int32.TryParse(cmd[4], out increment);
                        if (cmd[3].Equals("+") == true)
                        {

                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                width = width + increment;
                                height = height + increment;
                                IShape circle = factory.getShape("triangle");
                                Triangle t = new Triangle();
                                t.set(x, y, width, height);
                                t.draw(g);
                            }
                        }
                        else if (cmd[3].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                width = width - increment;
                                height = height - increment;
                                IShape circle = factory.getShape("triangle");
                                Triangle t = new Triangle();
                                t.set(x, y, width, height);
                                t.draw(g);
                            }

                        }

                    }
                }
                else if (cmd[0].Equals("loop") == true)
                {
                    loopcheck = true;
                    if (loop == 0)
                    {
                        Int32.TryParse(cmd[1], out counter);
                        kStart = k;
                    }
                }
                else if (cmd[0].Equals("if"))
                {
                    if (cmd[1].Equals("counter") && cmd[2].Equals("=") && cmd[4].Equals("then"))
                    {
                        Int32.TryParse(cmd[3], out ifcounter);
                        if (ifcounter == (loop + 1))
                        {

                            if (cmd[5].Equals("radius"))
                            {
                                if (cmd[6].Equals("="))
                                {
                                    Int32.TryParse(cmd[7], out radius);
                                }
                                else
                                if (cmd[6].Equals("+"))
                                {
                                    int r;
                                    Int32.TryParse(cmd[7], out r);
                                    radius += r;
                                    //MessageBox.Show("you are going right buddy");

                                }
                                else
                                if (cmd[6].Equals("-"))
                                {
                                    int r;
                                    Int32.TryParse(cmd[7], out r);
                                    radius = radius - r;
                                }

                            }
                            else if (cmd[5].Equals("width"))
                            {
                                if (cmd[6].Equals("="))
                                {
                                    Int32.TryParse(cmd[7], out width);
                                    Console.WriteLine(width);
                                }
                                else
                                if (cmd[6].Equals("+"))
                                {
                                    int w;
                                    Int32.TryParse(cmd[7], out w);
                                    width = width + w;
                                }
                                else
                                if (cmd[6].Equals("-"))
                                {
                                    int w;
                                    Int32.TryParse(cmd[7], out w);
                                    width = width - w;
                                }
                            }
                            else if (cmd[5].Equals("height"))
                            {
                                if (cmd[6].Equals("="))
                                {
                                    Int32.TryParse(cmd[7], out height);
                                    Console.WriteLine(height);
                                }
                                else
                                if (cmd[6].Equals("+"))
                                {
                                    int h;
                                    Int32.TryParse(cmd[7], out h);
                                    height = height + h;
                                }
                                else
                                if (cmd[6].Equals("-"))
                                {
                                    int h;
                                    Int32.TryParse(cmd[7], out h);
                                    height = height - h;
                                }
                            }
                        }
                    }
                }
                else
                if (cmd[0].Equals("endif"))
                {
                    if (cmd[1].Equals("radius"))
                    {
                        if (cmd[2].Equals("="))
                        {
                            int endifvar;
                            Int32.TryParse(cmd[3], out endifvar);
                            if (radius == endifvar)
                            {
                                break;
                            }
                        }

                    }
                    else
                    if (cmd[1].Equals("width"))
                    {
                        if (cmd[2].Equals("="))
                        {
                            int endifvar;
                            Int32.TryParse(cmd[3], out endifvar);
                            if (width == endifvar)
                            {
                                break;
                            }
                        }

                    }
                    else
                    if (cmd[1].Equals("height"))
                    {
                        if (cmd[2].Equals("="))
                        {
                            int endifvar;
                            Int32.TryParse(cmd[3], out endifvar);
                            if (height == endifvar)
                            {
                                break;
                            }
                        }

                    }

                }
                else if (cmd[0].Equals("endloop") == true)
                {
                    loopcheck = false;
                    if (counter > 0)
                    {
                        loop++;
                    }
                    if (counter == loop)
                    {
                        counter = 0;
                        loop = 0;

                    }
                    else
                    {
                        k = kStart;
                    }
                }
                else if (loopcheck == true)
                {
                    MessageBox.Show("invalid Loop Command");
                }
                else if (!cmd[0].Equals(null))
                {
                    int errorLine = k + 1;
                    MessageBox.Show("Invalid command recognised on line " + errorLine, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
