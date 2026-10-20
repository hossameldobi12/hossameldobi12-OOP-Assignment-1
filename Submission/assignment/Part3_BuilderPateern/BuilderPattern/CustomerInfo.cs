namespace Part3_BuilderPattern
{
    public class CustomerInfo
    {
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string? CustomerPhone { get; }

        public CustomerInfo(
            string customerName,
            string customerEmail,
            string? customerPhone)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
        }
    }
}