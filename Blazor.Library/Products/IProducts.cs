namespace Blazor.Library.Products;

public interface IProducts
{
    IEnumerable<Product>? GetProducts();
    Task<IEnumerable<Product>?> GetProductsAsync();
    IEnumerable<Product>? GetOfferProducts();
    Task<IEnumerable<Product>?> GetOfferProductsAsync();

}
