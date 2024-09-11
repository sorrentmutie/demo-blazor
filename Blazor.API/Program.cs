using Blazor.Data.Models;
using Blazor.Library.Map;
using Blazor.Library.Northwind.DTO;
using Blazor.UI.Library.Interop;
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


app.MapGet("/charts", () =>
{
    List<ChartData> dataList = new List<ChartData>();

    ChartData data = new ChartData
    {
        Id = "chart1",
        Labels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri" },
        Series = new List<List<int>>
            {
                new List<int> { 1, 1, 1, 1, 0 },
                new List<int> { 11, 21, 31, 41, 50 }
            }
    };

    ChartData data2 = new ChartData
    {
        Id = "chart2",
        Labels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri" },
        Series = new List<List<int>>
            {
                new List<int> { 31, 31,31, 31, 30 },
                new List<int> { 11, 21, 31, 41, 50 }
            }
    };

    ChartData data3 = new ChartData
    {
        Id = "chart3",
        Labels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri" },
        Series = new List<List<int>>
            {
                new List<int> { 8, 8, 8 }
            }
    };

    dataList.Add(data);
    //dataList.Add(data2);
    //dataList.Add(data3);

    return dataList;
});

app.Run();