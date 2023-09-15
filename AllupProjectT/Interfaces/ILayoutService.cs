using AllupProjectT.Models;

namespace AllupProjectT.Interfaces
{
    public interface ILayoutService
    {
        Task<Dictionary<string, string>> GetSettingsAsync();
        Task<List<Category>> GetCategoriesAsync();
    }
}
