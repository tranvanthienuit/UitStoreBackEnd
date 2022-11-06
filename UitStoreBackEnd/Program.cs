using Microsoft.EntityFrameworkCore;
using UitStoreBackEnd.db_context;
using UitStoreBackEnd.factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection =
    "Server=tcp:backenduit.database.windows.net,1433;Initial Catalog=backendmobile;Persist Security Info=False;User ID=CloudSA977394e2;Password=Vanthien@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
builder.Services.AddDbContext<dbcontext>(option => option.UseSqlServer(connection));

builder.Services.AddScoped(typeof(ICommentFactory), typeof(CommentFactory));
builder.Services.AddScoped(typeof(IDetailOrderFactory), typeof(DetailOrderFactory));
builder.Services.AddScoped(typeof(IFavorite_ProductFactory), typeof(Favorite_ProductFactory));
builder.Services.AddScoped(typeof(IProductFactory), typeof(ProductFactory));
builder.Services.AddScoped(typeof(IUserFactory), typeof(UserFactory));
builder.Services.AddScoped(typeof(IDetailOrderFactory), typeof(DetailOrderFactory));
builder.Services.AddScoped(typeof(IVoucherFactory), typeof(VoucherFactory));

var app = builder.Build();
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();