using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.Mission;
using Mission.Entities.ViewModel.MissionApplication;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService):ControllerBase
    {
        [HttpPost]
        [Route("AddMission")]
        public async Task<IActionResult> AddMission(MissionRequestModel model)
        {
            var response = await missionService.AddMissionAsync(model);
            return Ok(response);
        }

        [HttpGet]
        [Route("MissionList")]

        public async Task<IActionResult> MissionList()
        {
            var response = await missionService.MissionListAsync();
            if(response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("MissionDetailById/{missionId:int}")]
        public async Task<IActionResult> MissionDetailById(int missionId)
        {
            var response = await missionService.MissionDetailByIdAsync(missionId);
            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateMission")]
        public async Task<IActionResult> UpdateMission(MissionRequestModel model)
        {
            var response = await missionService.UpdateMissionAsync(model);
            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteMission/{missionId:int}")]
        public async Task<IActionResult> DeleteMission(int missionId)
        {
            var response = await missionService.DeleteMissionAsync(missionId);
            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("MissionApplicationList")]

        public async Task<IActionResult> MissionApplicationList()
        {
            var response = await missionService.MissionApplicationListAsync();
            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("MissionApplicationApprove")]

        public async Task<IActionResult> MissionApplicationApprove(MissionApplicationRequestModel model)
        {
            var response = await missionService.MissionApplicationApproveAsync(model);
            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("MissionApplicationDelete")]
        public async Task<IActionResult> MissionApplicationDelete(MissionApplicationRequestModel model)
        {
            var response = await missionService.MissionApplicationDeleteAsync(model);
            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
