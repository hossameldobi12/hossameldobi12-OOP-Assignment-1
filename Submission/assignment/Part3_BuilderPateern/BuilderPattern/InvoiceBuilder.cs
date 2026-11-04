namespace Part3_BuilderPattern
{
    public class InvoiceBuilder
    {
        private readonly int _invoiceId;
        private readonly CustomerInfo _customer;
        private readonly AddressInfo _billingAddress;
        private readonly OrderInfo _orderInfo;

        private AddressInfo? _shippingAddress;

        public InvoiceBuilder(
            int invoiceId,
            CustomerInfo customer,
            AddressInfo billingAddress,
            OrderInfo orderInfo)
        {
            _invoiceId = invoiceId;
            _customer = customer;
            _billingAddress = billingAddress;
            _orderInfo = orderInfo;
        }

        public InvoiceBuilder SetShippingAddress(
            AddressInfo shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public Invoice Build()
        {
            return new Invoice(
                _invoiceId,
                _customer,
                _billingAddress,
                _shippingAddress,
                _orderInfo);
        }
    }
}