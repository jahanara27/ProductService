using Newtonsoft.Json;

namespace ProductService
{
    public class Product
    {
        private int? _id;
        private string? _brand;
        private string? _model;
        private double? _price;
        public Product() { }
        public Product(int id, string brand, string model, double price)
        {
            _id = id;
            _brand = brand;
            _model = model;
            _price = price;
        }
        [JsonProperty(PropertyName ="Id")]
        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [JsonProperty(PropertyName = "Brand")]
        public string? Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        [JsonProperty(PropertyName = "Model")]
        public string? Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        [JsonProperty(PropertyName = "Price")]
        public double? Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var _products = new[] {
                new Product(1, "Apple", "iPhone X", 2000),
                new Product(2, "Samsung", "Note 9", 1400),
                new Product(3, "Google", "Pixel 3", 1309),
                new Product(4, "OnePlus", "6T", 788),
            };
            return _products.ToList();
        }
    }
}