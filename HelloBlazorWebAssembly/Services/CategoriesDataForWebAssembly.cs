using Blazor.Library.Northwind;
using Blazor.Library.Northwind.DTO;
using System.Net.Http.Json;

namespace HelloBlazorWebAssembly.Services;

public class CategoriesDataForWebAssembly : ICategoriesData
{
    private readonly HttpClient httpClient;
    private string url = "categories";

    public CategoriesDataForWebAssembly(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task AddCategoryAsync(CategoryDTO category)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDTO>?> GetCategoriesAsync()
    {
       var responseMessage = await httpClient.GetAsync(url);
        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<IEnumerable<CategoryDTO>>();

        }  else
        {
            return null;
        }
    }

    public Task<CategoryDTO?> GetCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(CategoryDTO category)
    {
        throw new NotImplementedException();
    }
}
