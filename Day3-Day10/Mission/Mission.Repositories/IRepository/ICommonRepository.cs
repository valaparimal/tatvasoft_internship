using Mission.Entities.ViewModel;

namespace Mission.Repositories.IRepository
{
    public interface ICommonRepository
    {
        Task<List<DropDownResponseModel>> MissionSkillListAsync();
        Task<List<DropDownResponseModel>> MissionThemeListAsync();
        Task<List<DropDownResponseModel>> CountryListAsync();
        Task<List<DropDownResponseModel>> CityListAsync(int countryId);
    }
}
