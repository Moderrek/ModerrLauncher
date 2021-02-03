using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLCore
{
    public struct GameListItem
    {
        [JsonProperty("id")]
        public string id;
        [JsonProperty("imageUrl")]
        public string imageUrl;
        [JsonProperty("version")]
        public string version;
        [JsonProperty("downloadDataUrl")]
        public string downloadDataUrl;
        [JsonProperty("show")]
        public bool show;

        [JsonConstructor]
        public GameListItem(string id, string imageUrl, string version, string downloadDataUrl, bool show)
        {
            this.id = id;
            this.imageUrl = imageUrl;
            this.version = version;
            this.downloadDataUrl = downloadDataUrl;
            this.show = show;
        }
    }
}
