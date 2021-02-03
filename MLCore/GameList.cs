using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLCore
{
    public class GameList
    {
        [JsonProperty("Games")]
        public List<GameListItem> games;

        [JsonConstructor]
        public GameList(List<GameListItem> games)
        {
            this.games = games;
        }


        public static GameList FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GameList>(json);
        }
        public static string ToJson(GameList gameList)
        {
            return JsonConvert.SerializeObject(gameList);
        }
    }
}
