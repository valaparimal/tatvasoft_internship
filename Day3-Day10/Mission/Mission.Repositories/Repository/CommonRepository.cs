using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.ViewModel;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class CommonRepository(MissionDbContext dbContext):ICommonRepository
    {
        private readonly MissionDbContext _context = dbContext;
        public async Task<List<DropDownResponseModel>> MissionSkillListAsync()
        {
            return await _context.MissionSkills
                .Where(s => s.Status == "active")
                .Select(s => new DropDownResponseModel(s.Id, s.SkillName))
                .ToListAsync();
        }

        public async Task<List<DropDownResponseModel>> MissionThemeListAsync()
        {
            return await _context.MissionThemes
                .Where(t => t.Status == "active")
                .Select(t => new DropDownResponseModel(t.Id, t.ThemeName))
                .ToListAsync();
        }

        public async Task<List<DropDownResponseModel>> CountryListAsync()
        {
            return await _context.Countries
                .OrderBy(c => c.CountryName)
                .Select(c => new DropDownResponseModel(c.Id, c.CountryName))
                .ToListAsync();
        }

        public async Task<List<DropDownResponseModel>> CityListAsync(int countryId)
        {
            return await _context.Cities
                .Where(c => c.CountryId == countryId)
                .Select(c => new DropDownResponseModel(c.Id, c.CityName))
                .ToListAsync();
        }
    }
}
