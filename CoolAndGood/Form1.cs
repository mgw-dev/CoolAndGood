using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolAndGood.Properties;

namespace CoolAndGood
{
    public partial class CoolAndGood : Form
    {
        public CoolAndGood()
        {
            InitializeComponent();
        }

        private static Image MemeMan = Resources.Meme_Man_HD;

        Random R = new Random(DateTime.Now.Millisecond);
        private int magnitude = 10;
        private int movespeed = 1;

        PictureBox memeManBox = new PictureBox();

        Timer T = new Timer();

        private void CoolAndGood_Load(object sender, EventArgs e)
        {
            Width = SystemInformation.VirtualScreen.Width;
            Height = SystemInformation.VirtualScreen.Height;
            TransparencyKey = BackColor;
            Top = 0;
            Left = 0;
            TopMost = true;

            T.Tick += T_Tick;
            T.Interval = 1;
            T.Start();



            memeManBox = PictureBoxFromImg(MemeMan);
            memeManBox.Top = 250;
            memeManBox.Left = -memeManBox.Width;
            Controls.Add(memeManBox);

        }

        private void T_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new Point(Cursor.Position.X + R.Next(-magnitude, magnitude + 1), Cursor.Position.Y + R.Next(-magnitude, magnitude + 1));
            Cursor.Clip = new Rectangle(this.Location, this.Size);

            memeManBox.Left += movespeed;

            if (movespeed > 0 && memeManBox.Left > SystemInformation.VirtualScreen.Width)
            {
                memeManBox.Left += memeManBox.Width;
                memeManBox.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                movespeed *= -1;
            }

            if (movespeed < 0 && memeManBox.Left + memeManBox.Width < 0)
            {
                memeManBox.Left -= memeManBox.Width;
                memeManBox.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                movespeed *= -1;
            }

        }

        private PictureBox PictureBoxFromImg(Image img)
        {
            PictureBox newBox = new PictureBox();
            newBox.BackColor = Color.Transparent;
            newBox.SizeMode = PictureBoxSizeMode.Zoom;
            newBox.Image = img;
            newBox.Width = newBox.Image.Width * 2;
            newBox.Height = newBox.Image.Height * 2;
            return newBox;
        }

    }
}