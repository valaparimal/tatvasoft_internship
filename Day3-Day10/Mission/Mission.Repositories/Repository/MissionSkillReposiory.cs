using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Model;
using Mission.Entities.ViewModel.MissionSkill;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class MissionSkillReposiory(MissionDbContext dbContext):IMissionSkillRepository
    {
        public readonly MissionDbContext _context = dbContext;

        public async Task<bool> addMissionSkillAsync(MissionSkillRequestModel model)
        {
            var missionSkill = _context.MissionSkills.Find(model.Id);

            if (missionSkill != null)
            {
                  return false;
            }

            var skill = new MissionSkill() {
                Id = model.Id,
                SkillName = model.SkillName,
                Status = model.Status
            };

            _context.MissionSkills.Add(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MissionSkillResponseModel>> GetMissionSkillListAsync()
        {
            return await _context.MissionSkills.Select(skill => new MissionSkillResponseModel()
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
                Status = skill.Status
            }).ToListAsync();
        }

        public async Task<MissionSkillResponseModel> GetMissionSkillByIdAsync(int skillId)
        {
            var skill =await _context.MissionSkills.FindAsync(skillId);

            if(skill == null)
            {
                return null;
            }

            return new MissionSkillResponseModel()
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
                Status = skill.Status
            };
        }

        public async Task<bool> UpdateMissionSkillAsync(MissionSkillRequestModel model)
        {
            var missionSkill = await _context.MissionSkills.FindAsync(model.Id);

            if (missionSkill == null)
            {
                return false;
            }

            missionSkill.SkillName = model.SkillName;
            missionSkill.Status = model.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionSkillAsync(int skillId)
        {
            var skill = await _context.MissionSkills.FindAsync(skillId);

            if (skill == null)
            {
                return false;
            }

             _context.MissionSkills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
