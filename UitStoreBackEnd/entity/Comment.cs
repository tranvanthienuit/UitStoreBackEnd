namespace UitStoreBackEnd.entity;

public class Comment
{
    public Guid id { get; set; }

    public Guid productId { get; set; }

    public Guid userId { get; set; }

    public int rating { get; set; }

    public string content { get; set; }
}