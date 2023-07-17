using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace SoledoutUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void sku_GotFocus(object sender, RoutedEventArgs e)
        {
            if (create_sku.Text == "SKU")
            {
                create_sku.Text = "";
            }
        }

        private void sku_LostFocus(object sender, RoutedEventArgs e)
        {
            if (create_sku.Text == "")
            {
                create_sku.Text = "SKU";
            }
        }

        private void amount_GotFocus(object sender, RoutedEventArgs e)
        {
            if (create_amount.Text == "Amount")
            {
                create_amount.Text = "";
            }
        }

        private void amount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (create_amount.Text == "")
            {
                create_amount.Text = "Amount";
            }
        }

        private void amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        bool tasks_good = false;
        private void check_tasks_setup()
        {
            if (task_group.Text == "Task Group Name")
            {
                MessageBox.Show("Task Group Name Missing!", "Error");
                return;
            }
            else if (create_site.Text == "Site")
            {
                MessageBox.Show("Select A Site To Create Tasks!", "Error");
                return;
            } else if (create_sku.Text == "SKU")
            {
                MessageBox.Show("SKU Input Is Required!", "Error");
                return;
            }
            else if (create_amount.Text == "Amount") 
            {
                MessageBox.Show("Amount Is Required!", "Error");
                return;
            }
            else if (create_site.Text == "Ssense CA" && cart_quantity.Text == "Cart Quantity" || cart_quantity.Text == "0")
            {
                MessageBox.Show("Cart Quatity Is Required To Be More Than 0!", "Error");
                return;
            }
            else if (create_site.Text == "Ssense CA" && monitor_proxy.Text == "Monitor Proxy")
            {
                MessageBox.Show("Select A Monitor Proxy Group!", "Error");
                return;
            }
            else if (create_site.Text == "Ssense US" && cart_quantity.Text == "Cart Quantity" || cart_quantity.Text == "0")
            {
                MessageBox.Show("Cart Quatity Is Required To Be More Than 0!", "Error");
                return;
            }
            else if (create_main_mode.IsEnabled == true && create_main_mode.Text == "Main Mode")
            {
                MessageBox.Show("Main Mode Selection Is Required!", "Error");
                return;
            }
            else if (create_mode.IsEnabled == true && create_mode.Text == "Task Mode")
            {
                MessageBox.Show("Task Mode Selection Is Required!", "Error");
                return;
            } else if (create_proxy_group.Text == "Proxy Group")
            {
                MessageBox.Show("Proxy Group Selection Is Required!", "Error");
                return;
            }else if (create_sizes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Size Selection Is Required!", "Error");
                return;
            }
            else if (create_profiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Atlest 1 Profile Selection Is Required!", "Error");
                return;
            }
            tasks_good = true;
        }

        public class Proxies
        {
            public string name { get; set; }
            public string proxies { get; set; }
        }

        private readonly string proxies_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Proxies.json");
        private void create_proxy_group_Initialized(object sender, EventArgs e)
        {
            string jsonString2 = File.ReadAllText(proxies_path);

            using var doc = JsonDocument.Parse(jsonString2);
            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<Proxies>(user);
                
                create_proxy_group.Items.Add(full_profile.name);
            }
        }

        public class Profile
        {
            public string id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public bool? billingDifferent { get; set; }
            public card card { get; set; }
            public delivery delivery { get; set; }
            public billing billing { get; set; }
        }
        public class card
        {
            public string number { get; set; }
            public string expMonth { get; set; }
            public string expYear { get; set; }
            public string cvv { get; set; }
        }
        public class delivery
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string zip { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string state { get; set; }
        }
        public class billing
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string zip { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string state { get; set; }
        }

        private readonly string profile_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Profiles.json");
        private void create_profiles_Initialized(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText(profile_path);

            using var doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<Profile>(user);

                create_profiles.Items.Add(full_profile.name);
            }
        }

        public class Tasks
        {
            public string site { get; set; }
            public string size { get; set; }
            public string sku { get; set; }
            public string main_mode { get; set; }
            public string task_mode { get; set; }
            public string profiile_name { get; set; }
            public string proxy_group { get; set; }
            public int amount { get; set; }
            public string payment_method { get; set; }
            public int cart_q { get; set; }
            public string task_id { get; set; }
            public string schedular { get; set; }
            public string monitor_proxy_group { get; set; }
            public string task_name { get; set; }
        }

        public long DateTimeToUnix(DateTime MyDateTime)
        {
            TimeSpan timeSpan = MyDateTime - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds;
        }

        private Tasks NewTasks()
        {
            var rand = new Random();
            var schedule = "None";
            int amo = int.Parse(create_amount.Text);
            int cart_qa = 1;
            try
            {
                cart_qa = int.Parse(cart_quantity.Text);
            }
            catch
            {
            }
            
            List<string> selectedsize = new List<string>();
            List<string> selectedprofles = new List<string>();
            foreach (var item in create_sizes.SelectedItems)
            {
                TextBlock sp = item as TextBlock;
                selectedsize.Add(sp.Text);
            }
            foreach (var item in create_profiles.SelectedItems)
            {
                selectedprofles.Add(item.ToString());
            }
            if (task_schedular.IsChecked == true)
            {
                DateTime dateTimeOffSet = DateTime.Parse(date.Text+"-"+month.Text+"-"+ year.Text+" "+hour.Text+":"+min.Text+":"+sec.Text+" "+am_pm.Text);
                schedule = DateTimeToUnix(dateTimeOffSet).ToString();
            }
            
            var task = new Tasks
            {
                site = create_site.Text,
                size = string.Join(",", selectedsize),
                sku = create_sku.Text,
                main_mode = create_main_mode.Text,
                task_mode = create_mode.Text,
                profiile_name = string.Join(",", selectedprofles),
                proxy_group = create_proxy_group.Text,
                amount = amo,
                payment_method = payment_method.Text,
                cart_q = cart_qa,
                task_id = rand.Next(00000,99999).ToString(),
                schedular = schedule,
                task_name = task_group.Text,
                monitor_proxy_group = monitor_proxy.Text,
            };

            return task;
        }

        private void start_tasks_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:/Users/dwij0/OneDrive/Desktop/FTL BETA - Copy/Main_bot/UI/SoledoutUI/test.py";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;
            Process.Start(start);
        }

        string task_id;

        private readonly string task_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Task.json");
        private void task_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                check_tasks_setup();

                if (tasks_good == true)
                {
                    var proxy = NewTasks();

                    string jsonString = File.ReadAllText(task_path);

                    if (jsonString.ToString() == "[]")
                    {
                        List<Tasks> all_profiles = JsonSerializer.Deserialize<List<Tasks>>(jsonString);

                        all_profiles.Add(proxy);

                        string json = JsonSerializer.Serialize(all_profiles);

                        File.WriteAllText(task_path, json);
                    }
                    else
                    {
                        var all_profiles = JsonSerializer.Deserialize<List<Tasks>>(jsonString);

                        all_profiles.Add(proxy);

                        string json = JsonSerializer.Serialize(all_profiles);

                        File.WriteAllText(task_path, json);
                    }

                    MessageBox.Show("Tasks Created Successfully!", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void task_schedular_Checked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            date.IsEnabled = true;
            date.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            month.IsEnabled = true;
            month.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            year.IsEnabled = true;
            year.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            hour.IsEnabled = true;
            hour.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            min.IsEnabled = true;
            min.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            sec.IsEnabled = true;
            sec.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            am_pm.IsEnabled = true;
            am_pm.Foreground = (Brush)bc.ConvertFrom("#FF000000");
        }

        private void task_schedular_Unchecked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            date.IsEnabled = false;
            date.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            month.IsEnabled = false;
            month.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            year.IsEnabled = false;
            year.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            hour.IsEnabled = false;
            hour.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            min.IsEnabled = false;
            min.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            sec.IsEnabled = false;
            sec.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            am_pm.IsEnabled = false;
            am_pm.Foreground = (Brush)bc.ConvertFrom("#FF616161");
        }

        private void create_site_DropDownClosed(object sender, EventArgs e)
        {
            if (create_site.Text == "YeezySupply" || create_site.Text == "Ssense CA" || create_site.Text == "Ssense US")
            {
                monitor_proxy.Margin = new Thickness(40, 311, 0, 0);
                var bc = new BrushConverter();
                create_main_mode.IsEnabled = false;
                create_main_mode.Foreground = (Brush)bc.ConvertFrom("#FF616161");
                create_main_mode.Visibility = Visibility.Visible;
                cart_quantity.Visibility = Visibility.Hidden;
                create_mode.IsEnabled = false;
                create_mode.Foreground = (Brush)bc.ConvertFrom("#FF616161");
                create_mode.Visibility = Visibility.Visible;
                payment_method.Visibility = Visibility.Hidden;
            }
            else
            {
                monitor_proxy.Margin = new Thickness(40, 311, 0, 0);
                var bc = new BrushConverter();
                create_main_mode.IsEnabled = true;
                create_main_mode.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                create_main_mode.Visibility = Visibility.Visible;
                cart_quantity.Visibility = Visibility.Hidden;
                create_mode.Visibility = Visibility.Visible;
                payment_method.Visibility = Visibility.Hidden;
                monitor_proxy.Visibility = Visibility.Hidden;
                create_mode.IsEnabled = true;
                create_mode.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            }
            if (create_site.Text == "Ssense CA")
            {
                monitor_proxy.Margin = new Thickness(40, 311, 0, 0);
                cart_quantity.Visibility = Visibility.Visible;
                create_main_mode.Visibility = Visibility.Hidden;
                create_mode.Visibility = Visibility.Hidden;
                monitor_proxy.Visibility = Visibility.Visible;
                payment_method.Visibility = Visibility.Hidden;

            }
            if (create_site.Text == "Louis Vuitton US" || create_site.Text == "Louis Vuitton CA")
            {
                cart_quantity.Visibility = Visibility.Hidden;
                monitor_proxy.Visibility= Visibility.Visible;
                monitor_proxy.Margin = new Thickness(41, 258, 0, 0);
                create_main_mode.Visibility = Visibility.Hidden;
                payment_method.Visibility = Visibility.Visible;
                create_mode.Visibility = Visibility.Hidden;
                create_main_mode.IsEnabled = false;
                create_mode.IsEnabled = false;
            }
        }

        private void cart_quantity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cart_quantity.Text == "Cart Quantity")
            {
                cart_quantity.Text = "";
            }
        }

        private void cart_quantity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cart_quantity.Text == "")
            {
                cart_quantity.Text = "Cart Quantity";
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

        private void Window_Activated(object sender, EventArgs e)
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
                Window mainwindow = new MainWindow();
                Owner = mainwindow;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
                Window mainwindow = new MainWindow();
                Owner = mainwindow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void monitor_proxy_Initialized(object sender, EventArgs e)
        {
            string jsonString2 = File.ReadAllText(proxies_path);

            using var doc = JsonDocument.Parse(jsonString2);
            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<Proxies>(user);

                monitor_proxy.Items.Add(full_profile.name);
            }
        }

        private void task_group_GotFocus(object sender, RoutedEventArgs e)
        {
         if (task_group.Text == "Task Group Name")
            {
            task_group.Text = "";
            }
        }

        private void task_group_LostFocus(object sender, RoutedEventArgs e)
        {
         if (task_group.Text == "")
            {
            task_group.Text = "Task Group Name";
            }
        }

    }
}
