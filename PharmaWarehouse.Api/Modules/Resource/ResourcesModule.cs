using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using PharmaWarehouse.Api.Modules.Resource.Entities;

namespace PharmaWarehouse.Api.Modules.Resource
{
    public class ResourcesModule
    {
        private static Resources resources;

        public static string GetValue(string key)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            List<ResourceKeyPair> resourceKeyPairs =
                ReadResources().ResourceKeyPairs.Where(x => x.Key == key).ToList();

            if (resourceKeyPairs.Count > 0)
            {
                return resourceKeyPairs.Select(x => cultureInfo.Name == "tr-TR" ? x.Tr : x.Eng).FirstOrDefault();
            }
            else
            {
                return "Resource not found...";
            }
        }

        public static CultureInfo GetCultureInfo()
        {
            return Thread.CurrentThread.CurrentCulture;
        }

        private static Resources ReadResources()
        {
            if (resources == null)
            {
                resources = JsonConvert.DeserializeObject<Resources>(File.ReadAllText(@"resources.json"));
            }

            return resources;
        }
    }
}
