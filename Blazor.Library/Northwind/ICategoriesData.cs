using Blazor.Library.Northwind.DTO;

namespace Blazor.Library.Northwind;

public interface ICategoriesData
{
    Task<IEnumerable<CategoryDTO>?> GetCategoriesAsync();
    Task<CategoryDTO?> GetCategoryAsync(int id);
    Task AddCategoryAsync(CategoryDTO category);
    Task UpdateCategoryAsync(CategoryDTO category);
}
