using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektJPWP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ZaladujePoziom1(object sender, EventArgs e)
        {
            Poziom1 oknoPoziom1 = new Poziom1();
            oknoPoziom1.Show();
        }

        private void ZaładujPoziom2(object sender, EventArgs e)
        {
            Poziom2 oknoPoziom2 = new Poziom2();
            oknoPoziom2.Show();
        }

        private void ZaładujPomoc(object sender, EventArgs e)
        {
            Pomoc oknoPomoc = new Pomoc();
            oknoPomoc.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
