using Blazor.Library.Products.Services;
using Blazor.Library.Products;
using Blazor.UI.Library;
using HelloBlazorWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.Library.Contacts.Interfaces;
using Blazor.Library.Contacts.Services;
using Blazor.Library.Northwind;
using HelloBlazorWebAssembly.Services;
using Blazor.Library.Map;
using Blazor.Library.Charts.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7265/") });
builder.Services.AddScoped<IProducts, StaticProductsService>();
builder.Services.AddScoped<IContact, ContactService>();
builder.Services.AddScoped<IMapParameters, MapParametersWASM>();

builder.Services.AddScoped<ICategoriesData, CategoriesDataForWebAssembly>();
builder.Services.AddScoped<IDataChart, ChartServiceWasm>();




await builder.Build().RunAsync();
