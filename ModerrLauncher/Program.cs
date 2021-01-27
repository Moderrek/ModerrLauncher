using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        static void Main()
        {
            Console.WriteLine(PathManager.getLauncherDir().ToString());
            Console.WriteLine("App >> START");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("App >> Checking remember me");
            CheckToken();
            Console.WriteLine("App >> Loading login form");
            loginForm = new LoginForm();
            Application.Run(loginForm);
            Console.WriteLine("App >> After login");
            if (logged && token != "")
            {
                splashScreenThread = new Thread(new ThreadStart(StartSplashScreen));
                splashScreenThread.Start();
                Thread.Sleep(2500);
                Application.Run(new LauncherForm());
                Console.WriteLine("App >> END");
            }
            else
            {
                Console.WriteLine("Nie poprawnie się zalogowano");
            }
        }


        private static void CheckToken()
        {
            
        }


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

        public static async void LogInAsync(string login, string password, bool rememberMe)
        {
            Console.WriteLine("CheckLogin: ...");
            string temp_token;

            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "login", login },
                { "password", password },
                { "dc", Other.DiscordToken.GetToken() }
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
    }
}
