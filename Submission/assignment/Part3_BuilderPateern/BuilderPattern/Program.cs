using Part3_BuilderPattern;

var invoice = new InvoiceBuilder(
    1,
    "Ahmed Ali",
    "ahmed@example.com",
    "Tahrir Street",
    "Cairo",
    "Cairo",
    "11511",
    "Egypt",
    DateTime.Now,
    "Credit Card",
    "EGP",
    1000m)
    .SetCustomerPhone("01012345678")
    .SetShippingAddress(
        "Pyramids Street",
        "Giza",
        "Giza",
        "12511",
        "Egypt")
    .SetDiscountAmount(100m)
    .SetTaxAmount(140m)
    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Billing City: {invoice.BillingCity}");
Console.WriteLine($"Shipping City: {invoice.ShippingCity}");
Console.WriteLine($"Total Amount: {invoice.TotalAmount}");