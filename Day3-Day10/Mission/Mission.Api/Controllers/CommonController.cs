
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModel;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ICommonService commonService):ControllerBase
    {
        [HttpGet]
        [Route("MissionSkillList")]

        public async Task<IActionResult> MissionSkillList()
        {
            var response = await commonService.MissionSkillListAsync();

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("MissionThemeList")]
        public async Task<IActionResult> MissionThemeList()
        {
            var response = await commonService.MissionThemeListAsync();

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("CountryList")]
        public async Task<IActionResult> CountryList()
        {
            var response = await commonService.CountryListAsync();

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("CityList/{countryId:int}")]
        public async Task<IActionResult> CityList(int countryId)
        {
            var response = await commonService.CityListAsync(countryId);

            if (response.Result == ResponseStatus.Error)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("UploadImage")]

        public async Task<IActionResult> UploadImage()
        {
            List<string> filePathsList = new List<string>();
            var files = Request.Form.Files;

            try
            {
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var fName = file.FileName;
                        var fPath = Path.Combine("UploadMissionImage", "Mission");
                        string fileRootPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadMissionImage", "Mission");

                        if (!Directory.Exists(fileRootPath))
                        {
                            Directory.CreateDirectory(fileRootPath);
                        }

                        string name = Path.GetFileNameWithoutExtension(fName);
                        string extension = Path.GetExtension(fName);

                        string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                        fPath = Path.Combine(fPath, fullFileName);
                        string fullRootPath = Path.Combine(fileRootPath, fullFileName);
                        using (var stream = new FileStream(fullRootPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        filePathsList.Add(fPath);
                    }
                }

                return Ok(new { success = true, Data = filePathsList });
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
