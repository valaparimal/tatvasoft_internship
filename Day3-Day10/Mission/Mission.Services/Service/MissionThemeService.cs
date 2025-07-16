using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionTheme;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class MissionThemeService(IMissionThemeRepository missionThemeRepository) : IMissionThemeService
    {
        public async Task<ResponseResult> AddMissionThemeAsync(MissionThemeRequestModel model)
        {
            var result = new ResponseResult();
            var response =await missionThemeRepository.AddMissionThemeAsync(model);

            if (response)
            {
                result.Message = "Theme Added SuccessFully!";
                result.Result = ResponseStatus.Success;
                return result;
            }

            result.Message = "Theme Not Added SuccessFully!";
            result.Result = ResponseStatus.Error;
            return result;
        }

        public async Task<ResponseResult> GetMissionThemeListAsync()
        {
            var result = new ResponseResult();
            var response = await missionThemeRepository.GetMissionThemeListAsync();

            if(response == null)
            {
                result.Message = "Data Not Found!";
                result.Result = ResponseStatus.Error;
                return result;
            }

            result.Data = response;
            result.Result = ResponseStatus.Success;
            return result;
        }

        public async Task<ResponseResult> GetMissionThemeByIdAsync(int themeId)
        {
            var result = new ResponseResult();
            var response = await missionThemeRepository.GetMissionThemeByIdAsync(themeId);

            if (response == null)
            {
                result.Message = "Data Not Found!";
                result.Result = ResponseStatus.Error;
                return result;
            }

            result.Data = response;
            result.Result = ResponseStatus.Success;
            return result;
        }

        public async Task<ResponseResult> UpdateMissionThemeAsync(MissionThemeRequestModel model)
        {
            var result = new ResponseResult();
            var response = await missionThemeRepository.UpdateMissionThemeAsync(model);

            if (response)
            {
                result.Message = "Theme Updated SuccessFully!";
                result.Result = ResponseStatus.Success;
                return result;
            }

            result.Message = "Theme Not Found With Given Id!";
            result.Result = ResponseStatus.Error;
            return result;
        }

        public async Task<ResponseResult> DeleteMissionThemeAsync(int themeId)
        {
            var result = new ResponseResult();
            var response = await missionThemeRepository.DeleteMissionThemeAsync(themeId);

            if (response)
            {
                result.Message = "Theme Deleted SuccessFully!";
                result.Result = ResponseStatus.Success;
                return result;
            }

            result.Message = "Theme Not Deleted SuccessFully!";
            result.Result = ResponseStatus.Error;
            return result;
        }
    }
}
