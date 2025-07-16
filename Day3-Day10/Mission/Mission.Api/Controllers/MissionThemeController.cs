using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.MissionTheme;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController(IMissionThemeService missionThemeService):ControllerBase
    {
        [HttpPost]
        [Route("AddMissionTheme")]

        public async Task<IActionResult> AddMissionTheme(MissionThemeRequestModel mode)
        {
            var response = await missionThemeService.AddMissionThemeAsync(mode);

            if(response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetMissionThemeList")]

        public async Task<IActionResult> GetMissionThemeList()
        {
            var response = await missionThemeService.GetMissionThemeListAsync();

            if(response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetMissionThemeById/{themeId:int}")]
        public async Task<IActionResult> GetMissionThemeById(int themeId)
        {
            var response = await missionThemeService.GetMissionThemeByIdAsync(themeId);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateMissionTheme")]
        public async Task<IActionResult> UpdateMissionTheme(MissionThemeRequestModel mode)
        {
            var response = await missionThemeService.UpdateMissionThemeAsync(mode);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteMissionTheme{themeId:int}")]

        public async Task<IActionResult> DeleteMissionTheme(int themeId)
        {
            var response = await missionThemeService.DeleteMissionThemeAsync(themeId);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
