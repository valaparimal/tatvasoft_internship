using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.ViewModel.MissionSkill
{
    public class MissionSkillRequestModel
    {
        public required int Id { get; set; }
        public required string SkillName { get; set; }
        public string Status { get; set; }
    }
}
