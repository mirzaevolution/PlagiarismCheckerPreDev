using System.Collections.Generic;

namespace Plagiarism.DataLayer.Models
{
    public class StudentClass
    {
        public StudentClass()
        {
            Students = new List<Student>();
            Assignments = new List<Assignment>();
        }
        public int ID { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        
    }
}
