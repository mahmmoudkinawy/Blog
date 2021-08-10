using Newtonsoft.Json;

namespace BlogAPI.Models.Exception
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
