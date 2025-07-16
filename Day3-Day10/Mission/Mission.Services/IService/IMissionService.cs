using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.Mission;
using Mission.Entities.ViewModel.MissionApplication;

namespace Mission.Services.IService
{
    public interface IMissionService
    {
        Task<ResponseResult> AddMissionAsync(MissionRequestModel model);
        Task<ResponseResult> MissionListAsync();
        Task<ResponseResult> MissionDetailByIdAsync(int missionId);
        Task<ResponseResult> UpdateMissionAsync(MissionRequestModel model);
        Task<ResponseResult> DeleteMissionAsync(int missionId);
        Task<ResponseResult> ClientSideMissionListAsync(int userId);
        Task<ResponseResult> ApplyMissionAsync(ApplyMissionRequestModel model);
        Task<ResponseResult> MissionApplicationListAsync();
        Task<ResponseResult> MissionApplicationApproveAsync(MissionApplicationRequestModel model);
        Task<ResponseResult> MissionApplicationDeleteAsync(MissionApplicationRequestModel model);
        Task<ResponseResult> MissionClientListAsync(ClientListRequestModel model);
    }
}
