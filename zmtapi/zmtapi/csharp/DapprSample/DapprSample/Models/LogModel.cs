namespace DapprSample.Models
{
    public class LogModel
    {
        public string Level { get; set; }
        public string Message { get; set; }
        public string ResourceId { get; set; }
        public DateTime Timestamp { get; set; } 
        public string SpanId { get; set; }
        public string Commit { get; set; }
        public string Metadata { get; set; }
    }
}

