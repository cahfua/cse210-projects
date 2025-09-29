namespace OnlineOrdering
{
    /// <summary>
    /// Street address with helpers for USA check and formatted display.
    /// </summary>
    public class Address
    {
        private string _street;
        private string _city;
        private string _StateOrProvince;
        private string _country;

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string StateOrProvince
        {
            get { return _StateOrProvince; }
            set { _StateOrProvince = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public Address(string street, string city, string StateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _StateOrProvince = StateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            if (string.IsNullOrWhiteSpace(_country)) return false;
            var c = _country.Trim().ToLowerInvariant();
            return c == "usa" || c == "us" || c == "united states" || c == "united states of america";
        }

        public string ToMultilineString()
        {
            return $"{_street}\n{_city}, {_StateOrProvince}\n{_country}";
        }
    }
}