using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Model;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionTheme;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class MissionThemeRepository(MissionDbContext dbContext):IMissionThemeRepository
    {
        private readonly MissionDbContext _context = dbContext;

        public async Task<bool> AddMissionThemeAsync(MissionThemeRequestModel model)
        {
            var theme = await _context.MissionThemes.FindAsync(model.Id);

            if(theme != null)
            {
                return false;
            }

            var missionTheme = new MissionTheme()
            {
                ThemeName = model.ThemeName,
                Status = model.Status
            };

            _context.MissionThemes.Add(missionTheme);
            await _context.SaveChangesAsync();
            return true;

        }


        public async Task<List<MissionThemeResponseModel>> GetMissionThemeListAsync()
        {
            return await _context.MissionThemes.Select(theme => new MissionThemeResponseModel()
            {
                Id = theme.Id,
                ThemeName = theme.ThemeName,
                Status = theme.Status
            }).ToListAsync();
        }

        public async Task<MissionThemeResponseModel> GetMissionThemeByIdAsync(int themeId)
        {
             var theme = await _context.MissionThemes.FindAsync(themeId);

            if(theme == null)
            {
                return null;
            }

            return new MissionThemeResponseModel()
            {
                Id = theme.Id,
                ThemeName = theme.ThemeName,
                Status = theme.Status
            };
        }

        public async Task<bool> UpdateMissionThemeAsync(MissionThemeRequestModel model)
        {
            var theme = await _context.MissionThemes.FindAsync(model.Id);

            if (theme == null) return false;


            theme.ThemeName = model.ThemeName;
            theme.Status = model.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionThemeAsync(int themeId)
        {
            var theme = await _context.MissionThemes.FindAsync(themeId);

            if(theme == null)
            {
                return false;
            }

            _context.MissionThemes.Remove(theme);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
