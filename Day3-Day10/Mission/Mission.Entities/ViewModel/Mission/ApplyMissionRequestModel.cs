namespace Mission.Entities.ViewModel.Mission
{
    public class ApplyMissionRequestModel
    {
        public required int MissionId { get; set; }
        public required int UserId { get; set; }
        public required DateTime AppliedDate { get; set; }
    }
}
