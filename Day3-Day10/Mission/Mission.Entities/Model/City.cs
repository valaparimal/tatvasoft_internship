using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public required int CountryId { get; set; }
        public required string CityName { get; set; }
    }
}
