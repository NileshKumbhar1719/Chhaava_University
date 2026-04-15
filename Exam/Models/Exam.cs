namespace Exam.Models
{
    public class Exam
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int CourseId { get; set; }
    }
}
