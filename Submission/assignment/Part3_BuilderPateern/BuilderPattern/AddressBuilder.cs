namespace Part3_BuilderPattern
{
    public class AddressBuilder
    {
        private readonly string _street;
        private readonly string _city;
        private readonly string _state;
        private readonly string _zipCode;
        private readonly string _country;

        public AddressBuilder(
            string street,
            string city,
            string state,
            string zipCode,
            string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _zipCode = zipCode;
            _country = country;
        }

        public AddressInfo Build()
        {
            return new AddressInfo(
                _street,
                _city,
                _state,
                _zipCode,
                _country);
        }
    }
}