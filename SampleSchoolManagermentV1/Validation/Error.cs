using Newtonsoft.Json;

namespace SampleSchoolManagermentV1.Validation
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()=>JsonConvert.SerializeObject(this);
        
    }
}
