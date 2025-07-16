using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionTheme;

namespace Mission.Services.IService
{
    public interface IMissionThemeService
    {
        Task<ResponseResult> AddMissionThemeAsync(MissionThemeRequestModel model);
        Task<ResponseResult> GetMissionThemeListAsync();
        Task<ResponseResult> GetMissionThemeByIdAsync(int themeId);
        Task<ResponseResult> UpdateMissionThemeAsync(MissionThemeRequestModel model);
        Task<ResponseResult> DeleteMissionThemeAsync(int themeId);
    }
}
