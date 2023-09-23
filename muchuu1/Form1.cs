using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace muchuu1
{
    public partial class Form1 : Form
    {
        public static Bitmap iya(Bitmap bmp)
        {
            Random random = new Random();
            int rnt = random.Next(1, 4);
            int rnt1 = random.Next(1, 17);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            switch (random.Next(1, 7))
            {
                case 1:
                    for (int counter = 1; counter < rgbValues.Length; counter += rnt)
                        rgbValues[counter] = (byte)(rgbValues[counter] + rnt1);
                    break;
                case 2:
                    for (int counter = 1; counter < rgbValues.Length; counter += rnt)
                        rgbValues[counter] = (byte)(rgbValues[counter] * -rnt1);
                    break;
                case 3:
                    for (int counter = 1; counter < rgbValues.Length; counter += rnt)
                        rgbValues[counter] = (byte)(rgbValues[counter] / rnt1);
                    break;
                case 4:
                    for (int counter = 1; counter < rgbValues.Length; counter += rnt)
                        rgbValues[counter] = (byte)(rgbValues[counter] - rnt1);
                    break;
                case 5:
                    for (int counter = 1; counter < rgbValues.Length; counter += rnt)
                        rgbValues[counter] = (byte)(rgbValues[counter] * rnt1);
                    break;
                case 6:
                    for (int counter = 1; counter < rgbValues.Length; counter += rnt)
                        rgbValues[counter] = (byte)( Math.Pow(rgbValues[counter], rnt1));
                    break;
            }


            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            bmp.UnlockBits(bmpData);

            return bmp;
        }
        public Form1()
        {
            InitializeComponent();
        }
        FontFamily[] fontFamilies = new FontFamily[] { FontFamily.GenericMonospace, FontFamily.GenericSansSerif, FontFamily.GenericSerif, FontFamily.GenericMonospace };
        ContentAlignment[] contentAlignments = new ContentAlignment[] { ContentAlignment.BottomCenter, ContentAlignment.BottomLeft, ContentAlignment.BottomRight, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.TopCenter, ContentAlignment.TopLeft, ContentAlignment.TopRight };
        AnchorStyles[] AnchorStyles = new AnchorStyles[] { System.Windows.Forms.AnchorStyles.None, System.Windows.Forms.AnchorStyles.Top, System.Windows.Forms.AnchorStyles.Bottom, System.Windows.Forms.AnchorStyles.Left, System.Windows.Forms.AnchorStyles.Right };
        private Cursor[] CursorList()
        {

            return new Cursor[] {
                                     Cursors.AppStarting, Cursors.Arrow, Cursors.Cross,
                                     Cursors.Default, Cursors.Hand, Cursors.Help,
                                     Cursors.HSplit, Cursors.IBeam, Cursors.No,
                                     Cursors.NoMove2D, Cursors.NoMoveHoriz, Cursors.NoMoveVert,
                                     Cursors.PanEast, Cursors.PanNE, Cursors.PanNorth,
                                     Cursors.PanNW, Cursors.PanSE, Cursors.PanSouth,
                                     Cursors.PanSW, Cursors.PanWest, Cursors.SizeAll,
                                     Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE,
                                     Cursors.SizeWE, Cursors.UpArrow, Cursors.VSplit, Cursors.WaitCursor};
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            Bitmap ry = iya(muchuu1.Properties.Resources._382699809000211);
            IntPtr Hicon = ry.GetHicon();
            Icon myIcon = Icon.FromHandle(Hicon);
            this.Icon = myIcon;
            myIcon.Dispose();
            this.Cursor = CursorList()[random.Next(CursorList().Length)];
            this.RightToLeft = (RightToLeft)random.Next(0,2);
            this.FormBorderStyle = (FormBorderStyle)random.Next(1,7);
            this.Size = new Size(random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height));
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                var request = WebRequest.Create("https://picsum.photos/" + random.Next(1, Screen.PrimaryScreen.Bounds.Height));

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    urlToolStripMenuItem.Text = response.ResponseUri.ToString();
                    switch (random.Next(1,2))
                    {
                        case 0:
                            bg.Image = Bitmap.FromStream(stream);
                            break;
                            case 1:
                            Bitmap str = (Bitmap)Bitmap.FromStream(stream);
                            Bitmap result_image = iya(str);
                            bg.Image = result_image;
                            break;
                    }
                    response.Close();
                }
            }
            catch
            {
                urlToolStripMenuItem.Text = "";
                var bmpScreenshot = new Bitmap(random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height),
                                               PixelFormat.Format32bppArgb);

                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                gfxScreenshot.CopyFromScreen(random.Next(Screen.PrimaryScreen.Bounds.Width)/4, random.Next(Screen.PrimaryScreen.Bounds.Height)/4,
                                            0,
                                            0,
                                            Screen.PrimaryScreen.Bounds.Size,
                                            CopyPixelOperation.SourceCopy);
                Bitmap result_image = iya(bmpScreenshot);
                bg.Image = result_image;

            }
            for (int i = 0; i < random.Next(16); i++)
            {
                Button newButton = new Button();
                int stringlen = random.Next(4, 50);
                int randValue;
                string str = "";
                char letter;
                for (int j = 0; j < stringlen; j++)
                {

                    randValue = random.Next(0, 32767);

                    letter = Convert.ToChar(randValue);

                    str = str + letter;
                }
                newButton.Text = str;
                newButton.Location = new Point(random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height));
                newButton.Click += NewButton_Click; ;
                newButton.Size = new Size(random.Next(Screen.PrimaryScreen.Bounds.Width/2), random.Next(Screen.PrimaryScreen.Bounds.Height/2));
                newButton.Font = new Font(fontFamilies[random.Next(fontFamilies.Length)],random.Next(1,64));
                newButton.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newButton.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newButton.FlatStyle = (FlatStyle)random.Next(3);
                newButton.TextAlign = contentAlignments[contentAlignments.Length - 1];
                newButton.Anchor = AnchorStyles[random.Next(AnchorStyles.Length - 1)] | AnchorStyles[random.Next(AnchorStyles.Length - 1)];
                newButton.Cursor = CursorList()[random.Next(CursorList().Length)];
                bg.Controls.Add(newButton);
                this.Text = str;
            }
            for (int i = 0; i < random.Next(16); i++)
            {
                Label newLabel = new Label();
                int stringlen = random.Next(4, 50);
                int randValue;
                string str = "";
                char letter;
                for (int j = 0; j < stringlen; j++)
                {

                    randValue = random.Next(0, 32767);

                    letter = Convert.ToChar(randValue);

                    str = str + letter;
                }
                newLabel.Text = str;
                newLabel.Location = new Point(random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height));
                newLabel.Click += NewButton_Click; ;
                newLabel.Size = new Size(random.Next(Screen.PrimaryScreen.Bounds.Width / 4), random.Next(Screen.PrimaryScreen.Bounds.Height / 4));
                newLabel.Font = new Font(fontFamilies[random.Next(fontFamilies.Length)], random.Next(1, 64));
                newLabel.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newLabel.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newLabel.FlatStyle = (FlatStyle)random.Next(3);
                newLabel.TextAlign = contentAlignments[contentAlignments.Length - 1];
                newLabel.Anchor = AnchorStyles[random.Next(AnchorStyles.Length - 1)] | AnchorStyles[random.Next(AnchorStyles.Length - 1)];
                newLabel.Cursor = CursorList()[random.Next(CursorList().Length)];
                bg.Controls.Add(newLabel);
                this.Text = str;
            }
            for (int i = 0; i < random.Next(16); i++)
            {
                RadioButton newRadioButton = new RadioButton();
                int stringlen = random.Next(4, 50);
                int randValue;
                string str = "";
                char letter;
                for (int j = 0; j < stringlen; j++)
                {

                    randValue = random.Next(0, 32767);

                    letter = Convert.ToChar(randValue);

                    str = str + letter;
                }
                newRadioButton.Text = str;
                newRadioButton.Location = new Point(random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height));
                newRadioButton.Click += NewButton_Click; ;
                newRadioButton.Size = new Size(random.Next(Screen.PrimaryScreen.Bounds.Width / 4), random.Next(Screen.PrimaryScreen.Bounds.Height / 4));
                newRadioButton.Font = new Font(fontFamilies[random.Next(fontFamilies.Length)], random.Next(1, 64));
                newRadioButton.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newRadioButton.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newRadioButton.FlatStyle = (FlatStyle)random.Next(3);
                newRadioButton.TextAlign = contentAlignments[contentAlignments.Length - 1];
                newRadioButton.Anchor = AnchorStyles[random.Next(AnchorStyles.Length - 1)] | AnchorStyles[random.Next(AnchorStyles.Length - 1)];
                newRadioButton.Cursor = CursorList()[random.Next(CursorList().Length)];
                bg.Controls.Add(newRadioButton);
                this.Text = str;
            }
            for (int i = 0; i < random.Next(16); i++)
            {
                CheckBox newCheckBox = new CheckBox();
                int stringlen = random.Next(4, 50);
                int randValue;
                string str = "";
                char letter;
                for (int j = 0; j < stringlen; j++)
                {

                    randValue = random.Next(0, 32767);

                    letter = Convert.ToChar(randValue);

                    str = str + letter;
                }
                newCheckBox.Text = str;
                newCheckBox.Location = new Point(random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height));
                newCheckBox.Click += NewButton_Click; ;
                newCheckBox.Size = new Size(random.Next(Screen.PrimaryScreen.Bounds.Width / 4), random.Next(Screen.PrimaryScreen.Bounds.Height / 4));
                newCheckBox.Font = new Font(fontFamilies[random.Next(fontFamilies.Length)], random.Next(1, 64));
                newCheckBox.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newCheckBox.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                newCheckBox.FlatStyle = (FlatStyle)random.Next(3);
                newCheckBox.TextAlign = contentAlignments[contentAlignments.Length - 1];
                newCheckBox.Anchor = AnchorStyles[random.Next(AnchorStyles.Length - 1)] | AnchorStyles[random.Next(AnchorStyles.Length - 1)];
                newCheckBox.Cursor = CursorList()[random.Next(CursorList().Length)];
                bg.Controls.Add(newCheckBox);
                this.Text = str;
            }
            bg.Invalidate();
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            switch (random.Next(1,8))
            {
                case 1:
                    bytebeat(random.Next(4000), random.Next(5));
                    break;
                case 2:
                    Thread thread = new Thread(() => Console.Beep(random.Next(37, 32767), random.Next(10000)));
                    thread.Start();
                    break;
                    case 3:
                    SystemSounds.Asterisk.Play();
                    break;
                case 4:
                    SystemSounds.Beep.Play();
                    break;
                case 5:
                    SystemSounds.Exclamation.Play();
                    break;
                case 6:
                    SystemSounds.Hand.Play();
                    break;
                case 7:
                    SystemSounds.Question.Play();
                    break;
            }
            
        }

        void bytebeat(int sample_rate,int seconds)
        {
            Random random = new Random();
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());    
                writer.Write((UInt32)0);               
                writer.Write("WAVE".ToCharArray());   

                writer.Write("fmt ".ToCharArray());    
                writer.Write((UInt32)16);              
                writer.Write((UInt16)1);               

                var channels = 1;
                var bits_per_sample = 8;

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8));   
                writer.Write((UInt16)(channels * bits_per_sample / 8));                 
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                var data = new byte[sample_rate * seconds];

                for (var t = 0; t < data.Length; t++)
                    data[t] = (byte)(
                        random.Next(32767)
                        );

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                           
                writer.Write((UInt32)(writer.BaseStream.Length - 8));   

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).Play();
            }
        }
        private void bg_Paint(object sender, PaintEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(64); i++)
            {



                Button newButton = new Button();
                int stringlen = random.Next(4, 10);
                int randValue;
                string str = "";
                char letter;
                for (int j = 0; j < stringlen; j++)
                {

                    randValue = random.Next(0, 32767);

                    letter = Convert.ToChar(randValue);

                    str = str + letter;
                }
                FontFamily[] fontFamilies = new FontFamily[] { FontFamily.GenericMonospace, FontFamily.GenericSansSerif, FontFamily.GenericSerif, FontFamily.GenericMonospace };
                e.Graphics.DrawString(str, new Font(fontFamilies[random.Next(fontFamilies.Length)], random.Next(1, 100)), new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255))), random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height));
                int rande2 = random.Next(1,4);
                Bitmap ry = iya(muchuu1.Properties.Resources._382699809000211);
                e.Graphics.DrawImage(ry, random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height), muchuu1.Properties.Resources._382699809000211.Width*rande2, muchuu1.Properties.Resources._382699809000211.Height*rande2);
                Bitmap[] icons = { SystemIcons.Application.ToBitmap(), SystemIcons.Asterisk.ToBitmap(), SystemIcons.Error.ToBitmap(), SystemIcons.Exclamation.ToBitmap(), SystemIcons.Hand.ToBitmap(), SystemIcons.Information.ToBitmap(), SystemIcons.Shield.ToBitmap(), SystemIcons.Warning.ToBitmap(), SystemIcons.WinLogo.ToBitmap(), };
                int rande3 = random.Next(icons.Length);
                Bitmap bitmap = iya(icons[rande3]);
                e.Graphics.DrawImage(bitmap, random.Next(Screen.PrimaryScreen.Bounds.Width), random.Next(Screen.PrimaryScreen.Bounds.Height), icons[rande3].Width * rande2, icons[rande3].Height * rande2);
                
            }
        }

        private void genbutton_Click(object sender, EventArgs e)
        {
            muretry = true;
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void httpspicsumphotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://picsum.photos/");
        }

        private void urlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(urlToolStripMenuItem.Text) == false)
            {
                Process.Start(urlToolStripMenuItem.Text);
            }
        }
        bool muretry = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (muretry == false)
            {
                Environment.Exit(0);
            }
            else { }
        }
    }
}
