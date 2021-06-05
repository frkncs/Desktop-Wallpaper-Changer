using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWallpaperChanger
{
    class DatabaseSetters
    {
        SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\DesktopWallpaperChanger\Database.sqlite;Version=3;");
        SQLiteCommand cmd;

        public void AddImageToDB(string imageLoc)
        {
            try
            {
                string imageLocationsString = null;

                DatabaseGetters db_getters = new DatabaseGetters();
                List<string> imageLocations = db_getters.GetImageLocationsFromDB();

                con.Open();

                foreach (string imageLocation in imageLocations)
                {
                    if (imageLocation == "null")
                    {
                        string sql = "UPDATE Settings SET image_locations = '" + imageLoc + "'";
                        cmd = new SQLiteCommand(sql, con);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        break;
                    }
                    else
                    {
                        imageLocationsString += imageLocation + ";";
                    }
                }

                if (imageLocationsString != null)
                {
                    imageLocationsString += imageLoc;

                    string sql = "UPDATE Settings SET image_locations = '" + imageLocationsString + "'";
                    cmd = new SQLiteCommand(sql, con);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteLastImageFromDB()
        {
            try
            {
                string imageLocationsString = null;

                DatabaseGetters db_getters = new DatabaseGetters();
                List<string> imageLocations = db_getters.GetImageLocationsFromDB();
                
                con.Open();

                for (int i = 0; i < imageLocations.Count; i++)
                {
                    if (imageLocations[0] != "null")
                    {
                        if (imageLocations.Count > 1)
                        {
                            if (i < imageLocations.Count - 1)
                            {
                                imageLocationsString += imageLocations[i] + ";";
                            }
                        }
                        else
                            imageLocationsString = "null";
                    }
                }

                if (imageLocationsString != null)
                {
                    if (imageLocationsString != "null")
                        imageLocationsString = imageLocationsString.Substring(0, imageLocationsString.Length - 1);

                    string sql = "UPDATE Settings SET image_locations = '" + imageLocationsString + "'";
                    cmd = new SQLiteCommand(sql, con);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void SetOpacity(double opacity)
        {
            try
            {
                con.Open();
                string sql = "UPDATE Settings SET opacity = '" + opacity + "'";
                cmd = new SQLiteCommand(sql, con);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void SetDelayType(int delayType)
        {
            try
            {
                con.Open();
                string sql = "UPDATE Settings SET delay_type = '" + delayType + "'";
                cmd = new SQLiteCommand(sql, con);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void SetDelay(int delay)
        {
            try
            {
                con.Open();
                string sql = "UPDATE Settings SET delay = '" + delay + "'";
                cmd = new SQLiteCommand(sql, con);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
