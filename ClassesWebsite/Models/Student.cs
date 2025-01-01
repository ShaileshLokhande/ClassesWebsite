using System.ComponentModel.DataAnnotations;

namespace ClassesWebsite.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Class { get; set; }
        public string Technology { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; }

        // Navigation Properties
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}
