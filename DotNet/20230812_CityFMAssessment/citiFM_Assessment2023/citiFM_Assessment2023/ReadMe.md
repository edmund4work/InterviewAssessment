Still can improve:
--------------
1) able to add multiple
2) return api checking can move flexible


Question:
--------
1) A foreign exchange rate
FxRates (Get a list of all available foreign exchange rates)
[GET] /api/fx-rates
FxRate{
    sourceCurrency	string The source currency for the exchange rate
    targetCurrency	string The target currency for the exchange rate
    rate	number($double) The conversation rate from the source currency to the target currency
}

2) An order for one or more products
Orders (Submit an order)
[POST] /api/Orders
Order{
    customerName*	string The name of the customer
    customerEmail*	string he email address of the customer
    OrderLineItem*	[...]
}

OrderLineItem{
    productId*	string The id for the product to order
    quantity	integer($int32) maximum: 2147483647 minimum: 1 The quantity of the product to order
}

3) An available product
Products (Get a list of all available products)
[GET] /api/Products
Product{

    productId	string   The unique identifier for the product
    name	string    The name of the product
    description	string    A description for the product
    unitPrice	number($double)    The unit price for the product in Australian Dollars (AUD)
    maximumQuantity	integer($int32) The maximum quantity that is allowed to be ordered (in a single order) for the product

}


Your new API Key is: API-11YBQ5W9BXY3RPB
Your API key must be included in all requests to the API in a HTTP header names 'api-key'.
API keys cannot be retrieved once they are created. Make sure you save this key in a safe place like a password management tool.