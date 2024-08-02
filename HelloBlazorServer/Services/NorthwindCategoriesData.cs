using Blazor.Data.Models;
using Blazor.Library.Northwind;
using Blazor.Library.Northwind.DTO;
using Microsoft.EntityFrameworkCore;

namespace HelloBlazorServer.Services;

public class NorthwindCategoriesData : ICategoriesData
{
    private readonly NorthwindContext northwindContext;

    public NorthwindCategoriesData(NorthwindContext northwindContext)
    {
        this.northwindContext = northwindContext;
    }


    public async Task AddCategoryAsync(CategoryDTO category)
    {
        await northwindContext.Categories.AddAsync(new Category
        {
            CategoryName = category.Name,
            Description = category.Description
        });
        await northwindContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryDTO>?> GetCategoriesAsync()
    {
        var categories = northwindContext.Categories.Select(c => new CategoryDTO
        {
            Id = c.CategoryId,
            Name = c.CategoryName,
            Description = c.Description
        });
        return await categories.ToListAsync();
    }

    public async Task<CategoryDTO?> GetCategoryAsync(int id)
    {
        return await northwindContext.Categories.Select(c => new CategoryDTO
        {
            Id = c.CategoryId,
            Name = c.CategoryName,
            Description = c.Description
        }).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateCategoryAsync(CategoryDTO category)
    {
        var categoryDb = await northwindContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.Id);
        if (categoryDb != null)
        {
            categoryDb.CategoryName = category.Name;
            categoryDb.Description = category.Description;
            await northwindContext.SaveChangesAsync();
        }
    }
}
