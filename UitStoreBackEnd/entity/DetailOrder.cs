namespace UitStoreBackEnd.entity;

public class DetailOrder
{
    public Guid id { get; set; }

    public Guid orderId { get; set; }

    public Guid productId { get; set; }

    public int quantity { get; set; }
}