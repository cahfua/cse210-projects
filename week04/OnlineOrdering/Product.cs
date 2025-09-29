namespace OnlineOrdering
{
    /// <summary>
    /// Product with id, price per unit, and quantity. Can compute its total cost.
    ///  </summary>
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _pricePerUnit;
        private int _quantity;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public decimal PricePerUnit
        {
            get { return _pricePerUnit; }
            set { _pricePerUnit = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return _pricePerUnit * _quantity;
        }
    }
}