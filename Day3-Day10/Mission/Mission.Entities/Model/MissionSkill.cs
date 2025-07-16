using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Model
{
    public class MissionSkill
    {
        [Key]
        public int Id { get; set; }
        public required string SkillName { get; set; }
        public required string Status { get; set; }
    }
}
