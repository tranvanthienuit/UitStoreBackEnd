using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.model.order;

public class OrderDetail
{
    public Guid? userId { get; set; }

    public string? fullName { get; set; }

    public string? telephone { get; set; }

    public string? address { get; set; }

    public double? total { get; set; }

    public string? status { get; set; }

    public List<DetailOrder> DetailOrders { get; set; }
}