using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services.IService
{
    public interface IMissionSkillService
    {
        Task<ResponseResult> addMissionSkillAsync(MissionSkillRequestModel model);
        Task<ResponseResult> GetMissionSkillListAsync();
        Task<ResponseResult> GetMissionSkillByIdAsync(int skillId);
        Task<ResponseResult> UpdateMissionSkillAsync(MissionSkillRequestModel model);
        Task<ResponseResult> DeleteMissionSkillAsync(int skillId);
    }
}
