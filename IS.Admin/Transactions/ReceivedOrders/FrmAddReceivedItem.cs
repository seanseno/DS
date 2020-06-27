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
using ZXing.QrCode.Internal;

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
            LoadItems();

            RequestOrderItemsModel RModel = new RequestOrderItemsModel();
            cboOrders.DataSource = null;

            var response1 = RModel.ItemList();
            var comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-Select-");
            foreach (var item in response1)
            {
                comboSource.Add(item.Id, item.RequestOrderName);
            }

            cboOrders.DataSource = new BindingSource(comboSource, null);
            cboOrders.DisplayMember = "Value";
            cboOrders.ValueMember = "Key";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(cboOrders.Items.Count > 0 )
            {
                if(cboOrders.SelectedIndex > 0)
                {
                     int ItemId = (int)dgvSearch.CurrentRow.Cells[0].Value;
                    int OrderId = ((KeyValuePair<int, string>)cboOrders.SelectedItem).Key;

                    FrmAddInputReceivedItem frm = new FrmAddInputReceivedItem(this);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ReceivedOrdersModel model = new ReceivedOrdersModel();
                        ItemReceivedOrders itemReceivedOrders = new ItemReceivedOrders();
                        itemReceivedOrders.RequestOrderId = OrderId;
                        itemReceivedOrders.ItemId = ItemId;
                        itemReceivedOrders.DateReceived = InputDateReceived;
                        itemReceivedOrders.DateManufactured = InputDateManufactured;
                        itemReceivedOrders.ExpirationDate = InputExpirationDate;
                        itemReceivedOrders.SupplierPrice = InputOrderPrice;
                        itemReceivedOrders.SellingPricePerPiece = InputSellingPrice;
                        itemReceivedOrders.Quantity = InputQuantity; 
                        model.Insert(itemReceivedOrders);
                        MessageBox.Show("Order Received Added!", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadItems();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Please select orders first!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboOrders.Focus();
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            ReceivedOrdersModel model = new ReceivedOrdersModel();
            var response = model.ItemList(txtSearch.Text);

            dgvSearch.DataSource = null;
            dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.DataSource = response;
        }
    }
}
