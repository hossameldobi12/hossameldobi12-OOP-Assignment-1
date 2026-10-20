namespace Part3_BuilderPattern
{
    public class CustomerInfoBuilder
    {
        private readonly string _customerName;
        private readonly string _customerEmail;

        private string? _customerPhone;

        public CustomerInfoBuilder(
            string customerName,
            string customerEmail)
        {
            _customerName = customerName;
            _customerEmail = customerEmail;
        }

        public CustomerInfoBuilder SetCustomerPhone(string phone)
        {
            _customerPhone = phone;
            return this;
        }

        public CustomerInfo Build()
        {
            return new CustomerInfo(
                _customerName,
                _customerEmail,
                _customerPhone);
        }
    }
}