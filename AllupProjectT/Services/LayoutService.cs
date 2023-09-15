using AllupProjectT.DataAccessLayer;
using AllupProjectT.Interfaces;
using AllupProjectT.Models;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;

namespace AllupProjectT.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        { 
            List<Category> categories = await _context.Catagoires
                .Include(c=>c.Children.Where(ch=>ch.IsDeleted==false))
                .Where(c=>c.IsDeleted == false && c.IsMain==true).ToListAsync();
            return categories;
        }

        public async Task<Dictionary<string, string>> GetSettingsAsync() 
        {
          Dictionary<string,string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key, s=>s.Value);
            return settings;
        }
    }
}
