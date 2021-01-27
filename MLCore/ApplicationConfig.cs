using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLCore
{
    public struct ApplicationConfig
    {
        [JsonProperty("executableApp")]
        public string executablePath;
        [JsonProperty("id")]
        public string id;
        [JsonProperty("local")]
        public bool local;
        [JsonProperty("thumbnailImagePath")]
        public string thumbnailImagePath;

        public ApplicationConfig(string id, string appPath, bool local, string thumbnailImagePath = null)
        {
            this.id = id;
            executablePath = appPath;
            this.local = local;
            this.thumbnailImagePath = thumbnailImagePath;
        }

        public override string ToString() => $"{JsonConvert.SerializeObject(this)}";
        public static ApplicationConfig Deserialize(string json) => JsonConvert.DeserializeObject<ApplicationConfig>(json);
    }
}
