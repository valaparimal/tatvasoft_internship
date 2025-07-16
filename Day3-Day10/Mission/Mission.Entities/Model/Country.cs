using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public required string CountryName {get; set;}
    }
}
