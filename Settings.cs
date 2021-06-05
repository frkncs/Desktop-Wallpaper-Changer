using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DesktopWallpaperChanger
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        DatabaseOperations db_op;
        DatabaseGetters db_getters;
        DatabaseSetters db_setters;

        int selectedDelayType = -1;

        private void Settings_Load(object sender, EventArgs e)
        {
            InitializeVariables();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double trackbarValue = (sender as TrackBar).Value;
            lblSettingsFormOpacity.Text = trackbarValue.ToString() + "%";
        }

        private void radioButtonsSelect(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Name.ToLower().EndsWith("minute") && (sender as RadioButton).Checked == true)
            {
                selectedDelayType = 0;
                nudDelay.Maximum = 59;
            }
            if ((sender as RadioButton).Name.ToLower().EndsWith("hour") && (sender as RadioButton).Checked == true)
            {
                selectedDelayType = 1;
                nudDelay.Maximum = 23;
            }
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            bool error = false;

            // Check Delay Type
            if (selectedDelayType == -1)
            {
                MessageBox.Show("You must select 1 delay type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = true;
            }

            if (!error)
            {
                // Apply Delay
                db_setters.SetDelay((int)nudDelay.Value);

                // Apply Delay Type
                db_setters.SetDelayType(selectedDelayType);

                // Apply Opacity
                Opacity = (double)trackBar1.Value / 100;
                db_setters.SetOpacity((double)trackBar1.Value / 100);

                Form1 f1 = new Form1();
                f1.UpdateTimerInterval();

                MessageBox.Show("Settings Saved Succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void InitializeVariables()
        {
            db_op = new DatabaseOperations();
            db_getters = new DatabaseGetters();
            db_setters = new DatabaseSetters();

            double opac = (double)db_getters.GetValueFromDB(0);
            lblSettingsFormOpacity.Text = ((int)(opac * 100)).ToString() + "%";
            trackBar1.Value = (int)(opac * 100);
            Opacity = opac;
        }
    }
}
