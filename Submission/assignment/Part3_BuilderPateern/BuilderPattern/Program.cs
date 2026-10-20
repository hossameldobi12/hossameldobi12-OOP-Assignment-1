using Part3_BuilderPattern;

var customer = new CustomerInfoBuilder(
    "Ahmed Ali",
    "ahmed@example.com")
    .SetCustomerPhone("01012345678")
    .Build();

var billingAddress = new AddressBuilder(
    "Tahrir Street",
    "Cairo",
    "Cairo",
    "11511",
    "Egypt")
    .Build();

var orderInfo = new OrderInfoBuilder(
    DateTime.Now,
    "Credit Card",
    "EGP",
    1000m)
    .SetDiscountAmount(100m)
    .SetTaxAmount(140m)
    .Build();

var shippingAddress = new AddressBuilder(
    "Pyramids Street",
    "Giza",
    "Giza",
    "12511",
    "Egypt")
    .Build();

var invoice = new InvoiceBuilder(
    1,
    customer,
    billingAddress,
    orderInfo)
    .SetShippingAddress(shippingAddress)
    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.Customer.CustomerName}");
Console.WriteLine($"Email: {invoice.Customer.CustomerEmail}");
Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress?.City}");
Console.WriteLine($"Payment Method: {invoice.OrderInfo.PaymentMethod}");
Console.WriteLine($"Total Amount: {invoice.OrderInfo.TotalAmount}");