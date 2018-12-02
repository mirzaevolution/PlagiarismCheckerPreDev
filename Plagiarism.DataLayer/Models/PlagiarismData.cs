using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagiarism.DataLayer.Models
{
    public class PlagiarismData
    {
        public int ID { get; set; }
        public string UploadedFilePath { get; set; }
        public int PercentageInteger { get; set; }
        public float Percentage { get; set; }
        public string Description { get; set; }
        public bool IsAccepted { get; set; }
        public string Data { get; set; }
        public virtual CoreData CoreData { get; set; }
    }
}
