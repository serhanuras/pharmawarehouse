using System.Collections.Generic;
using Newtonsoft.Json;

namespace PharmaWarehouse.Api.Modules.Resource.Entities
{
    public class Resources
    {
        [JsonProperty("resources")]
        public IEnumerable<ResourceKeyPair> ResourceKeyPairs { get; set; }
    }
}
