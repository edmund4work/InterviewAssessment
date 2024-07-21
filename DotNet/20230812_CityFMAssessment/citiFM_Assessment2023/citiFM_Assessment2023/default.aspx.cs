using citiFM_Assessment2023.Controller;
using citiFM_Assessment2023.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace citiFM_Assessment2023
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    getFxRateList();
                    getProductList(0);
                    txtQty.Attributes.Add("onkeydown", "return isInteger(event)");
                    displayAlertMsg("PLease Select Product to purchase (by clicking [Add This Item] from list and key in the quantity. Thanks.");
                }
                catch (Exception ex)
                {
                    displayAlertMsg(ex.Message);
                }
            }
        }

        #region Api Calling
        private void getFxRateList()
        {
            string urlCall = "fx-rates";
            List<FxRate> returnData = new List<FxRate>();
            try
            {
                returnData = JsonConvert.DeserializeObject<List<FxRate>>(apiCommonCode.callAPIGet(urlCall));
            }
            catch (Exception ex)
            {
                displayAlertMsg(ex.Message);
            }
            this.gvFxRates.DataSource = returnData;
            this.gvFxRates.DataBind();
        }
        private void getProductList(int pageIndex)
        {
            string urlCall = "Products";
            List<Product> returnData = new List<Product>();
            try
            {
                returnData = JsonConvert.DeserializeObject<List<Product>>(apiCommonCode.callAPIGet(urlCall));
            }
            catch (Exception ex)
            {
                displayAlertMsg(ex.Message);
            }
            ///normally will not retrieve all data but will use skip and take la.
            this.gvProducts.DataSource = returnData;
            if (returnData.Count > 0)
                this.gvProducts.PageIndex = pageIndex;
            this.gvProducts.DataBind();
        }
        private string postOrder()
        {
            string urlCall = "Orders";
            string returnData = "";
            try
            {
                Order data = new Order();
                //Master data
                data.customerEmail = this.txtCustomerEmail.Text;
                data.customerName = this.txtCustomerName.Text;

                //begin: lineItemData (should be allow to make it multiple, but may leave it to next time.
                int qty = 0;
                int.TryParse(this.txtQty.Text, out qty);
                OrderLineItem item = new OrderLineItem
                {
                    productId = this.hfProductID.Value,
                    quantity = qty,
                };

                data.lineItems = new List<OrderLineItem>();
                data.lineItems.Add(item);
                //end: lineItemData

                returnData = apiCommonCode.callAPIPost(urlCall, data);
            }
            catch (Exception ex)
            {
                displayAlertMsg(ex.Message);
            }

            return returnData;
        }
        #endregion

        #region common function
        private decimal markupPrice(decimal unitPrice)
        {
            return (unitPrice * (decimal)1.20);
        }
        private void displayAlertMsg(string message)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('An Error Occured. Kindly check with support. We are sincerely apologize. ')", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + message + "')", true); //internal use.
        }
        private bool ValidateField()
        {
            bool allPass = true;
            string failReason = "";
            string newLine = "<br />"; // Environment.NewLine

            if (String.IsNullOrEmpty(this.hfProductID.Value))
                failReason += "*Please select a product before submit order." + newLine;
            if (string.IsNullOrEmpty(this.txtQty.Text))
                failReason += "*Please put in the quantity." + newLine;
            else
            {
                int qtyMax = 0;
                int qtyKeyin = 0;
                int.TryParse(hfMaxQty.Value, out qtyMax);
                int.TryParse(this.txtQty.Text, out qtyKeyin);
                if (qtyMax > 0)
                    if (qtyKeyin > qtyMax)
                        failReason += "*Please key in the quantity less or equal " + qtyMax.ToString() + "." + newLine;

            }
            if (String.IsNullOrEmpty(this.txtCustomerName.Text))
                failReason += "*Please key in your name." + newLine;
            if (String.IsNullOrEmpty(this.txtCustomerEmail.Text))
                failReason += "*Please key in your email." + newLine;
            else
            {
                var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

                var regex = new Regex(pattern);
                if (!regex.IsMatch(this.txtCustomerEmail.Text))
                    failReason += "*Please key in a valid email." + newLine;
            }

            if (!string.IsNullOrEmpty(failReason))
                allPass = false;
            this.lblFailMsg.Text = failReason;


            return allPass;
        }
        private decimal getTotalPrice()
        {
            decimal returnValue = 0;
            decimal salesPrice = decimal.Parse(lblSelected_SalePrice.Text);
            int qtyKeyIN = 0;
            int.TryParse(txtQty.Text, out qtyKeyIN);
            returnValue = (salesPrice * qtyKeyIN);
            return returnValue;
        }
        #endregion

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddSelectedItem")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    DataKey row = gvProducts.DataKeys[rowIndex];

                    // Get product details from the selected row
                    string productID = row.Values[0].ToString();
                    string productName = row.Values[1].ToString();
                    string unitPrice = row.Values[2].ToString();
                    decimal unitPriceDecimal = 0;
                    Decimal.TryParse(unitPrice, out unitPriceDecimal);
                    string maxQty = (row.Values[3] ?? 0).ToString();

                    lblSelected_ProductName.Text = productName;
                    lblSelected_ProductID.Text = this.hfProductID.Value = productID;
                    lblSelected_TotalPrice.Text = "0";
                    lblSelected_SalePrice.Text = markupPrice(unitPriceDecimal).ToString("0.00");
                    hfUnitPrice.Value = lblSelected_SalePrice.Text;
                    hfMaxQty.Value = maxQty;
                    this.lblSelected_TotalPrice.Text = getTotalPrice().ToString("0.00");
                }
                catch (Exception ex)
                {
                    displayAlertMsg(ex.Message);
                }
            }
        }

        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                    btnAdd.CommandArgument = e.Row.RowIndex.ToString();

                    int rowIndex = e.Row.RowIndex;
                    DataKey row = gvProducts.DataKeys[rowIndex];
                    decimal unitPrice = 0;
                    decimal.TryParse(row.Values[2].ToString(), out unitPrice);
                    Label lblMarkUp = (Label)e.Row.FindControl("lblMarkUp");
                    lblMarkUp.Text = markupPrice(unitPrice).ToString("0.00");
                    this.lblSelected_TotalPrice.Text = getTotalPrice().ToString("0.00");

                }
                catch (Exception ex)
                {
                    displayAlertMsg(ex.Message);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1: Validate Field
                if (ValidateField())
                {
                    //Step 2: Call API to submit
                    string resultReturn = postOrder();
                    //Step 3: return result
                    this.lblFailMsg.Text = resultReturn.Replace(";", "<br/>");

                    if (resultReturn == "Order submitted")
                    {
                        //this.lblFailMsg.ForeColor = System.Drawing.Color.LightGreen;
                        displayAlertMsg("Thanks for submit this order.");
                    }

                }
            }
            catch (Exception ex)
            {
                displayAlertMsg(ex.Message);
            }
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int qty = 0;
                int.TryParse(txtQty.Text, out qty);
                if (qty < 0)
                {
                    displayAlertMsg("Quantity must more than 0");
                    txtQty.Text = "0";
                    txtQty.Focus();
                }
                else
                    this.lblSelected_TotalPrice.Text = getTotalPrice().ToString("0.00");
            }
            catch (Exception ex)
            {
                displayAlertMsg(ex.Message);
            }
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            getProductList(e.NewPageIndex);
        }

    }
}