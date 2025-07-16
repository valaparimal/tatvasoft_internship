using Mission.Entities.ViewModel;

namespace Mission.Services.IService
{
    public interface ICommonService
    {
        Task<ResponseResult> MissionSkillListAsync();
        Task<ResponseResult> MissionThemeListAsync();
        Task<ResponseResult> CountryListAsync();
        Task<ResponseResult> CityListAsync(int countryId);
    }
}
