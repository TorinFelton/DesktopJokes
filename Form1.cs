using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Jokes_App
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(UAction uAction, int uParam, StringBuilder lpvParam, int fuWinIni);

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            changeJokeNow.Start(); // start the joke change timer
            
        }
        public enum UAction
        {
            /// <summary>
            /// set the desktop background image
            /// </summary>
            SPI_SETDESKWALLPAPER = 0x0014,
            /// <summary>
            /// set the desktop background image
            /// </summary>
            SPI_GETDESKWALLPAPER = 0x0073,
        }
        public static string GetBackgroud()
        {
            StringBuilder s = new StringBuilder(300);
            SystemParametersInfo(UAction.SPI_GETDESKWALLPAPER, 300, s, 0);
            return s.ToString();
        }
        /// <summary>
        /// set the desktop background image
        /// </summary>
        /// <param name="fileName">the path of image</param>
        /// <returns></returns>
        public static int SetBackgroud(string fileName)
        {
            int result = 0;
            if (File.Exists(fileName))
            {
                StringBuilder s = new StringBuilder(fileName);
                result = SystemParametersInfo(UAction.SPI_SETDESKWALLPAPER, 0, s, 0x2);
            }
            return result;
        }
        /// <summary>
        /// set the option of registry
        /// </summary>
        /// <param name="optionsName">the name of registry</param>
        /// <param name="optionsData">set the data of registry</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SetOptions(string optionsName, string optionsData, ref string msg)
        {
            bool returnBool = true;
            RegistryKey classesRoot = Registry.CurrentUser;
            RegistryKey registryKey = classesRoot.OpenSubKey(@"Control Panel\Desktop", true);
            try
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(optionsName.ToUpper(), optionsData);
                }
                else
                {
                    returnBool = false;
                }
            }
            catch
            {
                returnBool = false;
                msg = "Error when read the registry";
            }
            finally
            {
                classesRoot.Close();
                registryKey.Close();
            }
            return returnBool;
        }

        public static void imageWrite()
        {
            System.Drawing.SolidBrush fontBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("https://icanhazdadjoke.com/");
            if (!!GetFirstParagraph(webData).Contains("€") || !!GetFirstParagraph(webData).Contains("™") || !!GetFirstParagraph(webData).Contains("â"))
            {
                Console.WriteLine("Bad text found! Rerouting for new joke... Text was: " + GetFirstParagraph(webData));
                imageWrite();
            }
            else
            {
                Bitmap bitMapImage = new System.Drawing.Bitmap(@"C:\Users\TorinPC\Pictures\Camera Roll\Random\WallpaperMoving\wp8.jpg");
                Graphics graphicImage = Graphics.FromImage(bitMapImage);
                graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
                graphicImage.DrawString(GetFirstParagraph(webData), new Font("Sego UI", 10, FontStyle.Bold), fontBrush, new Point(2, 1060));
                //graphicImage.DrawArc(new Pen(Color.Red, 3), 90, 235, 150, 50, 0, 360);
                //Save the new image to the response output stream.
                bitMapImage.Save(@"C:\Users\TorinPC\Pictures\Camera Roll\Random\WallpaperMoving\currentWallpaper.jpg", ImageFormat.Jpeg);
                SetBackgroud(@"C:\Users\TorinPC\Pictures\Camera Roll\Random\WallpaperMoving\currentWallpaper.jpg");

                bitMapImage.Dispose();
                graphicImage.Dispose();
                wc.Dispose();
                fontBrush.Dispose();
            }
        }

        static string GetFirstParagraph(string file)
        {
            Match m = Regex.Match(file, @"<p\s*(.+?)\s*</p>");
            if (m.Success)
            {
                return (m.Groups[1].Value).Replace("class=\"subtitle\">", "").Replace("<br>", "").Replace("</br>", "");
            }
            else
            {
                return "";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon1.Text = "Desktop Jokes v1.1";
            notifyIcon1.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
        }

        private void changeJokeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetBackgroud();
            imageWrite();
        }

        private void changeJokeNow_Tick(object sender, EventArgs e)
        {
            GetBackgroud();
            imageWrite();
        }

        private void intervalTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                changeJokeNow.Interval = int.Parse(intervalTime.Text);
            }
            catch
            {
                
            }
        }
    }
}
