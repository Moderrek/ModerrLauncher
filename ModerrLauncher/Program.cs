using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLCore;

namespace ModerrLauncher
{
    static class Program
    {

        // Login Data
        public static bool logged = false;
        public static string token = "";
        // Login Form
        private static LoginForm loginForm = null;
        // SplashScreen
        public static SplashScreen splashScreen = null;
        public static Thread splashScreenThread = null;

        [STAThread]
        private static async Task MainAsync()
        {
            Console.WriteLine("App >> START");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MLBox.Show("Upewnij się", "Czy podczas pobierania masz uruchomiony launcher za pomocą administatora");
            Console.WriteLine("App >> Checking saved token");
            if (!await CheckTokenAsync().ConfigureAwait(false))
            {
                Console.WriteLine("App >> Loading login form");
                loginForm = new LoginForm();
                Application.Run(loginForm);
                Console.WriteLine("App >> After login");
            }
            if (logged && token != "")
            {
                /*try
                {
                    splashScreen = new SplashScreen();
                    splashScreen.Show();
                    Thread.Sleep(2500);
                    splashScreen.Dispose();
                }
                catch
                {
                    Console.WriteLine("Wystąpił bład podczas SplashScreen'a");
                    MLBox.Show("Splash Screen", "Wystąpił bład podczas próby wyświetlenia");
                }*/
                Application.Run(new LauncherForm());
                Console.WriteLine("App >> END");
            }
            else
            {
                Console.WriteLine("Logowanie się nie powiodło");
            }
        }

        [STAThread]
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        #region TOKEN
        private static string tempDir = $@"{Path.GetTempPath()}\ModerrLauncher\";
        private static string tokenPath = $@"{tempDir}\token.txt";

        private static void SaveToken(string token)
        {
            if(!new DirectoryInfo(tempDir).Exists)
            {
                Directory.CreateDirectory(tempDir);
            }
            using(StreamWriter writer = new StreamWriter(tokenPath))
            {
                writer.Write(token);
            }
        }
        private static void DeleteToken()
        {
            if(new FileInfo(tokenPath).Exists)
            {
                File.Delete(tokenPath);
            }
        }
        private static async Task<bool> CheckTokenAsync()
        {
            if(new FileInfo(tokenPath).Exists)
            {
                using(StreamReader reader = new StreamReader(tokenPath))
                {
                    return await LogInWithTokenAsync(await reader.ReadToEndAsync());
                }
            }
            return false;
        }
        #endregion

        #region SplashScreen
        public static void StopSplashScreen()
        {
            splashScreenThread.Abort();
            Console.WriteLine("SplashScreen >> END");
        }
        public static void StartSplashScreen()
        {
            Console.WriteLine("SplashScreen >> START");
            splashScreen = new SplashScreen();
            Application.Run(splashScreen);
        }
        #endregion

        #region SEARCH GAMES
        public static GameList searchGames;

        public static async Task<GameList> getSearchGamesList()
        {
            Console.WriteLine("GET >> Search Games");
            WebClient client = new WebClient();
            searchGames = GameList.FromJson(await client.DownloadStringTaskAsync("https://moderr.pl/ML/games.json"));
            return searchGames;
        }
        #endregion

        #region CONFIG
        private static IniFile configIni = new IniFile("Config.ini");
        public static void checkConfig()
        {

            Console.WriteLine("Checking config...");
            Console.WriteLine("Checking config values");
            if(!configIni.KeyExists("InstallDir", "Path"))
            {
                Console.WriteLine("Config value missing | InstallDir");
                string path = $@"{AppDomain.CurrentDomain.BaseDirectory}Applications";
                setInstallPath(path);
                if(new DirectoryInfo(path).Exists)
                {
                    Directory.CreateDirectory(path);
                }
                Console.WriteLine("Created new value InstallDir | " + path);
            }
        }
        public static void setInstallPath(string path)
        {
            configIni.Write("InstallDir", path, "Path");
        }
        public static string getInstallPath()
        {
            string path = configIni.Read("InstallDir", "Path");
            if (!new DirectoryInfo(path).Exists)
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        #endregion

        #region Account
        public static void Logout()
        {
            Console.WriteLine("Logout...");
            DeleteToken();
            Environment.Exit(0);
        }
        public static async Task<string> getName(string token)
        {
            Console.WriteLine("Get >> Username");
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "token", token }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://moderr.pl/ML/0.1/get_username.php", content);
            string responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Received: " + responseString);
            switch (responseString)
            {
                case "0":
                    Console.WriteLine("CheckLogin: Invalid | Wrong name or password");
                    MLBox.Show("Logowanie", "Podano nieprawidłowe dane logowania!");
                    break;
                case "not_registered":
                    Console.WriteLine("CheckLogin: Invalid | Not registered");
                    MLBox.Show("Logowanie", "Nie jesteś zarejestrowany!");
                    break;
                case "error":
                    Console.WriteLine("CheckLogin: Error | Unknown error");
                    MLBox.Show("Logowanie", "Wystąpił problem z naszej strony!");
                    break;
                case "error_db_connection":
                    Console.WriteLine("CheckLogin: Error | Database connection error");
                    MLBox.Show("Logowanie", "Wystąpił problem z naszej strony!");
                    break;
                default:
                    return responseString;
            }
            return null;
        }
        public static async Task<bool> LogInWithTokenAsync(string loginToken)
        {
            Console.WriteLine("Logging via token...");
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "token", loginToken }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://moderr.pl/ML/0.1/check_token.php", content);
            string received = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Received: " + received);
            switch (received)
            {
                case "true":
                    if (loginForm != null)
                    {
                        loginForm.Dispose();
                        loginForm = null;
                        Console.WriteLine("CheckLogin: Closing form...");
                    }
                    token = loginToken;
                    logged = true;
                    Console.WriteLine("Success logIn: " + token);
                    Console.WriteLine("CheckLogin: Valid!");
                    return true;
                case "false":
                    return false;
                default:
                    return false;
            }
        }
        public static async void LogInAsync(string login, string password, bool rememberMe)
        {
            Console.WriteLine("CheckLogin: ...");
            string temp_token;

            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "login", login },
                { "password", password },
                { "computername", Environment.MachineName },
                { "user", Environment.UserName }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://moderr.pl/ML/0.1/token.php", content);

            temp_token = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Received: " + temp_token);
            switch (temp_token)
            {
                case "0":
                    Console.WriteLine("CheckLogin: Invalid | Wrong name or password");
                    MLBox.Show("Logowanie", "Podano nieprawidłowe dane logowania!");
                    break;
                case "not_registered":
                    Console.WriteLine("CheckLogin: Invalid | Not registered");
                    MLBox.Show("Logowanie", "Nie jesteś zarejestrowany!");
                    break;
                case "error":
                    Console.WriteLine("CheckLogin: Error | Unknown error");
                    MLBox.Show("Logowanie", "Wystąpił problem z naszej strony!");
                    break;
                case "error_db_connection":
                    Console.WriteLine("CheckLogin: Error | Database connection error");
                    MLBox.Show("Logowanie", "Wystąpił problem z naszej strony!");
                    break;
                default:
                    if(loginForm != null)
                    {
                        loginForm.Dispose();
                        loginForm = null;
                        Console.WriteLine("CheckLogin: Closing form...");
                    }
                    if (temp_token.StartsWith("logged_"))
                    {
                        token = temp_token.Replace("logged_", "");
                        if (rememberMe)
                        {
                            SaveToken(token);
                        }
                        logged = true;
                        Console.WriteLine("Success logIn: " + token);
                        Console.WriteLine("CheckLogin: Valid!");
                    }
                    else
                    {
                        Console.WriteLine("CheckLogin: Error | MLC Script Error");
                        MLBox.Show("Logowanie", "Wystąpił problem z naszej strony!");
                    }
                    break;
            }
        }
        public static async void CreateAccount(string username, string mail, string password)
        {
            Console.WriteLine("TRY >> CreateAccount");
            string uuid = Guid.NewGuid().ToString();
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "name", username },
                { "mail", mail },
                { "password", password }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://moderr.pl/ML/0.1/create.php", content);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Console.WriteLine("SUCCESS >> CreateAccount");
        }
        public static async Task<bool> CheckExistsAsync(string name, string email)
        {
            Console.WriteLine("TRY >> CheckAccountExists");
            string exists;
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "name", name },
                { "mail", email }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://moderr.pl/ML/0.1/exists.php", content);

            exists = await response.Content.ReadAsStringAsync();
            Console.WriteLine(exists);
            Console.WriteLine("SUCCESS >> CheckAccountExists");
            switch (exists)
            {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    throw new Exception("Wystąpił problem podczas sprawdzania dostępności kont");
            }
        }
        #endregion
    }
}
