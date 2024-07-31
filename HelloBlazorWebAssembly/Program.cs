using Blazor.Library.Products.Services;
using Blazor.Library.Products;
using Blazor.UI.Library;
using HelloBlazorWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProducts, StaticProductsService>();

await builder.Build().RunAsync();
