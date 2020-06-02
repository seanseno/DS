using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.KIOSK
{
    public class CustomDataGridView : DataGridView
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int col = this.CurrentCell.ColumnIndex;
                int row = this.CurrentCell.RowIndex;
                this.CurrentCell = this[col, row];
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }
    }
}
