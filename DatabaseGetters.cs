using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWallpaperChanger
{
    class DatabaseGetters
    {
        SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\DesktopWallpaperChanger\Database.sqlite;Version=3;");
        SQLiteCommand cmd;

        /// <summary>
        /// 0: Opacity
        /// 1: Delay Type
        /// 2: Delay
        /// 3: Image Locations
        /// </summary>

        public object GetValueFromDB(int valueIndex)
        {
            con.Open();
            string sql = "SELECT * FROM Settings";
            cmd = new SQLiteCommand(sql, con);
            cmd.Connection = con;

            try
            {
                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();

                object[] objs = new object[4];
                int quant = reader.GetValues(objs);

                reader.Close();

                if (valueIndex == 0 || valueIndex == 1 || valueIndex == 2)
                    return double.Parse(objs[valueIndex].ToString());
                else
                    return objs[valueIndex].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public List<string> GetImageLocationsFromDB()
        {
            string imageLocations = (string)GetValueFromDB(3);

            List<string> imageLocationsList = new List<string>();

            while (true)
            {
                if (imageLocations.IndexOf(";") != -1)
                {
                    string imLoc = imageLocations.Substring(0, imageLocations.IndexOf(";"));
                    imageLocationsList.Add(imLoc);

                    imageLocations = imageLocations.Substring(imageLocations.IndexOf(";") + 1);
                    continue;
                }
                else
                {
                    if (imageLocations.Length > 0)
                    {
                        imageLocationsList.Add(imageLocations);
                        break;
                    }
                    else
                        break;
                }
            }

            return imageLocationsList;
        }
    }
}
