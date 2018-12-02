using System.Collections.Generic;

namespace Plagiarism.DataLayer.Models
{
    public class StatusResult
    {
        public StatusResult() { }
        public StatusResult(bool success, List<string> errors)
        {
            this.Success = success;
            this.Errors = errors;
        }
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
    public class DataResult<T>
    {
        public DataResult() { }
        public DataResult(T data, StatusResult statusResult)
        {
            Data = data;
            Status = statusResult;
        }
        public T Data { get; set; }
        public StatusResult Status { get; set; } = new StatusResult();
    }
}
