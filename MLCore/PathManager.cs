using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLCore
{
    public class PathManager
    {
        public static string getMainDir()
        {
            return Environment.ExpandEnvironmentVariables(@"%APPDATA%\ModerrLauncher\");
        }

        public static string getLauncherDir()
        {
            return Environment.CurrentDirectory;
        }
        public static string getApplicationsDir()
        {
            return $@"{getLauncherDir()}\Applications";
        }
        public static string getApplicationDir(string game)
        {
            return $@"{getApplicationsDir()}\{game}";
        }

        public static string getConfigFileName()
        {
            return "config.json";
        }
    }
}
