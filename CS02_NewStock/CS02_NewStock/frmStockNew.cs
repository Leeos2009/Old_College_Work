using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS02_NewStock
{
    public partial class frmStockNew : Form
    {
        public frmStockNew()
        {
            InitializeComponent();
        }

        private void frmStockReg_Load(object sender, EventArgs e)
        {
            txtStockNo.Text = Stock.nextStockNo().ToString("00000");
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            //validate data


            //instantiate Stock Object
            Stock myStock = new Stock();
            myStock.setStockNo(Convert.ToInt32(txtStockNo.Text));
            myStock.setDescription(txtDescription.Text);
            myStock.setCostPrice(Convert.ToDecimal(txtCostPrice.Text));
            myStock.setSalePrice(Convert.ToDecimal(txtSalePrice.Text));
            myStock.setQty(Convert.ToInt32(txtQty.Text));
            myStock.setStatus('R');

            //INSERT Stock record into stock table
            myStock.regStock();

            //Display Confirmation Message
            MessageBox.Show("Stock " + txtStockNo.Text + " Registered", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //reset UI
            txtDescription.Text = "";
            txtCostPrice.Text = "";
            txtSalePrice.Text = "";
            txtQty.Text = "";

            txtStockNo.Text = Stock.nextStockNo().ToString("00000");
            txtDescription.Focus();
        }
    }
}
