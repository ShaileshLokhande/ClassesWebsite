using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassesWebsite.Models
{
    public class StudentIndexViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        // Updated properties for cascading dropdowns
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }


}
