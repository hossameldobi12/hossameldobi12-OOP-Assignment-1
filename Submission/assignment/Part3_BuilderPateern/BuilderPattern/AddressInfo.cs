namespace Part3_BuilderPattern
{
    public class AddressInfo
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string Country { get; }

        public AddressInfo(
            string street,
            string city,
            string state,
            string zipCode,
            string country)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
}