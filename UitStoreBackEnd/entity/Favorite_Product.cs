namespace UitStoreBackEnd.entity;

public class Favorite_Product
{
    public Guid id { get; set; }

    public Guid userId { get; set; }

    public Guid? productId { get; set; }

    public string? image { get; set; }
}