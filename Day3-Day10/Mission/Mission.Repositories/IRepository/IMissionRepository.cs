using Mission.Entities.ViewModel.Mission;
using Mission.Entities.ViewModel.MissionApplication;

namespace Mission.Repositories.IRepository
{
    public interface IMissionRepository
    {
        Task AddMissionAsync(MissionRequestModel model);
        Task<List<MissionResponseModel>> MissionListAsync();
        Task<MissionResponseModel> MissionDetailByIdAsync(int missionId);
        Task<bool> UpdateMissionAsync(MissionRequestModel model);
        Task<bool> DeleteMissionAsync(int missionId);

        Task<List<ClientMissionResponseModel>> ClientSideMissionListAsync(int userId);
        Task<(bool response, string message)> ApplyMissionAsync(ApplyMissionRequestModel model);
        Task<List<MissionApplicationResponseModel>> MissionApplicationListAsync();
        Task<bool> MissionApplicationApproveAsync(MissionApplicationRequestModel model);
        Task<bool> MissionApplicationDeleteAsync(MissionApplicationRequestModel model);
        Task<List<ClientMissionResponseModel>> MissionClientListAsync(ClientListRequestModel model);
    }
}
