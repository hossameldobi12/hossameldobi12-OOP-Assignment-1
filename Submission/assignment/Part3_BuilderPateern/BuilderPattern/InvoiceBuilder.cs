namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private readonly int _invoiceId;
    private readonly string _customerName;
    private readonly string _customerEmail;

    private readonly string _billingStreet;
    private readonly string _billingCity;
    private readonly string _billingState;
    private readonly string _billingZipCode;
    private readonly string _billingCountry;

    private readonly DateTime _orderDate;
    private readonly string _paymentMethod;
    private readonly string _currency;
    private readonly decimal _subTotal;

    private string? _customerPhone;

    private string? _shippingStreet;
    private string? _shippingCity;
    private string? _shippingState;
    private string? _shippingZipCode;
    private string? _shippingCountry;

    private decimal _discountAmount;
    private decimal _taxAmount;

    public InvoiceBuilder(
        int invoiceId,
        string customerName,
        string customerEmail,
        string billingStreet,
        string billingCity,
        string billingState,
        string billingZipCode,
        string billingCountry,
        DateTime orderDate,
        string paymentMethod,
        string currency,
        decimal subTotal)
    {
        _invoiceId = invoiceId;
        _customerName = customerName;
        _customerEmail = customerEmail;

        _billingStreet = billingStreet;
        _billingCity = billingCity;
        _billingState = billingState;
        _billingZipCode = billingZipCode;
        _billingCountry = billingCountry;

        _orderDate = orderDate;
        _paymentMethod = paymentMethod;
        _currency = currency;
        _subTotal = subTotal;
    }

    public InvoiceBuilder SetCustomerPhone(string phone)
    {
        _customerPhone = phone;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        _shippingStreet = street;
        _shippingCity = city;
        _shippingState = state;
        _shippingZipCode = zipCode;
        _shippingCountry = country;

        return this;
    }

    public InvoiceBuilder SetDiscountAmount(decimal amount)
    {
        _discountAmount = amount;
        return this;
    }

    public InvoiceBuilder SetTaxAmount(decimal amount)
    {
        _taxAmount = amount;
        return this;
    }

    public Invoice Build()
    {
        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone,
            _billingStreet,
            _billingCity,
            _billingState,
            _billingZipCode,
            _billingCountry,
            _shippingStreet,
            _shippingCity,
            _shippingState,
            _shippingZipCode,
            _shippingCountry,
            _orderDate,
            _paymentMethod,
            _currency,
            _subTotal,
            _discountAmount,
            _taxAmount);
    }
}