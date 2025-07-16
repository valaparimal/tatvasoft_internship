using Mission.Entities.ViewModel.MissionSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepository
{
    public interface IMissionSkillRepository
    {
        Task<bool> addMissionSkillAsync(MissionSkillRequestModel model);

        Task<List<MissionSkillResponseModel>> GetMissionSkillListAsync();
        Task<MissionSkillResponseModel> GetMissionSkillByIdAsync(int skillId);
        Task<bool> UpdateMissionSkillAsync(MissionSkillRequestModel model);

        Task<bool> DeleteMissionSkillAsync(int skillId);
    }
}
