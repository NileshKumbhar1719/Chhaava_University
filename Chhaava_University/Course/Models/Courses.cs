namespace Course.Models
{

    public class Courses
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int DepartmentId { get; set; }
    }
}
