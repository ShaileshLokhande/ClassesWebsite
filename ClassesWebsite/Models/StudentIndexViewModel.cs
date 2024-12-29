namespace ClassesWebsite.Models
{
    public class StudentIndexViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }

}
