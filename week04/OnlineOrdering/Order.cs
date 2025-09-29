using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    /// <summary>
    /// Order contains a Customer and a list of Products.
    /// Compute totals (with shipping) and produces packing/shipping labels.
    /// </summary>
    public class Order
    {
        private const decimal UsaShipping = 5m;
        private const decimal IntlShipping = 35m;

        private readonly List<Product> _products = new List<Product>();
        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal subtotal = 0m;
            foreach (var p in _products)
            {
                subtotal += p.GetTotalCost();
            }

            decimal shipping = (_customer != null && _customer.LivesInUSA()) ? UsaShipping : IntlShipping;
            return subtotal + shipping;
        }

        /// <summary>
        /// packing label: each line shows product name and product id.
        /// </summary>
        public string GetPackingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("PACKING LABEL");
            foreach (var p in _products)
            {
                sb.AppendLine($"- {p.Name} (ID: {p.ProductId})");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Shipping label: customer name and full multiline address.
        /// </summary>
        public string GetShippingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("SHIPPING LABEL");
            sb.AppendLine(_customer.Name);
            sb.Append(_customer.Address.ToMultilineString());
            return sb.ToString();
        }
    }
}