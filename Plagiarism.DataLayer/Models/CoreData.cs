namespace Plagiarism.DataLayer.Models
{
    public class CoreData
    {
        public int ID { get; set; }
        public virtual Student Student { get; set; }
        public virtual StudentClass Class { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual PlagiarismData PlagiarismData { get; set; }
    }
}
