using Mission.Entities.Model;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.Mission;
using Mission.Entities.ViewModel.MissionApplication;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class MissionService(IMissionRepository missionRepository):IMissionService
    {
        public async Task<ResponseResult> AddMissionAsync(MissionRequestModel model)
        {
            await missionRepository.AddMissionAsync(model);

            return new ResponseResult()
            {
                Result = ResponseStatus.Success,
                Message = "Mission Added Successfully!"
            };
        }

        public async Task<ResponseResult> MissionListAsync()
        {
            var result = new ResponseResult();

            var response = await missionRepository.MissionListAsync();

            if(response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> MissionDetailByIdAsync(int missionId)
        {
            var result = new ResponseResult();

            var response = await missionRepository.MissionDetailByIdAsync(missionId);

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> UpdateMissionAsync(MissionRequestModel model)
        {
            var result = new ResponseResult();

            var response = await missionRepository.UpdateMissionAsync(model);

            if (!response)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Not Found With Given Id!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Message = "Mission Updated Successfully!";
            return result;
        }

        public async Task<ResponseResult> DeleteMissionAsync(int missionId)
        {
            var result = new ResponseResult();

            var response = await missionRepository.DeleteMissionAsync(missionId);

            if (!response)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Not Found With Given Id!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Message = "Mission Deleted Successfully!";
            return result;
        }

        public async Task<ResponseResult> ClientSideMissionListAsync(int userId)
        {
            var result = new ResponseResult();

            var response = await missionRepository.ClientSideMissionListAsync(userId);

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> ApplyMissionAsync(ApplyMissionRequestModel model)
        {
            var result = new ResponseResult();

            var (response,massege) = await missionRepository.ApplyMissionAsync(model);

            if (!response)
            {
                result.Result = ResponseStatus.Error;
                result.Message = massege;
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Message = massege;
            return result;
        }

        public async Task<ResponseResult> MissionApplicationListAsync()
        {
            var result = new ResponseResult();

            var response = await missionRepository.MissionApplicationListAsync();

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionApplication Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }

        public async Task<ResponseResult> MissionApplicationApproveAsync(MissionApplicationRequestModel model)
        {
            var result = new ResponseResult();

            var response = await missionRepository.MissionApplicationApproveAsync(model);

            if (!response)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionApplication Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Message = "MissionApplication Approved Successfully!";
            return result;
        }

        public async Task<ResponseResult> MissionApplicationDeleteAsync(MissionApplicationRequestModel model)
        {
            var result = new ResponseResult();

            var response = await missionRepository.MissionApplicationDeleteAsync(model);

            if (!response)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "MissionApplication Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Message = "MissionApplication Approved Successfully!";
            return result;
        }

        public async Task<ResponseResult> MissionClientListAsync(ClientListRequestModel model)
        {
            var result = new ResponseResult();

            var response = await missionRepository.MissionClientListAsync(model);

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Not Found!";
                return result;
            }


            result.Result = ResponseStatus.Success;
            result.Data = response;
            return result;
        }
    }
}
