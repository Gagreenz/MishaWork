namespace MishaWork.Models
{
    public class UserSubject
    {
        public User user { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
