using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektJPWP
{
    internal class smieci
    {
        public Image smieciPic;
        public int width;
        public int height;
        public Point position = new Point();
        public bool active = false;
        public Rectangle rect;
        public smieci(string imageLocation)
        {
            smieciPic = Image.FromFile(imageLocation);
            width = 50;
            height = 70;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

    }
}
