<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="citiFM_Assessment2023._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CitiFM Assessment 2023</title>
    <style>
        .requirdField {
            color: red;
        }
        .failMsg {
            color: red;
            font-style: italic;
        }
    </style>
    <script type="text/javascript">
        function isInteger(event) {
            var key = event.keyCode || event.which;

            // Allow backspace and number keys (0-9)
            if (key === 8 || key === 9 || (key >= 48 && key <= 57)) {
                return true;
            }

            return false;
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="gvFxRates" runat="server" EmptyDataText="No Record Yet" EnableSortingAndPagingCallbacks="True" AutoGenerateColumns="false" Caption="Fx Rate">
                <Columns>
                    <asp:BoundField HeaderText="Source Currency" DataField="sourceCurrency" />
                    <asp:BoundField HeaderText="Target Currency" DataField="targetCurrency" />
                    <asp:BoundField HeaderText="Rate" DataField="rate" />
                </Columns>
                <PagerSettings Mode="NumericFirstLast" />
            </asp:GridView>

            <asp:GridView ID="gvProducts" runat="server" EmptyDataText="No Record Yet" AutoGenerateColumns="false" Caption="Products" OnRowDataBound="gvProducts_RowDataBound" OnRowCommand="gvProducts_RowCommand" DataKeyNames="productId,name,unitPrice,maximumQuantity" OnPageIndexChanging="gvProducts_PageIndexChanging" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Add">
                        <ItemTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="Add This Item" CommandName="AddSelectedItem" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Product Name" DataField="name" />
                    <asp:BoundField HeaderText="Description" DataField="description" />
                    <asp:BoundField HeaderText="Unit Price" DataField="unitPrice" />
                    <asp:TemplateField HeaderText="Mark-Up">
                        <ItemTemplate>
                            <asp:Label ID="lblMarkUp" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Max Quantity" DataField="maximumQuantity" />
                </Columns>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
            </asp:GridView>

            <br />
            <asp:HiddenField ID="hfProductID" runat="server" />
            <asp:HiddenField ID="hfMaxQty" runat="server" />
            <asp:HiddenField ID="hfUnitPrice" runat="server" />
            <asp:Label ID="lblTitle_ProductID" runat="server" Text="Product ID: "></asp:Label><i><asp:Label ID="lblSelected_ProductID" runat="server" Text="Please select a product from list above."></asp:Label></i>
            <br />
            <asp:Label ID="lblTitle_ProductName" runat="server" Text="Product Name: "></asp:Label><i><asp:Label ID="lblSelected_ProductName" runat="server" Text="Please select a product from list above."></asp:Label></i>
            <br />
            <asp:Label ID="lbllblTitle_SalePrice" runat="server" Text="Sales Price: "></asp:Label><i><asp:Label ID="lblSelected_SalePrice" runat="server" Text="0"></asp:Label></i>
            <br />
            <span class="requirdField">*</span><asp:Label ID="lblTitle_Qty" runat="server" Text="Quantity: " ></asp:Label><asp:TextBox ID="txtQty" runat="server" AutoPostBack="true" ToolTip="please let us know how many you want to purchase." OnTextChanged="txtQty_TextChanged"></asp:TextBox>
            <br />
            <asp:Label ID="lblTitle_TotalPrice" runat="server" Text="Total Price: "></asp:Label><i><asp:Label ID="lblSelected_TotalPrice" runat="server" Text="0"></asp:Label></i>
            <br />
            <span class="requirdField">*</span><asp:Label ID="lblTitle_CustomerName" runat="server" Text="Your Name: "></asp:Label><asp:TextBox ID="txtCustomerName" runat="server" ToolTip="please share us your name."></asp:TextBox>
            <br />
            <span class="requirdField">*</span><asp:Label ID="lblTitle_CustomerEmail" runat="server" Text="Your Email: "></asp:Label><asp:TextBox ID="txtCustomerEmail" runat="server" ToolTip="plese share us your email."></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Order" OnClick="btnSubmit_Click" OnClientClick="return confirm('Do you want to submit it? Click OK to proceed.');"  />
            <br />
            <asp:Label ID="lblFailMsg" runat="server" Text="" CssClass="failMsg"></asp:Label>
        </div>
    </form>
</body>
</html>
