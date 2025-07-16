using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Model;
using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.Mission;
using Mission.Entities.ViewModel.MissionApplication;
using Mission.Repositories.IRepository;
using System.Reflection;

namespace Mission.Repositories.Repository
{
    public class MissionRepository(MissionDbContext dbContext):IMissionRepository
    {
        private readonly MissionDbContext _context = dbContext;

        public async Task AddMissionAsync(MissionRequestModel model)
        {
            var mission = new Mission_()
            {
                CityId = model.CityId,
                CountryId = model.CountryId,
                MissionDescription = model.MissionDescription,
                MissionImages = model.MissionImages,
                MissionSkillId = model.MissionSkillId,
                MissionThemeId = model.MissionThemeId,
                MissionTitle = model.MissionTitle,
                StartDate = model.StartDate.Date.ToUniversalTime(),
                EndDate = model.EndDate.Date.ToUniversalTime(),
                TotalSeats = model.TotalSeats,
            };

            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MissionResponseModel>> MissionListAsync()
        {
            return await _context.Missions.Select(m => new MissionResponseModel
            {
                Id = m.Id,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate.Date.ToUniversalTime(),
                EndDate = m.EndDate.Date.ToUniversalTime(),
                CountryId = m.CountryId,
                CityId = m.CityId,
                MissionDescription = m.MissionDescription,
                MissionSkillId = m.MissionSkillId,
                MissionImages = m.MissionImages,
                TotalSeats = m.TotalSeats
            }).ToListAsync();
        }

        public async Task<MissionResponseModel?> MissionDetailByIdAsync(int missionId)
        {
            return await _context.Missions.Where(m=>m.Id == missionId).Select(m=> new MissionResponseModel()
            {
                Id = m.Id,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate.Date.ToUniversalTime(),
                EndDate = m.EndDate.Date.ToUniversalTime(),
                CountryId = m.CountryId,
                CityId = m.CityId,
                MissionDescription = m.MissionDescription,
                MissionSkillId = m.MissionSkillId,
                MissionImages   = m.MissionImages,
                TotalSeats = m.TotalSeats
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMissionAsync(MissionRequestModel model)
        {
            var mission = _context.Missions.Find(model.Id);

            if(mission == null)
            {
                return false;
            }

            mission.MissionTitle = model.MissionTitle;
            mission.CityId = model.CityId;
            mission.CountryId = model.CountryId;
            mission.MissionSkillId = model.MissionSkillId;
            mission.MissionImages = model.MissionImages;
            mission.MissionThemeId = model.MissionThemeId;
            mission.MissionDescription = model.MissionDescription;
            mission.StartDate = model.StartDate.Date.ToUniversalTime();
            mission.EndDate = model.EndDate.Date.ToUniversalTime();
            mission.TotalSeats = model.TotalSeats;

            await _context.SaveChangesAsync();

            return true;
            
        }

        public async Task<bool> DeleteMissionAsync(int missionId)
        {
            var mission = await _context.Missions.FindAsync(missionId);

            if (mission == null) return false;

             _context.Remove(mission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClientMissionResponseModel>> ClientSideMissionListAsync(int userId)
        {
            return await _context.Missions.Select(m => new ClientMissionResponseModel
            {
                Id = m.Id,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate.Date.ToUniversalTime(),
                EndDate = m.EndDate.Date.ToUniversalTime(),
                CountryId = m.CountryId,
                CityId = m.CityId,
                MissionDescription = m.MissionDescription,
                MissionSkillId = m.MissionSkillId,
                MissionImages = m.MissionImages,
                TotalSeats = m.TotalSeats,
                MissionThemeName = m.MissionTheme.ThemeName,
                CityName = m.City.CityName,
                CountryName = m.Country.CountryName,
                MissionSkillName = string.Join(',',_context.MissionSkills
                    .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                    .Select(ms => ms.SkillName)
                    .ToList()),
                MissionApplyStatus = _context.MissionApplications.Any(ma =>!ma.IsDelete && ma.MissionId == m.Id && ma.UserId == userId)?"Applied" : "Apply",
                MissionApproveStatus = _context.MissionApplications.Any(ma => !ma.IsDelete && ma.MissionId == m.Id && ma.UserId == userId && ma.Status) ? "Approved" : "Applied"
            }).ToListAsync();
        }

        public async Task<(bool response, string message)> ApplyMissionAsync(ApplyMissionRequestModel model)
        {
            var mission = _context.Missions.Find(model.MissionId);

            if (mission == null) return (false, "Mission Not Found With Given Id!");

            if (mission.TotalSeats <= 0) return (false, "You can apply on this mission because seats are already full!");

            _context.MissionApplications.Add(new MissionApplication()
            {
                MissionId = model.MissionId,
                UserId = model.UserId,
                AppliedDate = model.AppliedDate.ToUniversalTime()
            });

            mission.TotalSeats--;

            await _context.SaveChangesAsync();

            return (true,"Mission Applied Successfully!");
        }

        public async Task<List<MissionApplicationResponseModel>> MissionApplicationListAsync()
        {
            return await _context.MissionApplications.Where(m => !m.IsDelete)
                .Select(m => new MissionApplicationResponseModel()
            {
                Id = m.Id,
                MissionTitle = m.Mission.MissionTitle,
                MissionTheme = m.Mission.MissionTheme.ThemeName,
                AppliedDate = m.AppliedDate.ToUniversalTime(),
                UserName = m.User.FirstName +" "+m.User.LastName,
                Status = m.Status,
            }).ToListAsync();
        }

        public async Task<bool> MissionApplicationApproveAsync(MissionApplicationRequestModel model)
        {
            var mission = _context.MissionApplications.Find(model.Id);

            if (mission == null) return false;

            mission.Status = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MissionApplicationDeleteAsync(MissionApplicationRequestModel model)
        {
            var mission = _context.MissionApplications.Include(m=>m.Mission).FirstOrDefault(m=>m.Id == model.Id);

            if (mission == null) return false;

            mission.IsDelete = true;

            mission.Mission.TotalSeats++;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClientMissionResponseModel>> MissionClientListAsync(ClientListRequestModel model)
        {

            var sort = model.SortestValue;
            var userId = model.UserId;

            var missionsQuery = _context.Missions.AsQueryable();


            missionsQuery = sort switch
            {
                "Newest" => missionsQuery.OrderByDescending(m => m.StartDate),
                "Oldest" => missionsQuery.OrderBy(m => m.StartDate),
                "Lowest available seats" => missionsQuery.OrderBy(m => m.TotalSeats),
                "Highest available seats" => missionsQuery.OrderByDescending(m => m.TotalSeats),
                "Registration deadline" => missionsQuery.OrderBy(m => m.EndDate),
                _ => missionsQuery.OrderByDescending(m => m.StartDate) // Default to Newest if not specified
            };



            return await missionsQuery.Select(m => new ClientMissionResponseModel
            {
                Id = m.Id,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate.Date.ToUniversalTime(),
                EndDate = m.EndDate.Date.ToUniversalTime(),
                CountryId = m.CountryId,
                CityId = m.CityId,
                MissionDescription = m.MissionDescription,
                MissionSkillId = m.MissionSkillId,
                MissionImages = m.MissionImages,
                TotalSeats = m.TotalSeats,
                MissionThemeName = m.MissionTheme.ThemeName,
                CityName = m.City.CityName,
                CountryName = m.Country.CountryName,
                MissionSkillName = string.Join(',', _context.MissionSkills
                    .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                    .Select(ms => ms.SkillName)
                    .ToList()),
                MissionApplyStatus = _context.MissionApplications.Any(ma => !ma.IsDelete && ma.MissionId == m.Id && ma.UserId == userId) ? "Applied" : "Apply",
                MissionApproveStatus = _context.MissionApplications.Any(ma => !ma.IsDelete && ma.MissionId == m.Id && ma.UserId == userId && ma.Status) ? "Approved" : "Applied"
            }).ToListAsync();
        }
    }
}
