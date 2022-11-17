using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace SemaAndCo
{
    public partial class Captcha : UserControl
    {
        private string text = String.Empty;
        public Captcha()
        {
            InitializeComponent();
        }

        public void Renew()
        {
            captchaPictureBox.Image = CreateImage(captchaPictureBox.Width, captchaPictureBox.Height);
        }
        public bool CheckText(string text)
        {
            return text.ToLower() == this.text.ToLower();
        }

        private Bitmap CreateImage(int width, int height)
        {
            Random rnd = new Random();
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

            Bitmap result = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage((Image)result);

            g.Clear(Color.Aqua);

            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            Font stringFont = new Font("DS Brushes", 50);
            double textWidth;
            double textHeight;

            using (Bitmap tempImage = new Bitmap(318, 177))
            {
                SizeF stringSize = Graphics.FromImage(tempImage).MeasureString(text, stringFont);
                textWidth = stringSize.Width;
                textHeight = stringSize.Height;
            }

            int Xpos = rnd.Next(0, Width - (int)textWidth - 15);
            int Ypos = rnd.Next(15, Height - (int)textHeight - 15);

            for (int i = 0; i < 100; i++)
            {
                g.DrawLine(Pens.SteelBlue,
                new Point(Width - rnd.Next(Width), 0),
                new Point(Width - rnd.Next(Width), Height - 1));
            }

            for (int i = 0; i < 50; i++)
            {
                g.DrawLine(Pens.SteelBlue,
                new Point(0, Height - rnd.Next(Height)),
                new Point(Width - 1, Height - rnd.Next(Height)));
            }

            g.DrawString(text,
            stringFont,
            Brushes.Maroon,
            new PointF(Xpos, Ypos));

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 3 == 0)
                        result.SetPixel(i, j, Color.Indigo);

            return result;
        }
    }
}
