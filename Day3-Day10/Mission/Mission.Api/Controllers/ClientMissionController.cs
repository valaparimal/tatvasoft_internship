using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.Mission;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController(IMissionService missionService) : ControllerBase
    {
        [HttpGet]
        [Route("ClientSideMissionList/{userId:int}")]
        public async Task<IActionResult> ClientSideMissionList(int userId)
        {
            var response = await missionService.ClientSideMissionListAsync(userId);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("ApplyMission")]
        public async Task<IActionResult> ApplyMission(ApplyMissionRequestModel model)
        {
            var response = await missionService.ApplyMissionAsync(model);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("MissionClientList")]
        public async Task<IActionResult> MissionClientList(ClientListRequestModel model)
        {
            var response = await missionService.MissionClientListAsync(model);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);

        }
    }
}
