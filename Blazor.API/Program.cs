using Blazor.Data.Models;
using Blazor.Library.Map;
using Blazor.Library.Northwind.DTO;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/categories", async (NorthwindContext db) =>
{
    return await db.Categories.Select(c => new CategoryDTO
    {
        Id = c.CategoryId,
        Name = c.CategoryName,
        Description = c.Description,
        NumberOfProducts = c.Products.Count(),
        Products = c.Products.Select(p => new ProductDTO { Name = p.ProductName, Id = p.ProductId, IdFornitore = p.Supplier.SupplierId, NomeFornitore = p.Supplier.CompanyName })
    }).ToListAsync();
});

app.MapGet("/mapparameters", () =>
{
    var mapMarkers = new List<MapMarker>();
    mapMarkers.Add(new MapMarker { Id = 1, MapCoordinates = new MapCoordinates { Latitude = 49.01, Longitude = 10.01 }, Description = "desc1" });
    mapMarkers.Add(new MapMarker { Id = 2, MapCoordinates = new MapCoordinates { Latitude = 49.02, Longitude = 10.02 }, Description = "desc2" });

    var parameters = new List<MapParameters>();
    parameters.Add(new MapParameters
    {
        Id = "map1",
        Height = "200",
        Coordinates = new MapCoordinates { Latitude = 49.0, Longitude = 10.0 },
        Zoom = 10,
        Markers = mapMarkers
    });
    parameters.Add(new MapParameters { Id = "map2", Height = "200", Coordinates = new MapCoordinates { Latitude = 41, Longitude = 16 }, Zoom = 10 });
    return parameters;
});


app.Run();