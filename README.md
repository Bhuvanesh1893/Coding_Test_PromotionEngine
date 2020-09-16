# Coding_Test_PromotionEngine
Coding Test Promotion Engine

Tools used - Visual Studio 2019
Frameworks used - .Net Framework 4.6.2, NUnit 3.12, NUnit3TestAdaptor

Coding Patterns used - Adaptor pattern, Interface Inversion principle

Overview - 
1. API created which accepts the Line Items information and returns back with the cart total.
2. Two promotions added in different class files.
3. Configured 3 active promotions.
4. Created a separate class library with adaptors for the fetcing the SKU Price info (hardcoded for now, no use of Db).

URL - {localhost}/api/Order

Sample Test Input :
{
    "LineItems": [
        {
            "skuId": "A",
            "quantity": 5
        },
        {
            "skuId": "A",
            "quantity": 5
        },
        {
            "skuId": "B",
            "quantity": 5
        },
	    {
            "skuId": "C",
            "quantity": 1
        },
        {
            "skuId": "D",
            "quantity": 1
        }
    ]
}

Sample Test Output :
{
    "LineItemPrice": [
        {
            "skuId": "A",
            "quantity": 5,
            "promoDesc": "Buy3For130",
            "skuTotal": 230.0
        },
        {
            "skuId": "A",
            "quantity": 5,
            "promoDesc": "Buy3For130",
            "skuTotal": 230.0
        },
        {
            "skuId": "B",
            "quantity": 5,
            "promoDesc": "Buy2For45",
            "skuTotal": 120.0
        },
        {
            "skuId": "C",
            "quantity": 1,
            "promoDesc": "Buy2SKUfor30",
            "skuTotal": 0.0
        },
        {
            "skuId": "D",
            "quantity": 1,
            "promoDesc": "Buy2SKUfor30",
            "skuTotal": 30.0
        }
    ],
    "CartTotal": 610.0,
    "RespMessage": {
        "StatusCode": 200,
        "StatusMessage": "Success"
    }
}
