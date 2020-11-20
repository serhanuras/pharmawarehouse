using Newtonsoft.Json;

namespace PharmaWarehouse.Api.Modules.Resource.Entities
{
    public class ResourceKeyPair
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("tr-TR")]
        public string Tr { get; set; }

        [JsonProperty("en-US")]
        public string Eng { get; set; }
    }
}
