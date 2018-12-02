using System.Collections.Generic;

namespace Plagiarism.DataLayer.Models
{
    public class Assignment
    {
        public Assignment()
        {
            Students = new List<Student>();
        }
        public int ID { get; set; }
        public string AssignmentName { get; set; }
        public virtual StudentClass Class { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
