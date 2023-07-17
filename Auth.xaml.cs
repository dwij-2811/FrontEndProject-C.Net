using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text.Json;
using System.Diagnostics;
using System.Net.Sockets;

namespace SoledoutUI
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void key_input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (key_input.Text == "Your License Here")
            {
                key_input.Text = "";
            }
        }

        private void key_input_LostFocus(object sender, RoutedEventArgs e)
        {
            if (key_input.Text == "")
            {
                key_input.Text = "Your License Here";
            }
        }

        public static String sha256_hash(string value)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public class resp
        {
            public string Success { get; set; }

            public string Error { get; set; }
            public string Discord_name { get; set; }
            public string Discord_image { get; set; }
        }

        public class key_
        {
            public string key { get; set; }
        }

        private key_ Newkey()
        {
            var setting = new key_
            {
                key = key_input.Text,
            };

            return setting;
        }

        private key_ No_key()
        {
            var setting = new key_
            {
                key = "",
            };

            return setting;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private readonly string key_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Key.json");
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (key_input.Text == null || key_input.Text == "")
                {
                    no_key.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    var key = key_input.Text;
                    
                    var macAddr = GetLocalIPAddress().ToString();
                        //(
                        //    from nic in NetworkInterface.GetAllNetworkInterfaces()
                        //    where nic.OperationalStatus == OperationalStatus.Up
                        //    select nic.GetPhysicalAddress().ToString()
                        //).FirstOrDefault();

                    checking.Visibility = Visibility.Visible;

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    var values = new Dictionary<string, string>
                    {
                        {"Reg", "CA" },
                        {"Key", key },
                        {"HWID", macAddr},
                    };


                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = JsonSerializer.Serialize(values);

                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var resps = JsonSerializer.Deserialize<resp>(result);
                        checking.Visibility = Visibility.Hidden;
                        if (resps.Success == "Ok")
                        {
                            var _key = Newkey();

                            string json = JsonSerializer.Serialize(_key);

                            File.WriteAllText(key_path, json);

                            string profile_file = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Profiles.json");
                            string proxy = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Proxies.json");
                            string settings = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Settings.json");
                            string task = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Task.json");
                            string checkout = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\checkout_data.json");

                            if (!File.Exists(profile_file))
                            {
                                using (StreamWriter sw = File.CreateText(profile_file))
                                {
                                    sw.WriteLine("[]");
                                }
                            }
                            if (!File.Exists(proxy))
                            {
                                using (StreamWriter sw = File.CreateText(proxy))
                                {
                                    sw.WriteLine("[]");
                                }
                            }
                            if (!File.Exists(settings))
                            {
                                using (StreamWriter sw = File.CreateText(settings))
                                {
                                    sw.WriteLine("{}");
                                }
                            }
                            if (!File.Exists(task))
                            {
                                using (StreamWriter sw = File.CreateText(task))
                                {
                                    sw.WriteLine("[]");
                                }
                            }
                            if (!File.Exists(checkout))
                            {
                                using (StreamWriter sw = File.CreateText(checkout))
                                {
                                    sw.WriteLine("[]");
                                }
                            }

                            check_updates_CLI();

                            if (updateavail == true)
                            {
                                if (MessageBox.Show("Looks like there is an update on CLI! Do you want to download it?", "SoledOut Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    Process.Start("AutoUpdater_CLI.exe");
                                    //this.Close();
                                }
                            }

                            check_updates_GUI();

                            if (updateavail_GUI == true)
                            {
                                if (MessageBox.Show("Looks like there is an update on GUI! Do you want to download it?", "SoledOut Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        if (File.Exists(@".\SoledOutGUI_Setup.msi"))
                                        {
                                            File.Delete(@".\SoledOutGUI_Setup.msi");
                                        }
                                        using (var client = new WebClient())
                                        {
                                            try
                                            {
                                                client.DownloadFile("", @".\SoledOutGUI_Setup.msi");
                                            }
                                            catch (Exception ex)
                                            {
                                                while (ex != null)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                    ex = ex.InnerException;
                                                }
                                            }
                                        }
                                            

                                        MessageBox.Show("Download Complete!");

                                        ExecuteCommand("msiexec /q /x {544FF65E-87D3-452C-9F99-1A838B61BE68}&msiexec /qb /i SoledOutGUI_Setup.msi&start " + @".\SoledoutUI.exe" + "&exit");

                                        //Process.Start(@".\SoledoutUI.exe");

                                        //var currentDirectory = Directory.GetCurrentDirectory();

                                        //string file = Directory.GetFiles(currentDirectory, "SoledOutGUI_Setup.msi").ToString();

                                        //MessageBox.Show(file);

                                        //File.SetAttributes(file, FileAttributes.Normal);
                                        //File.Delete(file);

                                        this.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            MainWindow mw = new MainWindow();
                            this.Close();
                            mw.Show();
                        }
                        else if (resps.Error == "Invalid User, You May Wana Reset Your Key!")
                        {
                            invalid_user.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            invalid.Text = resps.Error;
                            invalid.Visibility = Visibility.Visible;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + " Error Checking Key, Try Resetting Your Key", "Error");
            }
        }

        public class resps
        {
            public string CLI { get; set; }

            public string GUI { get; set; }
        }

        bool updateavail = false;
        private void check_updates_CLI()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var resps = JsonSerializer.Deserialize<resps>(result);

                var currentDirectory = Directory.GetCurrentDirectory();

                string file_string = null;

                foreach (var f in Directory.GetFiles(currentDirectory, "SoledOut_AIO_GUI*.exe"))
                {
                    file_string = f.ToString();
                    break;
                }

                string[] version_old_CLI = file_string.Split("SoledOut_AIO_GUI V")[1].Split(".ex")[0].Split('.');

                string[] version_new_CLI = resps.CLI.Split('.');

                if (int.Parse(version_new_CLI[0]) > int.Parse(version_old_CLI[0]))
                {
                    updateavail = true;
                    return;

                }
                else if (int.Parse(version_new_CLI[1]) > int.Parse(version_old_CLI[1]))
                {
                    updateavail = true;
                    return;
                }
                else if (int.Parse(version_new_CLI[2]) > int.Parse(version_old_CLI[2]))
                {
                    updateavail = true;
                    return;
                }
            }
        }

        bool updateavail_GUI = false;
        private void check_updates_GUI()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var resps = JsonSerializer.Deserialize<resps>(result);

                string[] version_old_GUI = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString().Split('.');

                string[] version_new_GUI = resps.GUI.Split('.');

                if ((int.Parse(version_new_GUI[0]) > int.Parse(version_old_GUI[0])))
                {
                    updateavail_GUI = true;
                    return;
                }
                else if (int.Parse(version_new_GUI[1]) > int.Parse(version_old_GUI[1]))
                {
                    updateavail_GUI = true;
                    return;
                }
                else if (int.Parse(version_new_GUI[2]) > int.Parse(version_old_GUI[2]))
                {
                    updateavail_GUI = true;
                    return;
                }
                else if (int.Parse(version_new_GUI[3]) > int.Parse(version_old_GUI[3]))
                {
                    updateavail_GUI = true;
                    return;
                }
            }
        }
        public void ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo;
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/k " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            Process cmd = Process.Start(ProcessInfo);
            cmd.WaitForExit();
        }
        private void Button_Initialized(object sender, EventArgs e)
        {
            try
            {
                string direcory = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO");
                bool folderExists = Directory.Exists(direcory);
                if (!folderExists)
                {
                    Directory.CreateDirectory(direcory);
                }
                string Key = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Key.json");
                if (!File.Exists(Key))
                {
                    using (StreamWriter sw = File.CreateText(Key))
                    {
                        sw.WriteLine("{}");
                    }
                }
                try
                {
                    string jsonString = File.ReadAllText(key_path);

                    var full_profile = JsonSerializer.Deserialize<key_>(jsonString);


                    if (full_profile.key != null && full_profile.key != "")
                    {
                        var key = full_profile.key;

                        var macAddr = GetLocalIPAddress().ToString();
                        //(
                        //        from nic in NetworkInterface.GetAllNetworkInterfaces()
                        //        where nic.OperationalStatus == OperationalStatus.Up
                        //        select nic.GetPhysicalAddress().ToString()
                        //    ).FirstOrDefault();

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create("");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";

                        var values = new Dictionary<string, string>
                    {
                        {"Reg", "CA" },
                        {"Key", key },
                        {"HWID", macAddr},
                    };


                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = JsonSerializer.Serialize(values);

                            streamWriter.Write(json);
                        }

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            var resps = JsonSerializer.Deserialize<resp>(result);
                            //checking.Visibility = Visibility.Hidden;
                            if (resps.Success == "Ok")
                            {
                                string profile_file = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Profiles.json");
                                string proxy = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Proxies.json");
                                string settings = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Settings.json");
                                string task = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Task.json");
                                string checkout = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\checkout_data.json");

                                if (!File.Exists(profile_file))
                                {
                                    using (StreamWriter sw = File.CreateText(profile_file))
                                    {
                                        sw.WriteLine("[]");
                                    }
                                }
                                if (!File.Exists(proxy))
                                {
                                    using (StreamWriter sw = File.CreateText(proxy))
                                    {
                                        sw.WriteLine("[]");
                                    }
                                }
                                if (!File.Exists(settings))
                                {
                                    using (StreamWriter sw = File.CreateText(settings))
                                    {
                                        sw.WriteLine("{}");
                                    }
                                }
                                if (!File.Exists(task))
                                {
                                    using (StreamWriter sw = File.CreateText(task))
                                    {
                                        sw.WriteLine("[]");
                                    }
                                }
                                if (!File.Exists(checkout))
                                {
                                    using (StreamWriter sw = File.CreateText(checkout))
                                    {
                                        sw.WriteLine("[]");
                                    }
                                }

                                check_updates_CLI();

                                if (updateavail == true)
                                {
                                    if (MessageBox.Show("Looks like there is an update on CLI! Do you want to download it?", "SoledOut Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        Process.Start("AutoUpdater_CLI.exe");
                                    }
                                }

                                check_updates_GUI();

                                if (updateavail_GUI == true)
                                {
                                    if (MessageBox.Show("Looks like there is an update on GUI! Do you want to download it?", "SoledOut Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        try
                                        {
                                            if (File.Exists(@".\SoledOutGUI_Setup.msi"))
                                            {
                                                File.Delete(@".\SoledOutGUI_Setup.msi");
                                            }
                                            using (var client = new WebClient())
                                            {
                                                try
                                                {
                                                    client.DownloadFile("", @".\SoledOutGUI_Setup.msi");
                                                }
                                                catch (Exception ex)
                                                {
                                                    while (ex != null)
                                                    {
                                                        MessageBox.Show(ex.Message);
                                                        ex = ex.InnerException;
                                                    }
                                                }
                                            }

                                            MessageBox.Show("Download Complete!");

                                            ExecuteCommand("msiexec /q /x {544FF65E-87D3-452C-9F99-1A838B61BE68}&msiexec /qb /i SoledOutGUI_Setup.msi&start " + @".\SoledoutUI.exe" + "&exit");

                                            //Process.Start(@".\SoledoutUI.exe");

                                            //var currentDirectory = Directory.GetCurrentDirectory();

                                            //string file = Directory.GetFiles(currentDirectory, "SoledOutGUI_Setup.msi").ToString();

                                            //MessageBox.Show(file);

                                            //File.SetAttributes(file, FileAttributes.Normal);
                                            //File.Delete(file);

                                            this.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                }

                                MainWindow mw = new MainWindow();
                                this.Close();
                                mw.Show();
                            }
                            else if (resps.Error == "Invalid User, You May Wana Reset Your Key!")
                            {
                                MessageBox.Show(resps.Error);

                                var _key = No_key();

                                string json = JsonSerializer.Serialize(_key);

                                File.WriteAllText(key_path, json);

                                invalid_user.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                MessageBox.Show(resps.Error);

                                var _key = No_key();

                                string json = JsonSerializer.Serialize(_key);

                                File.WriteAllText(key_path, json);

                                invalid.Text = resps.Error;
                                invalid.Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    var _key = No_key();

                    string json = JsonSerializer.Serialize(_key);

                    File.WriteAllText(key_path, json);

                }
            }catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void close_window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_window_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
