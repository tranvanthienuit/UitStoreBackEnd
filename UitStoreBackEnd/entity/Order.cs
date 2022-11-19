namespace UitStoreBackEnd.entity;

public class Order
{
    public Guid? id { get; set; }

    public Guid? userId { get; set; }

    public string? fullName { get; set; }

    public string? telephone { get; set; }

    public string? address { get; set; }

    public double? total { get; set; }

    public string? status { get; set; }
}