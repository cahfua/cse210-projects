using System.Collections.Concurrent;

namespace OnlineOrdering
{
    /// <summary>
    /// Customer has a name and an Address. Knows if they live in the USA.
    /// </summary>
    public class Customer
    {
        private string _name;
        private Address _address;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public bool LivesInUSA()
        {
            return _address != null && _address.IsInUSA();
        }
    }
}