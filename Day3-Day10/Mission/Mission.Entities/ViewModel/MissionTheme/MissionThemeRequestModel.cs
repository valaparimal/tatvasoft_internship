using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.ViewModel.MissionTheme
{
    public class MissionThemeRequestModel
    {
        public int Id { get; set; }
        public required string ThemeName { get; set; }
        public required string Status { get; set; }
    }
}
