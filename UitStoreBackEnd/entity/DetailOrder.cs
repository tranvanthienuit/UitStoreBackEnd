namespace UitStoreBackEnd.entity;

public class DetailOrder
{
    public Guid id { get; set; }

    public Guid orderId { get; set; }

    public Guid productId { get; set; }

    public string? image { get; set; }

    public string? name { get; set; }

    public double? price { get; set; }

    public int? size { get; set; }

    public int? quantity { get; set; }
}