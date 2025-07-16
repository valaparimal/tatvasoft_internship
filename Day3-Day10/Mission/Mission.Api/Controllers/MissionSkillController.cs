using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionSkill;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController(IMissionSkillService missionSkillService):ControllerBase
    {
        [HttpPost]
        [Route("AddMissionSkill")]
        public async Task<IActionResult> AddMissionSkill(MissionSkillRequestModel model)
        {
            var response = await missionSkillService.addMissionSkillAsync(model);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetMissionSkillList")]

        public async Task<IActionResult> GetMissionSkillList()
        {
            var response = await missionSkillService.GetMissionSkillListAsync();

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetMissionSkillById/{skillId:int}")]

        public async Task<IActionResult> GetMissionSkillById(int skillId)
        {
            var response = await missionSkillService.GetMissionSkillByIdAsync(skillId);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpPost]
        [Route("UpdateMissionSkill")]

        public async Task<IActionResult> UpdateMissionSkill(MissionSkillRequestModel model)
        {
            var response = await missionSkillService.UpdateMissionSkillAsync(model);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteMissionSkill/{skillId:int}")]

        public async Task<IActionResult> DeleteMissionSkill(int skillId)
        {
            var response = await missionSkillService.DeleteMissionSkillAsync(skillId);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
