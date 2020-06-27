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

namespace IS.Admin.Setup
{
    public partial class FrmEditItem : Form
    {
        private Items _Item { get;set;}
        public FrmEditItem(Items Item)
        {
            InitializeComponent();
            this._Item = Item;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemsModel model = new ItemsModel();

            var CompId = Convert.ToInt32(cboCompanies.SelectedValue?.ToString());
            if (CompId != 0)
            {
                _Item.CompanyId = CompId;
            }
            var CatId = Convert.ToInt32(cboCategories.SelectedValue.ToString());
            if (CatId != 0)
            {
                _Item.CategoryId = CatId;
            }

            _Item.GenericName = txtGenericname.Text;
            _Item.BrandName = txtBrandName.Text;
            _Item.Description = txtDescription.Text;
            _Item.SellingPricePerPiece = Convert.ToDecimal(txtPrice.Text);
            _Item.BarCode = txtBarcode.Text;

            if (cboItemStocks.SelectedItem != null)
            {
                _Item.ItemReceivedOrdersId = ((KeyValuePair<int, string>)cboItemStocks.SelectedItem).Key;
            }
           
;
            //_Item.BrandType = Convert.ToInt32(cboBrand.SelectedValue.ToString());
            if (model.CheckEditDup(_Item.Description, _Item.Id))
            {
                MessageBox.Show(_Item.Description + " already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrandName.Focus();
            }
            else
            {
                model.UpdateItem(_Item);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmEditItem_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cboCategories;

            CategoriesModel model1 = new CategoriesModel();
            var Categories = model1.CategoryListWithSelect();
            cboCategories.DataSource = Categories;
            cboCategories.DisplayMember = "CategoryName";
            cboCategories.ValueMember = "Id";

            CompaniesModel Cmodel = new CompaniesModel();
            var brand = Cmodel.CompanyListWithSelect();
            cboCompanies.DataSource = brand;
            cboCompanies.DisplayMember = "CompanyName";
            cboCompanies.ValueMember = "Id";

            ReceivedOrdersModel receivedOrdersModel = new ReceivedOrdersModel();
            var ItemReceivedList = receivedOrdersModel.RequestOrderListWithItemId(_Item.Id);

            var comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-Select-");

            if (ItemReceivedList != null)
            {
                foreach (var item in ItemReceivedList)
                {
                    comboSource.Add(item.Id, item.RequestOrderName + " " + item.OrderDate);
                }
            }

            cboAvailableStocks.DataSource = new BindingSource(comboSource, null);
            cboAvailableStocks.DisplayMember = "Value";
            cboAvailableStocks.ValueMember = "Key";

            //SET SELECTED INDEX
            ItemReceivedOrdersModel ReceivedOrdersDetails = new ItemReceivedOrdersModel();
            var itemReceivedOrder = ReceivedOrdersDetails.ItemReceivedOrderWithId(_Item.ItemReceivedOrdersId);


            var ReceivedOrder = receivedOrdersModel.GetOrderRequestInfoWithId(itemReceivedOrder.RequestOrderId);
            if (ReceivedOrder != null)
            {
                cboAvailableStocks.SelectedIndex = cboAvailableStocks.FindStringExact(ReceivedOrder.RequestOrderName + " " + ReceivedOrder.OrderDate);
            }

            ItemsModel items = new ItemsModel();
            var response = items.LoadEdit(_Item.Id);
            cboCategories.SelectedIndex = cboCategories.FindStringExact(response.CategoryName);
            cboCompanies.SelectedIndex = cboCompanies.FindStringExact(response.CompanyName);
            txtGenericname.Text = response.GenericName;
            txtBrandName.Text = response.BrandName;
            txtDescription.Text = response.Description;
            txtPrice.Text = response.SellingPricePerPiece.ToString();
            lblStock.Text = response.StockString;
            txtBarcode.Text = response.BarCode;

 
            //var AvailableStockString = ItemRecieved.re

            //this.ActiveControl = cboCompanies;


        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                BarcodeWriter writer = new BarcodeWriter()
                {
                    Format = BarcodeFormat.CODE_128
                };
                pictureBox1.Image = writer.Write(txtBarcode.Text);
            }
        }

        private void cboAvailableStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboSource1 = new Dictionary<int, string>();
            comboSource1.Add(0, "-Select-");
            //cboItemStocks.DataSource = comboSource1;
            if (cboAvailableStocks.SelectedItem != null)
            {
                if (cboAvailableStocks.Items.Count > 1 && cboAvailableStocks.SelectedIndex != 0)
                {
                    int Id = ((KeyValuePair<int, string>)cboAvailableStocks.SelectedItem).Key;
                    ItemReceivedOrdersModel itemReceivedOrdersModel = new ItemReceivedOrdersModel();
                    var ItemReceivedDetailList = itemReceivedOrdersModel.GetItemReceivedOrderListWithRequestOrderIdAndItemId(Id,_Item.Id);



                    if (ItemReceivedDetailList != null)
                    {
                        foreach (var item in ItemReceivedDetailList)
                        {
                            comboSource1.Add(item.Id, "Stocks: " + item.Quantity + " Desc: " + item.Description);
                           
                        }
                    }

                    cboItemStocks.DataSource = new BindingSource(comboSource1, null);
                    cboItemStocks.DisplayMember = "Value";
                    cboItemStocks.ValueMember = "Key";
                    cboItemStocks.SelectedIndex = 1;

                }
            }
        }
    }
}
