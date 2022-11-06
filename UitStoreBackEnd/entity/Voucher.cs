namespace UitStoreBackEnd.entity;

public class Voucher
{
    public Guid id { get; set; }

    public string name { get; set; }

    public double price { get; set; }

    public double discount { get; set; }

    public string time { get; set; }
}