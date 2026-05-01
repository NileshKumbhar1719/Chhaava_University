namespace Result.Models
{
    public class StudentResult   
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public string Grade { get; set; }

        public int StudentId { get; set; }
        public int ExamId { get; set; }
    }
}