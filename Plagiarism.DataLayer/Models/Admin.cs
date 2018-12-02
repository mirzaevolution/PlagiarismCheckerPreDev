namespace Plagiarism.DataLayer.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public virtual Role Role { get; set; }
    }
}
