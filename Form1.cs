using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWallpaperChanger
{
    public partial class Form1 : Form
    {
        // Private Variables
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);
        private uint SPI_SETDESKWALLPAPER = 0x14;

        DatabaseOperations db_op;
        DatabaseGetters db_getters;
        DatabaseSetters db_setters;

        int currentImageIx = 0;

        string selectedImageLocation = "";

        bool closeApplication = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db_op = new DatabaseOperations();
            db_getters = new DatabaseGetters();
            db_setters = new DatabaseSetters();

            db_op.CreateDatabase();
            SetRegistryKeyForStartWithWindows();
            FillAllPictureBoxes();

            UpdateButtonsState();
            UpdateTimerInterval();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            SelectImage();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            PutImageToPictureBox();
            UpdateButtonsState();
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            if (Application.OpenForms[settings.Name] == null)
                settings.Show();
        }

        private void btnDeleteLastImage_Click(object sender, EventArgs e)
        {
            DeleteLastImageInPictureBox();
            UpdateButtonsState();
        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            timer1.Start();

            UpdateButtonsState();
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            UpdateButtonsState();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeApplication)
            {
                e.Cancel = true;
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void toolStripMenuItemCloseApp_Click(object sender, EventArgs e)
        {
            closeApplication = true;
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DatabaseGetters db_get = new DatabaseGetters();

            List<string> imageLocations = db_get.GetImageLocationsFromDB();

            if (imageLocations.Count > 0)
            {
                ChangeDesktopBackgroundImage(imageLocations[currentImageIx]);

                if (currentImageIx < imageLocations.Count - 1)
                    currentImageIx++;
                else
                    currentImageIx = 0;
            }
        }

        void FillAllPictureBoxes()
        {
            List<string> imageLocations = db_getters.GetImageLocationsFromDB();

            foreach (string imageLocation in imageLocations)
            {
                if (imageLocation != "null")
                    PutImageToPictureBox(imageLocation);
            }
        }

        void PutImageToPictureBox()
        {
            if (selectedImageLocation != "")
            {
                PictureBox pcbox = GetNullPictureBox();

                if (pcbox != null)
                {
                    pcbox.BackColor = Color.Transparent;
                    pcbox.BackgroundImage = new Bitmap(selectedImageLocation);

                    db_setters.AddImageToDB(selectedImageLocation);
                }
            }
        }

        void PutImageToPictureBox(string imageLocation = "")
        {
            if (imageLocation != "")
            {
                PictureBox pcbox = GetNullPictureBox();

                if (pcbox != null)
                {
                    pcbox.BackColor = Color.Transparent;
                    pcbox.BackgroundImage = new Bitmap(imageLocation);
                }
            }
        }

        void DeleteLastImageInPictureBox()
        {
            PictureBox pbox = GetLastNotNullPictureBox();

            if (pbox != null)
            {
                pbox.BackColor = Color.Silver;
                pbox.BackgroundImage = null;

                db_setters.DeleteLastImageFromDB();
            }
        }

        void ChangeDesktopBackgroundImage(string file_name)
        {
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
            {
                MessageBox.Show("An unknown error has occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SelectImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.png; *.jpg; *.jpeg)|*.png; *.jpg; *.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImageLocation = ofd.FileName;

                txtImageLocation.Text = selectedImageLocation;
                if (!btnAddImage.Enabled)
                    btnAddImage.Enabled = true;
            }
        }

        public void UpdateTimerInterval()
        {
            DatabaseGetters db_get = new DatabaseGetters();

            double selectedDelayType = (double)db_get.GetValueFromDB(1);

            if (selectedDelayType == 0)
            {
                timer1.Interval = (int)((double)db_get.GetValueFromDB(2) * 60 * 1000);
            }
            else if (selectedDelayType == 1)
            {
                timer1.Interval = (int)((double)db_get.GetValueFromDB(2) * 3600 * 1000);
            }
        }

        void UpdateButtonsState()
        {
            if (db_getters.GetImageLocationsFromDB()[0] == "null")
            {
                btnStartTimer.Enabled = false;
                btnStopTimer.Enabled = false;
            }
            else
            {
                if (timer1.Enabled)
                {
                    btnStartTimer.Enabled = false;
                    btnStopTimer.Enabled = true;
                }
                else
                {
                    btnStartTimer.Enabled = true;
                    btnStopTimer.Enabled = false;
                }
            }
        }

        PictureBox GetNullPictureBox()
        {
            List<Control> pictureBoxes = new List<Control>();
            findControlsOfType(typeof(PictureBox), Controls, ref pictureBoxes);

            List<Control> sortedPictureBoxes = new List<Control>();
            SortControlsByLasNumberInName(pictureBoxes, ref sortedPictureBoxes, "pictureBox");

            foreach (PictureBox pictureBox in sortedPictureBoxes)
            {
                if (pictureBox.BackgroundImage == null)
                    return pictureBox;
            }

            return null;
        }

        PictureBox GetLastNotNullPictureBox()
        {
            List<Control> pictureBoxes = new List<Control>();
            findControlsOfType(typeof(PictureBox), Controls, ref pictureBoxes);

            List<Control> sortedPictureBoxes = new List<Control>();
            SortControlsByLasNumberInName(pictureBoxes, ref sortedPictureBoxes, "pictureBox");

            for (int i = sortedPictureBoxes.Count - 1; i >= 0; i--)
            {
                if (sortedPictureBoxes[i].BackgroundImage != null)
                    return sortedPictureBoxes[i] as PictureBox;
            }

            return null;
        }

        void findControlsOfType(Type type, Control.ControlCollection formControls, ref List<Control> controls)
        {
            foreach (Control control in formControls)
            {
                if (control.GetType() == type)
                    controls.Add(control);
                
                if (control.Controls.Count > 0)
                    findControlsOfType(type, control.Controls, ref controls);
            }
        }

        void SetRegistryKeyForStartWithWindows()
        {
            string appName = "Desktop Wallpaper Changer";

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (key.GetValue(appName) == null)
                key.SetValue(appName, Application.ExecutablePath);
        }

        void SortControlsByLasNumberInName(List<Control> controlList, ref List<Control> listOfSortedControls, string keyword)
        {
            // keyword: The word before the number for the objects we will call

            List<Control> tempList = controlList;

            int minNumber = int.MaxValue;

            foreach (Control item in tempList.ToList())
            {
                int numberAfterWord = int.Parse(item.Name.Substring(keyword.Length));

                if (numberAfterWord < minNumber)
                    minNumber = numberAfterWord;
            }

            foreach (Control item in controlList.ToList())
            {
                if (item.Name == keyword + minNumber)
                    listOfSortedControls.Add(item);
            }

            foreach (Control item in tempList.ToList())
            {
                if (item.Name == keyword + minNumber && tempList.Count > 0)
                    tempList.Remove(item);
            }

            if (tempList.Count > 0)
                SortControlsByLasNumberInName(controlList, ref listOfSortedControls, keyword);
        }
    }
}
