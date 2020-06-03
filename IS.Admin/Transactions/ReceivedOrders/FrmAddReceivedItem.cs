using IS.Admin.Model;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace IS.Admin.Trasactions
{
    public partial class FrmAddReceivedItem : Form
    {
        public int InputQuantity { get;set; }
        public DateTime InputDateReceived { get; set; }
        public DateTime InputDateManufactured { get; set; }
        public DateTime InputExpirationDate { get; set; }
        public decimal InputOrderPrice { get; set; }
        public decimal InputSellingPrice { get; set; }
        public FrmAddReceivedItem()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmAddReceivedItem_Load(object sender, EventArgs e)
        {
            ReceivedOrdersModel model = new ReceivedOrdersModel();
            var response = model.ItemList(txtSearch.Text);

        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            FrmAddInputReceivedItem frm = new FrmAddInputReceivedItem(this);
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
