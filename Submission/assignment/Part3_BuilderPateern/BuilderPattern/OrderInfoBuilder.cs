namespace Part3_BuilderPattern
{
    public class OrderInfoBuilder
    {
        private readonly DateTime _orderDate;
        private readonly string _paymentMethod;
        private readonly string _currency;
        private readonly decimal _subTotal;

        private decimal _discountAmount;
        private decimal _taxAmount;

        public OrderInfoBuilder(
            DateTime orderDate,
            string paymentMethod,
            string currency,
            decimal subTotal)
        {
            _orderDate = orderDate;
            _paymentMethod = paymentMethod;
            _currency = currency;
            _subTotal = subTotal;
        }

        public OrderInfoBuilder SetDiscountAmount(decimal amount)
        {
            _discountAmount = amount;
            return this;
        }

        public OrderInfoBuilder SetTaxAmount(decimal amount)
        {
            _taxAmount = amount;
            return this;
        }

        public OrderInfo Build()
        {
            return new OrderInfo(
                _orderDate,
                _paymentMethod,
                _currency,
                _subTotal,
                _discountAmount,
                _taxAmount);
        }
    }
}