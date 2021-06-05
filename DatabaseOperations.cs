using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace DesktopWallpaperChanger
{
    class DatabaseOperations
    {
        SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\DesktopWallpaperChanger\Database.sqlite;Version=3;");
        SQLiteCommand cmd;

        public void CreateDatabase()
        {
            try
            {
                if (!Directory.Exists(@"C:\DesktopWallpaperChanger"))
                    Directory.CreateDirectory(@"C:\DesktopWallpaperChanger");

                if (!File.Exists(@"C:\DesktopWallpaperChanger\Database.sqlite"))
                {
                    SQLiteConnection.CreateFile(@"C:\DesktopWallpaperChanger\Database.sqlite");

                    string sql = @"CREATE TABLE IF NOT EXISTS Settings(
                            opacity TEXT NOT NULL,
                            delay_type INTEGER NOT NULL,
                            delay INTEGER NOT NULL,
                            image_locations TEXT)";

                    con.Open();

                    cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    cmd = new SQLiteCommand(@"INSERT INTO Settings(opacity, delay_type, delay, image_locations)
                                            VALUES(1, 0, 0, 'null')");
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
    }
}
