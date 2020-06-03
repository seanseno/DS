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
    public partial class FrmEditReceivedItem : Form
    {
        private Items _Item { get;set;}
        public FrmEditReceivedItem(Items Item)
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
            _Item.Price = Convert.ToDecimal(txtPrice.Text);
            _Item.BarCode = txtBarcode.Text;

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

        private void FrmEditReceivedItem_Load(object sender, EventArgs e)
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

            ItemsModel items = new ItemsModel();
            var response = items.LoadEdit(_Item.Id);
            cboCategories.SelectedIndex = cboCategories.FindStringExact(response.CategoryName);
            cboCompanies.SelectedIndex = cboCompanies.FindStringExact(response.CompanyName);
            txtGenericname.Text = response.GenericName;
            txtBrandName.Text = response.BrandName;
            txtDescription.Text = response.Description;
            txtPrice.Text = response.Price.ToString();
            lblStock.Text = response.StockString;
            txtBarcode.Text = response.BarCode;
            this.ActiveControl = cboCompanies;
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
    }
}
