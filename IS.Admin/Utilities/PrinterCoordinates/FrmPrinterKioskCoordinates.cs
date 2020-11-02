using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmPrinterKioskCoordinates : BaseForm
    {
        ISFactory factory = new ISFactory();
        public FrmPrinterKioskCoordinates()
        {
            InitializeComponent();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmCashiers_Load(object sender, EventArgs e)
        {
            //var vvv = factory.PrinterCoordinatesRepository.GetList().ToList();
            var Coor = factory.PrinterCoordinatesRepository.GetList().Where(x=>x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel =="Date").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtDateX.Text = Coor.X.ToString("N0");
            txtDateY.Text = Coor.Y.ToString("N0");
            txtDateS.Text = Coor.Size.ToString("N0");

            Coor = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ReceiptNo").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtReceiptNoX.Text = Coor.X.ToString("N0");
            txtReceiptNoY.Text = Coor.Y.ToString("N0");
            txtReceiptNoS.Text = Coor.Size.ToString("N0");

            Coor = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "SoldTo").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtSoldToX.Text = Coor.X.ToString("N0");
            txtSoldToY.Text = Coor.Y.ToString("N0");
            txtSoldToS.Text = Coor.Size.ToString("N0");


            Coor = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Products").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtProductsX.Text = Coor.X.ToString("N0");
            txtProductsY.Text = Coor.Y.ToString("N0");
            txtProductsS.Text = Coor.Size.ToString("N0");


            Coor = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ProductsQty").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtProductsQtyX.Text = Coor.X.ToString("N0");
            txtProductsQtyS.Text = Coor.Size.ToString("N0");

            Coor = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "ProductsPrice").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtProductsPriceX.Text = Coor.X.ToString("N0");
            txtProductsPriceS.Text = Coor.Size.ToString("N0");

            Coor = factory.PrinterCoordinatesRepository.GetList().Where(x => x.PrintingType == (int)PrinterType.Kiosk && x.PrintingLabel == "Total").FirstOrDefault();
            if (Coor == null)
            {
                return;
            }
            txtTotalX.Text = Coor.X.ToString("N0");
            txtTotalY.Text = Coor.Y.ToString("N0");
            txtTotalS.Text = Coor.Size.ToString("N0");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                if (MessageBox.Show("Are you sure do want to update printer coordinates?", "Information!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    factory.PrinterCoordinatesRepository.Delete(PrinterType.Kiosk);

                    var coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "Date";
                    coor.X = Convert.ToInt32(txtDateX.Text);
                    coor.Y = Convert.ToInt32(txtDateY.Text);
                    coor.Size = Convert.ToInt32(txtDateS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);
                   
                    coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "ReceiptNo";
                    coor.X = Convert.ToInt32(txtReceiptNoX.Text);
                    coor.Y = Convert.ToInt32(txtReceiptNoY.Text);
                    coor.Size = Convert.ToInt32(txtReceiptNoS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);

                    coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "SoldTo";
                    coor.X = Convert.ToInt32(txtSoldToX.Text);
                    coor.Y = Convert.ToInt32(txtSoldToY.Text);
                    coor.Size = Convert.ToInt32(txtSoldToS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);

                    coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "Products";
                    coor.X = Convert.ToInt32(txtProductsX.Text);
                    coor.Y = Convert.ToInt32(txtProductsY.Text);
                    coor.Size = Convert.ToInt32(txtProductsS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);

                    coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "ProductsQty";
                    coor.X = Convert.ToInt32(txtProductsQtyX.Text);
                    coor.Size = Convert.ToInt32(txtProductsQtyS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);

                    coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "ProductsPrice";
                    coor.X = Convert.ToInt32(txtProductsPriceX.Text);
                    coor.Size = Convert.ToInt32(txtProductsPriceS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);

                    coor = new PrinterCoordinates();
                    coor.PrintingType = (int)PrinterType.Kiosk;
                    coor.PrintingLabel = "Total";
                    coor.X = Convert.ToInt32(txtTotalX.Text);
                    coor.Y = Convert.ToInt32(txtTotalY.Text);;
                    coor.Size = Convert.ToInt32(txtTotalS.Text);
                    factory.PrinterCoordinatesRepository.Insert(coor);
                    MessageBox.Show("coordinates updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtTotalX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtDateX.Text) 
                    || string.IsNullOrEmpty(txtDateY.Text)
                    || string.IsNullOrEmpty(txtDateS.Text))
            {
                MessageBox.Show("Empty is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDateX.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtReceiptNoX.Text)
                || string.IsNullOrEmpty(txtReceiptNoY.Text)
                || string.IsNullOrEmpty(txtReceiptNoS.Text))
                    {
                        MessageBox.Show("Empty is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtReceiptNoX.Focus();
                        return true;
            }

            if (string.IsNullOrEmpty(txtSoldToX.Text)
                || string.IsNullOrEmpty(txtSoldToY.Text)
                || string.IsNullOrEmpty(txtSoldToS.Text))
                        {
                            MessageBox.Show("Empty is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSoldToX.Focus();
                            return true;
            }

            if (string.IsNullOrEmpty(txtProductsX.Text)
                || string.IsNullOrEmpty(txtProductsY.Text)
                || string.IsNullOrEmpty(txtProductsS.Text))
            {
                MessageBox.Show("Empty is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductsX.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtTotalX.Text)
                || string.IsNullOrEmpty(txtTotalY.Text)
                || string.IsNullOrEmpty(txtTotalS.Text))
            {
                MessageBox.Show("Empty is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalX.Focus();
                return true;
            }
            return false;
        }
    }
}
