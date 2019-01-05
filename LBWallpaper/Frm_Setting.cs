using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
