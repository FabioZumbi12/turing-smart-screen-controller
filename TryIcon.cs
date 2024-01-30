using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turing_Smart_Screen_Controller
{
    public static class TryIcon
    {
        private static Form _form;
        private static NotifyIcon notifyIcon1;

        public static void InitTry(Form form)
        {
            _form = form;
            notifyIcon1 = new NotifyIcon
            {
                Icon = form.Icon,
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipText = "Turing Smart Screen Monitor is running.\nDouble click on icon to show!",
                BalloonTipTitle = "Turing Smart Screen",
                Text = "Turing Smart Screen Controller",
                Visible = true
            };
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
        }

        private static void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (_form.IsDisposed)
            {
                _form = new App();
            }
            _form.Show();
        }

        internal static void RemoveTry()
        {
            notifyIcon1.Visible = false;
        }

        internal static void ShowBaloon()
        {
            notifyIcon1.ShowBalloonTip(5);
        }
    }
}
