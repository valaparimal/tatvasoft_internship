using Mission.Entities.ViewModel;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class CommonService(ICommonRepository commonRepository):ICommonService
    {
        public async Task<ResponseResult> MissionSkillListAsync()
        {
            var result = new ResponseResult();
            var response = await commonRepository.MissionSkillListAsync();

            if(response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionSkills Not Found!";
                return result;
            }

            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> MissionThemeListAsync()
        {
            var result = new ResponseResult();
            var response = await commonRepository.MissionThemeListAsync();

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionSkills Not Found!";
                return result;
            }

            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> CountryListAsync()
        {
            var result = new ResponseResult();
            var response = await commonRepository.CountryListAsync();

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionSkills Not Found!";
                return result;
            }

            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> CityListAsync(int countryId)
        {
            var result = new ResponseResult();
            var response = await commonRepository.CityListAsync(countryId);

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionSkills Not Found!";
                return result;
            }

            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }
    }
}
