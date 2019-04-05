using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBWallpaper
{
    public partial class Frm_Setting : Form
    {
        public Frm_Setting()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(App.Config.SpecailWallpaper) && File.Exists(App.Config.SpecailWallpaper))
                button_SpecailWallpaper.Text = "已选择";
        }

        private void Frm_Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            App.Config.ChangeInterval = (int)numericUpDown_ChangeInterval.Value * 1000;
            App.Config.CacheSize = (int)numericUpDown_CacheSize.Value;
            App.Config.WriteConfig();
            App.RefreshInterval();
        }

        private void Frm_Setting_Load(object sender, EventArgs e)
        {
            numericUpDown_ChangeInterval.Value = App.Config.ChangeInterval / 1000;
            numericUpDown_CacheSize.Value = App.Config.CacheSize;
        }

        private void button_SpecailWallpaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                App.Config.SpecailWallpaper = ofd.FileName;
                button_SpecailWallpaper.Text = "已选择";
            }
        }
    }
}
