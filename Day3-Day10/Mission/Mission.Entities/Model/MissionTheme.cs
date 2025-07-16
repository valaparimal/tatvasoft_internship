using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Model
{
    public class MissionTheme
    {
        [Key]
        public int Id { get; set; }
        public required string ThemeName { get; set; }
        public required string Status { get; set; }

    }
}
