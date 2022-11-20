namespace UitStoreBackEnd.filter;

public class ProductFilter
{
    public string? createDate { get; set; } = "ASC";

    public string? stock { get; set; } = "ASC";

    public string? discount { get; set; } = "ASC";

    public string? salePrice { get; set; } = "ASC";
}