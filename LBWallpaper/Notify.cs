using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBWallpaper
{
    public class Notify
    {
        private NotifyIcon _NotifyIcon;
        private ContextMenuStrip _ContextMenuStrip;
        private bool _DoChangeWallpaper = false;

        public void Creat()
        {
            if (_ContextMenuStrip == null)
            {
                _ContextMenuStrip = new ContextMenuStrip();

                ToolStripMenuItem specail = new ToolStripMenuItem("特定壁纸");
                specail.Checked = App.Config.IsSpecailWallpaper;
                specail.CheckOnClick = true;
                specail.CheckedChanged += Specail_CheckedChanged;
                _ContextMenuStrip.Items.Add(specail);

                var setting = _ContextMenuStrip.Items.Add("设置");
                setting.Click += Setting_Click;

                var nextWallpaper = _ContextMenuStrip.Items.Add("切换壁纸");
                nextWallpaper.Click += NextWallpaper_Click;

                var exit = _ContextMenuStrip.Items.Add("退出");
                exit.Click += Exit_Click;
            }
            if (_NotifyIcon == null)
            {
                _NotifyIcon = new NotifyIcon();
                _NotifyIcon.Icon = Properties.Resources.favicon;
                _NotifyIcon.ContextMenuStrip = _ContextMenuStrip;
                _NotifyIcon.Visible = true;
            }
        }

        private void Specail_CheckedChanged(object sender, EventArgs e)
        {
            App.Config.IsSpecailWallpaper = ((ToolStripMenuItem)sender).Checked;
            App.Config.WriteConfig();
            if (!_DoChangeWallpaper)
            {
                Task.Factory.StartNew(() =>
                {
                    _DoChangeWallpaper = true;
                    App.StopTimer();
                    App.GetNewWallpaper();
                    App.StartTimer();
                    _DoChangeWallpaper = false;
                });
            }

        }

        private void NextWallpaper_Click(object sender, EventArgs e)
        {
            if (!_DoChangeWallpaper)
            {
                Task.Factory.StartNew(() =>
                {
                    _DoChangeWallpaper = true;
                    App.StopTimer();
                    App.GetNewWallpaper();
                    App.StartTimer();
                    _DoChangeWallpaper = false;
                });
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms["Frm_Setting"];
            if (frm == null)
            {
                frm = new Frm_Setting();
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }
    }
}
