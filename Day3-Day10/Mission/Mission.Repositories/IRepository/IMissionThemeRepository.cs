using Mission.Entities.ViewModel.MissionTheme;

namespace Mission.Repositories.IRepository
{
    public interface IMissionThemeRepository
    {
        Task<bool> AddMissionThemeAsync(MissionThemeRequestModel model);
        Task<List<MissionThemeResponseModel>> GetMissionThemeListAsync();
        Task<MissionThemeResponseModel> GetMissionThemeByIdAsync(int themeId);
        Task<bool> UpdateMissionThemeAsync(MissionThemeRequestModel model);
        Task<bool> DeleteMissionThemeAsync(int themeId);
    }
}
