using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionSkill;
using Mission.Repositories.IRepository;
using Mission.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services.Service
{
    public class MissionSkillService(IMissionSkillRepository missionSkillRepository):IMissionSkillService
    {
        public async Task<ResponseResult> addMissionSkillAsync(MissionSkillRequestModel model)
        {
            var result = new ResponseResult();
            var response = await missionSkillRepository.addMissionSkillAsync(model);

            if (response)
            {
                result.Result = ResponseStatus.Success;
                result.Message = "Mission Skill Added Successfully!";
                return result;
            }

            result.Result = ResponseStatus.Error;
            result.Message = "Mission Skill Already Exsist!";
            return result;
        }

        public async Task<ResponseResult> GetMissionSkillListAsync()
        {
            var result = new ResponseResult();
            var response = await missionSkillRepository.GetMissionSkillListAsync();

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Skills Not Found!";
                return result;
            }


            result.Data = response;
            result.Result = ResponseStatus.Success;
            return result;
        }


        public async Task<ResponseResult> GetMissionSkillByIdAsync(int skillId)
        {
            var result = new ResponseResult();
            var response = await missionSkillRepository.GetMissionSkillByIdAsync(skillId);

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Skill Not Found!";
                return result;
            }


            result.Data = response;
            result.Result = ResponseStatus.Success;
            return result;
        }

        public async Task<ResponseResult> UpdateMissionSkillAsync(MissionSkillRequestModel model)
        {
            var result = new ResponseResult();
            var response = await missionSkillRepository.UpdateMissionSkillAsync(model);

            if (response)
            {
                result.Result = ResponseStatus.Success;
                result.Message = "Mission Skill Updated Successfully!";
                return result;
            }

            result.Result = ResponseStatus.Error;
            result.Message = "Mission Skill Not Updated Successfully!";
            return result;
        }

        public async Task<ResponseResult> DeleteMissionSkillAsync(int skillId)
        {
            var result = new ResponseResult();
            var response = await missionSkillRepository.DeleteMissionSkillAsync(skillId);

            if (!response)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Skill Not Found!";
                return result;
            }

            result.Result = ResponseStatus.Success;
            return result;
        }
    }
}
