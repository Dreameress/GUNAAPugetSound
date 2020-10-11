using Newtonsoft.Json;

namespace Entities.DTOs
{
    public class BaseModel<T>
    {
        public BaseModel()
        {
            IsSuccess = true;
            Message = "";
        }
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }

        public string ReplaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
