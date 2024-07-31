namespace Blazor.Library.Products.Services;

public class StaticProductsService : IProducts
{
    private static List<Product> offerProducts = new List<Product>()
    {
           new Product
        {
            Id = 1,
            Name = "Offer Product 1",
            Price = 100,
            Category = "Category 1",
            Description = "Description 1",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 2,
            Name = "Offer Product 2",
            Price = 200,
            Category = "Category 2",
            Description = "Description 2",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 3,
            Name = "Offer Product 3",
            Price = 300,
            Category = "Category 3",
            Description = "Description 3",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 4,
            Name = "Offer Product 4",
            Price = 400,
            Category = "Category 4",
            Description = "Description 4",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 5,
            Name = "Offer Product 5",
            Price = 500,
            Category = "Category 5",
            Description = "Description 5",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        } };


    private static List<Product> products = new List<Product>()
    {
        new Product
        {
            Id = 1,
            Name = "Product 1",
            Price = 100,
            Category = "Category 1",
            Description = "Description 1",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 2,
            Name = "Product 2",
            Price = 200,
            Category = "Category 2",
            Description = "Description 2",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 3,
            Name = "Product 3",
            Price = 300,
            Category = "Category 3",
            Description = "Description 3",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 4,
            Name = "Product 4",
            Price = 400,
            Category = "Category 4",
            Description = "Description 4",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        },
        new Product
        {
            Id = 5,
            Name = "Product 5",
            Price = 500,
            Category = "Category 5",
            Description = "Description 5",
            ImagePath = "https://via.placeholder.com/150/00FFFF"
        }
    };

    public IEnumerable<Product>? GetOfferProducts()
    {
        return offerProducts;
    }

    public Task<IEnumerable<Product>?> GetOfferProductsAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product>? GetProducts()
    {
        return products;
    }

    public Task<IEnumerable<Product>?> GetProductsAsync()
    {
        throw new NotImplementedException();
    }
}
