namespace Part3_BuilderPattern
{
    public class Invoice
    {
        public int InvoiceId { get; }
        public CustomerInfo Customer { get; }
        public AddressInfo BillingAddress { get; }
        public AddressInfo? ShippingAddress { get; }
        public OrderInfo OrderInfo { get; }

        internal Invoice(
            int invoiceId,
            CustomerInfo customer,
            AddressInfo billingAddress,
            AddressInfo? shippingAddress,
            OrderInfo orderInfo)
        {
            InvoiceId = invoiceId;
            Customer = customer;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            OrderInfo = orderInfo;
        }
    }
}