using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLCore
{
    public class ApplicationManager
    {
        
        /*public static List<ApplicationConfig> getAllApplications()
        {
            List<ApplicationConfig> apps = new List<ApplicationConfig>();
            DirectoryInfo appDir = new DirectoryInfo(PathManager.getApplicationsDir());
            foreach (DirectoryInfo directories in appDir.GetDirectories())
            {
                string gameId = directories.Name;
                string path = directories.FullName;
                string configPath = $@"{path}\config.json";
                ApplicationConfig config;
                try
                {
                    if(new FileInfo(configPath).Exists)
                    {
                        using (StreamReader reader = new StreamReader(configPath))
                        {
                            config = ApplicationConfig.Deserialize(reader.ReadToEnd());
                            apps.Add(config);
                        }
                    }
                }
                catch(IOException e)
                {
                    Console.WriteLine("Error on loading app");
                    Console.WriteLine(e.Message);
                    MLBox.Show("Wystąpił błąd podczas wczytywania gry " + gameId, e.Message);
                }
            }
            return apps;
        }
        public static void editApplicatioData(ApplicationConfig config)
        {
            string appDirPath = PathManager.getApplicationDir(config.id);
            string configPath = $@"{appDirPath}\{PathManager.getConfigFileName()}";
            if (!new DirectoryInfo(appDirPath).Exists)
            {
                Directory.CreateDirectory(configPath);
            }
            if (!new FileInfo(configPath).Exists)
            {
                File.Create(configPath);
            }
            using (StreamWriter writer = new StreamWriter(configPath))
            {
                writer.Write(config.ToString());
                Console.WriteLine(config.ToString());
            }
        }
        public static void createApplicationData(ApplicationConfig config)
        {
            string appDirPath = PathManager.getApplicationDir(config.id);
            string configPath = $@"{appDirPath}\{PathManager.getConfigFileName()}";
            if(!new DirectoryInfo(appDirPath).Exists)
            {
                Directory.CreateDirectory(configPath);
            }
            if(!new FileInfo(configPath).Exists)
            {
                File.Create(configPath);
            }
            using (StreamWriter writer = new StreamWriter(configPath))
            {
                writer.Write(config.ToString());
                Console.WriteLine(config.ToString());
            }
        }*/

    }
}
