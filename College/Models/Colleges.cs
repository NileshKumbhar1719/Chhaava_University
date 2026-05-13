namespace College.Models
{
    public class Colleges
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int UniversityId { get; set; } // relation
    }
}
