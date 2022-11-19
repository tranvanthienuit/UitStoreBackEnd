namespace UitStoreBackEnd.model.product;

public class ProductDetail
{
    public Guid id { get; set; }

    public string name { get; set; }

    public int size { get; set; }

    public int stock { get; set; }

    public double price { get; set; }

    public string description { get; set; }

    public double salePrice { get; set; }

    public string image { get; set; }

    public double rating { get; set; }

    public string imageFavorite { get; set; }
}