using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sniffer
{
    public partial class LCDTest : Form
    {
        public LCDTest()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FadeOut();
        }

        int[] targetColor = { 0, 0, 0 };
        int[] fadeRGB = new int[3];
        private void FadeOut()
        {
            fadeRGB[0] = label_fadeTxt1.ForeColor.R;
            fadeRGB[1] = label_fadeTxt1.ForeColor.G;
            fadeRGB[2] = label_fadeTxt1.ForeColor.B;

            if (fadeRGB[0] > this.BackColor.R)
            {
                fadeRGB[0]--;
            }
            else if (fadeRGB[0] < this.BackColor.R)
            {
                fadeRGB[0]++;
            }

            if (fadeRGB[1] > this.BackColor.G)
            {
                fadeRGB[1]--;
            }
            else if (fadeRGB[1] < this.BackColor.G)
            {
                fadeRGB[1]++;
            }

            if (fadeRGB[2] > this.BackColor.B)
            {
                fadeRGB[2]--;
            }
            else if (fadeRGB[2] < this.BackColor.B)
            {
                fadeRGB[2]++;
            }

            if (fadeRGB[0] == this.BackColor.R &&
               fadeRGB[1] == this.BackColor.G &&
               fadeRGB[2] == this.BackColor.B)
            {
                timer1.Stop();
            }

            label_fadeTxt1.ForeColor = Color.FromArgb(fadeRGB[0], fadeRGB[1], fadeRGB[2]);
        }

        private void LCDTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.D1)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (BackColor == Color.White)
                    BackColor = Color.Red;
                else if (BackColor == Color.Red)
                    BackColor = Color.Green;
                else if (BackColor == Color.Green)
                    BackColor = Color.FromArgb(0, 66, 117);
                else if (BackColor == Color.FromArgb(0, 66, 117))
                    BackColor = Color.Black;
                else
                    BackColor = Color.White;
            }
        }
    }
}
