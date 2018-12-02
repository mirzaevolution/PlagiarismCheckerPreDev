using System.Collections.Generic;

namespace Plagiarism.DataLayer.Models
{
    public class Student
    {
        public Student()
        {
            Assignments = new List<Assignment>();
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public virtual Role Role { get; set; }
        public virtual StudentClass Class { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    
    }
}
