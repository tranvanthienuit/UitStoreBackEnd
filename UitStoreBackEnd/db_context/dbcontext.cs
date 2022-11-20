using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.db_context;

public class dbcontext : DbContext
{
    public dbcontext(DbContextOptions<dbcontext> options) : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<DetailOrder> DetailOrders { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }
}