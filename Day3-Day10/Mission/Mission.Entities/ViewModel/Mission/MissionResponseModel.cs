namespace Mission.Entities.ViewModel.Mission
{
    public class MissionResponseModel
    {
        public int Id { get; set; }
        public string MissionTitle { get; set; }
        public string MissionThemeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // get by id 
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int MissionThemeId { get; set; }
        public string MissionDescription { get; set; }
        public int TotalSeats { get; set; }
        public string MissionImages { get; set; }
        public string MissionSkillId { get; set; }
    }
}
