using IS.Library.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public partial class BaseForm : Form
    {
        protected override void OnShown(EventArgs e)
        {
            BackColor = GetColor();
            StartPosition = FormStartPosition.CenterParent;
        }
        public Color GetColor()
        {
            try
            {
                return ThemesUtility.BackColor();
            }
            catch
            {

            }
            return Color.FromArgb(64, 128, 123);
        }
    }
}
