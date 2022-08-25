using BeSpokeBikesAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IDiscountRepository, DiscountRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ISaleRepository, SaleRepository>();
builder.Services.AddSingleton<ISalespersonRepository, SalespersonRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicyAllHosts",
        builder =>
        {
            builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
