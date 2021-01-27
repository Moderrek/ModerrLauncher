using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerrLauncher.Langs
{
    public class LangFile
    {
        public Dictionary<string, string> langs = new Dictionary<string, string>();

        public string getLang(string key)
        {
            if (langs.ContainsKey(key))
            {
                return langs[key];
            }
            else
            {
                return "-";
            }
        }
    }
}
