namespace UitStoreBackEnd.filter;

public class DetailOrderFilter
{
    public Guid? orderId { get; set; }

    public Guid? productId { get; set; }


    public string? name { get; set; }

    public double? price { get; set; }

    public int? size { get; set; }

    public int? quantity { get; set; }
}