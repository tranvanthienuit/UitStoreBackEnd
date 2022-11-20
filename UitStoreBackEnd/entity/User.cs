namespace UitStoreBackEnd.entity;

public class User
{
    public Guid id { get; set; }

    public string? username { get; set; }

    public string? password { get; set; }

    public string? fullname { get; set; }

    public string? telephone { get; set; }

    public string? address { get; set; }

    public DateTime? birthday { get; set; }

    public string? email { get; set; }

    public string? avatar { get; set; }

    public int? loyalPoint { get; set; }

    public string? role { get; set; }
}