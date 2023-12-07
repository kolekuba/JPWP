using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektJPWP
{
    public partial class Poziom1 : Form
    {



        List<smieci> smieci = new List<smieci>();
        smieci SelectedSmieci;
        int indexValue;
        int xPos = 5;
        int yPos = 5;
        List<string> imageLocation = new List<string>();
        int smieciNumber = -1;
        int totalsmieci = 0;
        int lineAnimation = 0;
        private Random random = new Random();
 


        public Poziom1()
        {
            InitializeComponent();
            SetUpApp();
        }

       


        private void SetUpApp()    //funkcja
        {
            imageLocation = Directory.GetFiles("smieci", "*.png").ToList();
            totalsmieci = imageLocation.Count;

            for (int i = 0; i < totalsmieci; i++)
            {
                MakeSmieci();
            }
            label2.Text = "Smiec " + (smieciNumber + 1) + " z " + totalsmieci;

            
        }

        private void MakeSmieci()    //funkcja
        {
            smieciNumber++;
            int smieciWidth = 50; // Szerokość obiektu śmieci
            int smieciHeight = 50; // Wysokość obiektu śmieci
            bool overlap;

            do
            {
                overlap = false;

                xPos = random.Next(0, this.ClientSize.Width - smieciWidth);
                yPos = random.Next(0, this.ClientSize.Height - smieciHeight);

                Rectangle smieciRect = new Rectangle(xPos, yPos, smieciWidth, smieciHeight);

                // Sprawdzenie, czy śmieci nie nakładają się na obszar Tekstu
                if (
                    smieciRect.IntersectsWith(label2.Bounds))
                {
                    overlap = true;
                }
            } while (overlap);

            smieci newsmieci = new smieci(imageLocation[smieciNumber]);

            // Ustawienie nowej pozycji dla śmieci
            newsmieci.position.X = xPos;
            newsmieci.position.Y = yPos;

            newsmieci.rect.X = newsmieci.position.X;
            newsmieci.rect.Y = newsmieci.position.Y;

            smieci.Add(newsmieci);

        }

       
        private void Poziom1_Load(object sender, EventArgs e)
        {

        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {

            Point mousePosition = new Point(e.X, e.Y);
            foreach (smieci newsmieci in smieci)
            {
                if ( SelectedSmieci== null)
                {
                    if (newsmieci.rect.Contains(mousePosition))
                    {
                        SelectedSmieci = newsmieci;
                        newsmieci.active = true;
                        indexValue = smieci.IndexOf(newsmieci);
                        label2.Text = "Smieci " + (indexValue + 1) + " z " + totalsmieci;
                    }
                }
            }

        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedSmieci != null)
            {
                SelectedSmieci.position.X = e.X - (SelectedSmieci.width / 2);
                SelectedSmieci.position.Y = e.Y - (SelectedSmieci.height / 2);
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            foreach (smieci tempSmieci in smieci)
            {
                tempSmieci.active = false;
            }
            SelectedSmieci = null;
            lineAnimation = 0;
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            foreach (smieci smieci in smieci)
            {
                e.Graphics.DrawImage(smieci.smieciPic, smieci.position.X, smieci.position.Y, smieci.width, smieci.height);
                Pen outline;
                if (smieci.active)
                {
                    outline = new Pen(Color.Maroon, lineAnimation);
                }
                else
                {
                    outline = new Pen(Color.Transparent, 1);
                }
                e.Graphics.DrawRectangle(outline, smieci.rect);
            }
            if (SelectedSmieci != null)
            {
                e.Graphics.DrawImage(SelectedSmieci.smieciPic, SelectedSmieci.position.X, SelectedSmieci.position.Y, SelectedSmieci.width, SelectedSmieci.height);
            }

           
        }

        
        private void FormTimerEvent(object sender, EventArgs e)
        {
            foreach (smieci smieci in smieci)
            {
                smieci.rect.X = smieci.position.X;
                smieci.rect.Y = smieci.position.Y;
            }
            if (SelectedSmieci != null)
            {
                if (lineAnimation < 5)
                {
                    lineAnimation++;
                }
            }
            this.Invalidate();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Poziom 1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(328, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 61);
            this.label2.TabIndex = 1;
            this.label2.Text = "Śmieć 1 z 10";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTimer
            // 
            this.FormTimer.Enabled = true;
            this.FormTimer.Interval = 20;
            this.FormTimer.Tick += new System.EventHandler(this.FormTimerEvent);
            // 
            // Poziom1
            // 
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(871, 506);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Poziom1";
            this.Load += new System.EventHandler(this.Poziom1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     
    }
}



