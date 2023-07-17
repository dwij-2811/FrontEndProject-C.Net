using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Text.Json;
using Discord;
using Discord.Webhook;
using System.Net;
using System.Diagnostics;
using LiveCharts;
using LiveCharts.Wpf;
using System.Net.Sockets;

namespace SoledoutUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class resp
        {
            public string Success { get; set; }

            public string Error { get; set; }
            public string Discord_name { get; set; }
            public string Discord_image { get; set; }
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

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                version.Content = "V" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();

                string jsonString = File.ReadAllText(key_path);

                var full_profile = JsonSerializer.Deserialize<key_>(jsonString);

                if (full_profile.key != null || full_profile.key != "")
                {
                    var key = full_profile.key;

                    var macAddr = GetLocalIPAddress().ToString();

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
                        if (resps.Success == "Ok")
                        {
                            discord_name.Text = resps.Discord_name;
                            BitmapImage logo = new BitmapImage();
                            logo.BeginInit();
                            logo.UriSource = new Uri(resps.Discord_image);
                            logo.EndInit();
                            discord_image.ImageSource = logo;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    string err = e.InnerException.Message;
                }
            }

            

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Fname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Fname.Text == "FirstName")
            {
                Fname.Text = "";
            }
        }

        private void Fname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Fname.Text == "")
            {
                Fname.Text = "FirstName";
            }
        }

        private void lname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lname.Text == "")
            {
                lname.Text = "LastName";
            }
        }

        private void lname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lname.Text == "LastName")
            {
                lname.Text = "";
            }
        }

        private void addy1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (addy1.Text == "Address Line 1")
            {
                addy1.Text = "";
            }
        }

        private void addy1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (addy1.Text == "")
            {
                addy1.Text = "Address Line 1";
            }
        }

        private void addy2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (addy2.Text == "Address Line 2")
            {
                addy2.Text = "";
            }
        }

        private void addy2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (addy2.Text == "")
            {
                addy2.Text = "Address Line 2";
            }
        }

        private void city_GotFocus(object sender, RoutedEventArgs e)
        {
            if (city.Text == "City")
            {
                city.Text = "";
            }
        }

        private void city_LostFocus(object sender, RoutedEventArgs e)
        {
            if (city.Text == "")
            {
                city.Text = "City";
            }
        }

        private void zip_GotFocus(object sender, RoutedEventArgs e)
        {
            if (zip.Text == "Zip")
            {
                zip.Text = "";
            }
        }

        private void zip_LostFocus(object sender, RoutedEventArgs e)
        {
            if (zip.Text == "")
            {
                zip.Text = "Zip";
            }
        }

        private void BFname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (BFname.Text == "")
            {
                BFname.Text = "FirstName";
            }
        }

        private void BFname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (BFname.Text == "FirstName")
            {
                BFname.Text = "";
            }
        }

        private void Blname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Blname.Text == "LastName")
            {
                Blname.Text = "";
            }
        }

        private void Blname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Blname.Text == "")
            {
                Blname.Text = "LastName";
            }
        }

        private void Baddy1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Baddy1.Text == "Address Line 1")
            {
                Baddy1.Text = "";
            }
        }

        private void Baddy1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Baddy1.Text == "")
            {
                Baddy1.Text = "Address Line 1";
            }
        }

        private void Baddy2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Baddy2.Text == "Address Line 2")
            {
                Baddy2.Text = "";
            }
        }

        private void Baddy2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Baddy2.Text == "")
            {
                Baddy2.Text = "Address Line 2";
            }
        }

        private void Bcity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Bcity.Text == "City")
            {
                Bcity.Text = "";
            }
        }

        private void Bcity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Bcity.Text == "")
            {
                Bcity.Text = "City";
            }
        }

        private void Bzip_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Bzip.Text == "Zip")
            {
                Bzip.Text = "";
            }
        }

        private void Bzip_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Bzip.Text == "")
            {
                Bzip.Text = "Zip";
            }
        }

        private void ccnum1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ccnum1.Text == "Card Number")
            {
                ccnum1.Text = "";
            }
        }

        private void ccnum1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ccnum1.Text == "")
            {
                ccnum1.Text = "Card Number";
            }
        }
        private void cvv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cvv.Text == "CVV")
            {
                cvv.Text = "";
            }
        }

        private void cvv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cvv.Text == "")
            {
                cvv.Text = "CVV";
            }
        }

        private void profile_name_text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (profile_name_text.Text == "Profile Name")
            {
                profile_name_text.Text = "";
            }
        }

        private void profile_name_text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (profile_name_text.Text == "")
            {
                profile_name_text.Text = "Profile Name";
            }
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "Email")
            {
                email.Text = "";
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "Email";
            }
        }

        private void phonenumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (phonenumber.Text == "Phone Number")
            {
                phonenumber.Text = "";
            }
        }
        private void phonenumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (phonenumber.Text == "")
            {
                phonenumber.Text = "Phone Number";
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void success_webhook_GotFocus(object sender, RoutedEventArgs e)
        {
            if (success_webhook.Text == "Success Webhook Here")
            {
                success_webhook.Text = "";
            }
        }

        private void success_webhook_LostFocus(object sender, RoutedEventArgs e)
        {
            if (success_webhook.Text == "")
            {
                success_webhook.Text = "Success Webhook Here";
            }
        }

        private void decline_webhook_GotFocus(object sender, RoutedEventArgs e)
        {
            if (decline_webhook.Text == "Decline Webhook Here")
            {
                decline_webhook.Text = "";
            }
        }

        private void decline_webhook_LostFocus(object sender, RoutedEventArgs e)
        {
            if (decline_webhook.Text == "")
            {
                decline_webhook.Text = "Decline Webhook Here";
            }
        }

        private void newtask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Effect = new System.Windows.Media.Effects.BlurEffect();
                Window1 win1 = new Window1();
                win1.Owner = this;
                win1.ShowDialog();
                Task_redo();
                this.Effect = null;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void edittasks_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Owner = this;

            var selected_tasks = tasks_box.SelectedItem;
            if (selected_tasks == null)
            {
                MessageBox.Show("Select Tasks To Edit!", "Error");
                return;
            }

            List<string> selectedtasks = new List<string>();
            foreach (object o in tasks_box.SelectedItems)
            {

                var profile_to_del = tasks_box.Items.IndexOf(o);

                selectedtasks.Add(profile_to_del.ToString());
            }
            this.Effect = new System.Windows.Media.Effects.BlurEffect();
            
            win2.ShowDialog(string.Join(',', selectedtasks));
            this.Effect = null;
            Task_redo();
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TabItem_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void samebillship_Checked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            billing_grid.IsEnabled = false;
            BCountry.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            BState_US.Foreground = (Brush)bc.ConvertFrom("#FF616161");
            BState_CA.Foreground = (Brush)bc.ConvertFrom("#FF616161");
        }

        private void samebillship_Unchecked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            billing_grid.IsEnabled = true;
            BCountry.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            BState_US.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            BState_CA.Foreground = (Brush)bc.ConvertFrom("#FF000000");
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

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
        private void Profile_load_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (profiel_box.SelectedItem == null || profiel_box.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("Please Select A Profile To Load", "Error");
            //        return;
            //    }
            //    string jsonString = File.ReadAllText(profile_path);

            //    using var doc = JsonDocument.Parse(jsonString);
            //    JsonElement root = doc.RootElement;

            //    var users = root.EnumerateArray();

            //    while (users.MoveNext())
            //    {
            //        var user = users.Current;

            //        var full_profile = JsonSerializer.Deserialize<Profile>(user);

            //        if (profiel_box.Text == full_profile.name)
            //        {
            //            profile_name_text.Text = full_profile.name;
            //            email.Text = full_profile.email;
            //            phonenumber.Text = full_profile.phone;
            //            Fname.Text = full_profile.delivery.firstName;
            //            lname.Text = full_profile.delivery.lastName;
            //            addy1.Text = full_profile.delivery.address1;
            //            addy2.Text = full_profile.delivery.address2;
            //            city.Text = full_profile.delivery.city;
            //            zip.Text = full_profile.delivery.zip;
            //            Country.Text = full_profile.delivery.country;
            //            if (full_profile.delivery.country == "United States")
            //            {
            //                State_US.Visibility = Visibility.Visible;
            //                State_CA.Visibility = Visibility.Hidden;
            //                State_US.Text = full_profile.delivery.state;
            //            }
            //            else
            //            {
            //                State_US.Visibility = Visibility.Hidden;
            //                State_CA.Visibility = Visibility.Visible;
            //                State_CA.Text = full_profile.delivery.state;
            //            }


            //            if (full_profile.billingDifferent == true)
            //            {
            //                samebillship.IsChecked = false;
            //                BFname.Text = full_profile.billing.firstName;
            //                Blname.Text = full_profile.billing.lastName;
            //                Baddy1.Text = full_profile.billing.address1;
            //                Baddy2.Text = full_profile.billing.address2;
            //                Bcity.Text = full_profile.billing.city;
            //                Bzip.Text = full_profile.billing.zip;
            //                BCountry.SelectedItem = full_profile.billing.country;
            //                if (full_profile.billing.country == "United States")
            //                {
            //                    BState_US.Visibility = Visibility.Visible;
            //                    BState_CA.Visibility = Visibility.Hidden;
            //                    BState_US.Text = full_profile.billing.state;
            //                }
            //                else
            //                {
            //                    BState_US.Visibility = Visibility.Hidden;
            //                    BState_CA.Visibility = Visibility.Visible;
            //                    BState_US.Text = full_profile.billing.state;
            //                }
            //            }
            //            else
            //            {
            //                samebillship.IsChecked = true;
            //            }
            //            ccnum1.Text = full_profile.card.number;
            //            ccmonth.Text = full_profile.card.expMonth;
            //            ccyear.Text = full_profile.card.expYear;
            //            cvv.Text = full_profile.card.cvv;
            //            MessageBox.Show("Profile Loaded Successfully!", "Success");
            //            return;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed To Load Profile!" + ex, "Error");
            //    return;
            //}


        }

        string state_s;
        string Bstate_s;
        string Bfname_s;
        string Blname_s;
        string Baddy1_s;
        string Baddy2_s;
        string Bzip_s;
        string Bcity_s;
        string Bcountry_s;
        bool samebill;
        private Profile NewProfile()
        {
            if (Country.Text == "United States")
            {
                state_s = State_US.Text;
                if (samebillship.IsChecked == false)
                {
                    Bstate_s = BState_US.Text;
                    Bfname_s = BFname.Text;
                    Blname_s = Blname.Text;
                    Baddy1_s = Baddy1.Text;
                    Baddy2_s = Baddy2.Text;
                    Bzip_s = Bzip.Text;
                    Bcity_s = Bcity.Text;
                    Bcountry_s = BCountry.Text;
                    samebill = true;
                }
                else
                {
                    samebill = false;
                }

            }
            else
            {
                state_s = State_CA.Text;
                if (samebillship.IsChecked == false)
                {
                    Bstate_s = BState_CA.Text;
                    Bfname_s = BFname.Text;
                    Blname_s = Blname.Text;
                    Baddy1_s = Baddy1.Text;
                    Baddy2_s = Baddy2.Text;
                    Bzip_s = Bzip.Text;
                    Bcity_s = Bcity.Text;
                    Bcountry_s = BCountry.Text;
                    samebill = true;
                }
                else
                {
                    samebill = false;
                }
            }

            var profile = new Profile
            {
                name = profile_name_text.Text,
                email = email.Text,
                phone = phonenumber.Text,
                billingDifferent = samebill,
                delivery = new delivery
                {
                    firstName = Fname.Text,
                    lastName = lname.Text,
                    address1 = addy1.Text,
                    address2 = addy2.Text,
                    zip = zip.Text,
                    city = city.Text,
                    country = Country.Text,
                    state = state_s,
                },
                billing = new billing
                {
                    firstName = Bfname_s,
                    lastName = Blname_s,
                    address1 = Baddy1_s,
                    address2 = Baddy2_s,
                    zip = Bzip_s,
                    city = Bcity_s,
                    country = Bcountry_s,
                    state = Bstate_s,
                },
                card = new card
                {
                    number = ccnum1.Text,
                    expMonth = ccmonth.Text,
                    expYear = ccyear.Text,
                    cvv = cvv.Text,
                },
            };

            return profile;
        }

        bool tasks_good = false;
        private void check_tasks_setup()
        {
            if (profile_name_text.Text == "Profile Name")
            {
                MessageBox.Show("Profile Name Is Required!", "Error");
                return;
            }
            else if (email.Text == "Email")
            {
                MessageBox.Show("Email Input Is Required!", "Error");
                return;
            }
            else if (phonenumber.Text == "Phone Number")
            {
                MessageBox.Show("Phone Number Is Required!", "Error");
                return;
            }
            else if (Fname.Text == "FirstName")
            {
                MessageBox.Show("First Name Is Required!", "Error");
                return;
            }
            else if (lname.Text == "LastName")
            {
                MessageBox.Show("Last Name Is Required!", "Error");
                return;
            }
            else if (addy1.Text == "Address Line 1")
            {
                MessageBox.Show("Address Line 1 Is Required!", "Error");
                return;
            }
            else if (city.Text == "City")
            {
                MessageBox.Show("City Is Required!", "Error");
                return;
            }
            else if (zip.Text == "Zip")
            {
                MessageBox.Show("Zip Is Required!", "Error");
                return;
            }
            else if (samebillship.IsChecked == false && BFname.Text == "FirstName")
            {
                MessageBox.Show("Billing First Name Is Required!", "Error");
                return;
            }
            else if (samebillship.IsChecked == false && Blname.Text == "LastName")
            {
                MessageBox.Show("Billing Last Name Is Required!", "Error");
                return;
            }
            else if (samebillship.IsChecked == false && Baddy1.Text == "Address Line 1")
            {
                MessageBox.Show("Billing Address Line 1 Is Required!", "Error");
                return;
            }
            else if (samebillship.IsChecked == false && Bcity.Text == "City")
            {
                MessageBox.Show("Billing City Is Required!", "Error");
                return;
            }
            else if (samebillship.IsChecked == false && Bzip.Text == "Zip")
            {
                MessageBox.Show("Billing Zip Is Required!", "Error");
                return;
            }
            else if (ccnum1.Text == "Card Number")
            {
                MessageBox.Show("Credit Card Number Is Required!", "Error");
                return;
            }
            else if (cvv.Text == "CVV")
            {
                MessageBox.Show("CVV Is Required!", "Error");
                return;
            }
            tasks_good = true;
        }
        private void Profile_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                check_tasks_setup();

                if (tasks_good == true)
                {
                    var customer = NewProfile();

                    string jsonString = File.ReadAllText(profile_path);

                    var all_profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString);

                    if (jsonString.Contains(customer.name))
                    {
                        foreach (var profile in all_profiles)
                        {
                            if (profile.name == customer.name)
                            {
                                all_profiles.Remove(profile);
                                break;
                            }
                        }
                    }
                    all_profiles.Add(customer);

                    string json = JsonSerializer.Serialize(all_profiles);

                    File.WriteAllText(profile_path, json);

                    //profiel_box.Items.Clear();

                    Window1 _window1 = new Window1();

                    _window1.create_profiles.Items.Clear();

                    string jsonString2 = File.ReadAllText(profile_path);

                    using var doc = JsonDocument.Parse(jsonString2);
                    JsonElement root = doc.RootElement;

                    var users = root.EnumerateArray();

                    while (users.MoveNext())
                    {
                        var user = users.Current;

                        var full_profile = JsonSerializer.Deserialize<Profile>(user);

                        //profiel_box.Items.Add(full_profile.name);

                        _window1.create_profiles.Items.Add(full_profile.name);
                    }

                    MessageBox.Show("Profile Saved Successfully!", "Success");
                }
            }
            catch
            {
                MessageBox.Show("Failed To Save Profile!", "Error");
            }

        }

        private void Profile_Delete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string jsonString = File.ReadAllText(profile_path);

            //    var all_profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString);

            //    var itemToRemove = all_profiles.Single(r => r.name == profiel_box.Text);

            //    all_profiles.Remove(itemToRemove);

            //    string json = JsonSerializer.Serialize(all_profiles);

            //    File.WriteAllText(profile_path, json);

            //    profiel_box.Items.Clear();

            //    Window1 _window1 = new Window1();

            //    _window1.create_profiles.Items.Clear();

            //    string jsonString2 = File.ReadAllText(profile_path);

            //    using var doc = JsonDocument.Parse(jsonString2);
            //    JsonElement root = doc.RootElement;

            //    var users = root.EnumerateArray();

            //    while (users.MoveNext())
            //    {
            //        var user = users.Current;

            //        var full_profile = JsonSerializer.Deserialize<Profile>(user);

            //        profiel_box.Items.Add(full_profile.name);

            //        _window1.create_profiles.Items.Add(full_profile.name);
            //    }

            //    MessageBox.Show("Profile Deleted Successfully!", "Success");
            //}
            //catch
            //{
            //    MessageBox.Show("Failed To Delete the Profile!", "Error");
            //}
        }

        public class CyberGroup
        {
            public string id { get; set; }
            public string name { get; set; }
            public List<Profile> profiles { get; set; }
        }
        private void Profile_Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "JSON File (.json)|*.json"; // Filter files by extension

                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string filename = dialog.FileName;

                    string jsonString = File.ReadAllText(profile_path);

                    var all_profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString);

                    string jsonString2 = File.ReadAllText(filename);

                    var new_profiles = JsonSerializer.Deserialize<List<CyberGroup>>(jsonString2);

                    for (int i = 0; i < new_profiles[0].profiles.Count; i++)
                    {
                        all_profiles.Add(new_profiles[0].profiles[i]);
                    }

                    string json = JsonSerializer.Serialize(all_profiles);

                    File.WriteAllText(profile_path, json);

                    //profiel_box.Items.Clear();

                    Window1 _window1 = new Window1();

                    _window1.create_profiles.Items.Clear();

                    string jsonString3 = File.ReadAllText(profile_path);

                    using var doc1 = JsonDocument.Parse(jsonString3);
                    JsonElement root2 = doc1.RootElement;

                    var users2 = root2.EnumerateArray();

                    while (users2.MoveNext())
                    {
                        var user1 = users2.Current;

                        var full_profile = JsonSerializer.Deserialize<Profile>(user1);

                        //profiel_box.Items.Add(full_profile.name);

                        _window1.create_profiles.Items.Add(full_profile.name);
                    }

                    profiel_box_Initialized();

                }
                else
                {
                    MessageBox.Show("Error Importing Profile!", "Error");
                    return;
                }

                MessageBox.Show("Profile(s) Imported Successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Importing Profile!" + ex, "Error");
            }

        }

        private void Profile_Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "JSON File (.json)|*.json"; // Filter files by extension

                // Show save file dialog box
                bool? result = dialog.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dialog.FileName;

                    string jsonString = File.ReadAllText(profile_path);

                    var all_profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString);

                    string json = JsonSerializer.Serialize(all_profiles);

                    File.WriteAllText(filename, json);

                    MessageBox.Show("Profile(s) Exported Successfully!", "Success");

                }
                else
                {
                    MessageBox.Show("Error Exporting Profile!", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Error Exporting Profile!", "Error");
            }

        }

        private void Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Country.Text == "United States")
            {
                State_US.Visibility = Visibility.Hidden;
                State_CA.Visibility = Visibility.Visible;
            }
            else
            {
                State_US.Visibility = Visibility.Visible;
                State_CA.Visibility = Visibility.Hidden;
            }
        }

        private void BCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BCountry.Text == "United States")
            {
                BState_US.Visibility = Visibility.Hidden;
                BState_CA.Visibility = Visibility.Visible;
            }
            else
            {
                BState_US.Visibility = Visibility.Visible;
                BState_CA.Visibility = Visibility.Hidden;
            }
        }

        private void profiel_box_Loaded(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText(profile_path);

            using var doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            while (users.MoveNext())
            {
                var user = users.Current;


                var full_profile = JsonSerializer.Deserialize<Profile>(user);

                //profiel_box.Items.Add(full_profile.name);
            }
        }

        public class Proxies
        {
            public string name { get; set; }
            public string proxies { get; set; }
        }

        private Proxies NewProxies()
        {
            string str_proxies = proxies.Text.Replace(" ", "").Replace("\r\n", ",");
            var proxie = new Proxies
            {
                name = proxy_group_name.Text,
                proxies = str_proxies,
            };

            return proxie;
        }

        private readonly string proxies_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Proxies.json");
        private void save_proxy_Click(object sender, RoutedEventArgs e)
        {
            if (proxy_group_name.Text == "New Group")
            {
                MessageBox.Show("Missing Proxy Group Name!", "Error");
                return;
            }
            else if (proxies.Text == null || proxies.Text == "")
            {
                MessageBox.Show("Missing Proxies!", "Error");
                return;
            }
            try
            {
                var proxy = NewProxies();

                string jsonString = File.ReadAllText(proxies_path);

                var all_profiles = JsonSerializer.Deserialize<List<Proxies>>(jsonString);

                if (jsonString.Contains(proxy.name))
                {
                    foreach (var profile in all_profiles)
                    {
                        if (profile.name == proxy.name)
                        {
                            all_profiles.Remove(profile);
                            break;
                        }
                    }
                }

                all_profiles.Add(proxy);

                string json = JsonSerializer.Serialize(all_profiles);

                File.WriteAllText(proxies_path, json);

                proxy_box.Items.Clear();

                string jsonString2 = File.ReadAllText(proxies_path);

                using var doc = JsonDocument.Parse(jsonString2);
                JsonElement root = doc.RootElement;

                var users = root.EnumerateArray();

                while (users.MoveNext())
                {
                    var user = users.Current;

                    var full_profile = JsonSerializer.Deserialize<Proxies>(user);

                    proxy_box.Items.Add(full_profile.name);
                }

                MessageBox.Show("Proxies Saved Successfully!", "Success");
            }
            catch
            {
                MessageBox.Show("Failed To Save Proxies!", "Error");
            }
        }

        private void delete_proxy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jsonString = File.ReadAllText(proxies_path);

                var all_profiles = JsonSerializer.Deserialize<List<Proxies>>(jsonString);

                var itemToRemove = all_profiles.Single(r => r.name == proxy_box.Text);

                all_profiles.Remove(itemToRemove);

                string json = JsonSerializer.Serialize(all_profiles);

                File.WriteAllText(proxies_path, json);

                proxy_box.Items.Clear();

                proxy_group_name.Text = "New Group";

                proxies.Text = "";

                string jsonString2 = File.ReadAllText(proxies_path);

                using var doc = JsonDocument.Parse(jsonString2);

                JsonElement root = doc.RootElement;

                var users = root.EnumerateArray();

                while (users.MoveNext())
                {
                    var user = users.Current;

                    var full_profile = JsonSerializer.Deserialize<Proxies>(user);

                    proxy_box.Items.Add(full_profile.name);
                }

                MessageBox.Show("Proxy Group Deleted Successfully!", "Success");
            }
            catch
            {
                MessageBox.Show("Failed To Delete the Proxy Group!", "Error");
            }
        }

        private void load_proxy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (proxy_box.SelectedItem == null || proxy_box.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select A Proxy Group To Load", "Error");
                    return;
                }
                string jsonString = File.ReadAllText(proxies_path);

                using var doc = JsonDocument.Parse(jsonString);

                JsonElement root = doc.RootElement;

                var users = root.EnumerateArray();

                while (users.MoveNext())
                {
                    var user = users.Current;

                    var full_profile = JsonSerializer.Deserialize<Proxies>(user);

                    if (proxy_box.Text == full_profile.name)
                    {
                        proxy_group_name.Text = full_profile.name;
                        string str_proxies = full_profile.proxies.Replace(",", "\r\n");
                        proxies.Text = str_proxies;
                        MessageBox.Show("Proxy Group Loaded", "Success");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed To Load Proxy Group", "Error");
            }
        }

        private void proxy_group_name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (proxy_group_name.Text == "New Group")
            {
                proxy_group_name.Text = "";
            }
        }

        private void proxy_group_name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (proxy_group_name.Text == "")
            {
                proxy_group_name.Text = "New Group";
            }
        }

        private void proxy_box_Initialized(object sender, EventArgs e)
        {
            string jsonString2 = File.ReadAllText(proxies_path);

            using var doc = JsonDocument.Parse(jsonString2);
            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<Proxies>(user);

                proxy_box.Items.Add(full_profile.name);
            }
        }

        public class Settings
        {
            public string success_webhook { get; set; }
            public string decline_webhook { get; set; }
            public int error_delay { get; set; }
            public int monitor_delay { get; set; }
            public string primary_solvers { get; set; }
            public string primary_solver_key { get; set; }
            public string domains { get; set; }
            public string text_cap_solvers { get; set; }
            public string text_cap_solver_key { get; set; }

        }

        private Settings NewSettings()
        {
            var setting = new Settings
            {
                success_webhook = success_webhook.Text,
                decline_webhook = decline_webhook.Text,
                error_delay = int.Parse(error_delay.Text),
                monitor_delay = int.Parse(monitor_delay.Text),
                primary_solvers = _3rdparty_solver.Text,
                primary_solver_key = cap_key.Text,
                text_cap_solvers = text_cap_solver.Text,
                text_cap_solver_key = cap_key_text.Text,
                domains = domains_box.Text.Replace(" ", "").Replace("\r\n", ",")
            };

            return setting;
        }

        private readonly string settings_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Settings.json");
        private void settings_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var settings = NewSettings();

                string json = JsonSerializer.Serialize(settings);

                File.WriteAllText(settings_path, json);

                MessageBox.Show("Settings Saved", "Success");
            }
            catch
            {
                MessageBox.Show("Failed To Save Settings", "Error");
            }
        }

        private void settings_export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "JSON File (.json)|*.json"; // Filter files by extension

                // Show save file dialog box
                bool? result = dialog.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dialog.FileName;

                    string jsonString = File.ReadAllText(settings_path);

                    var all_profiles = JsonSerializer.Deserialize<Settings>(jsonString);

                    string json = JsonSerializer.Serialize(all_profiles);

                    File.WriteAllText(filename, json);

                    MessageBox.Show("Settings Exported Successfully!", "Success");

                }
                else
                {
                    MessageBox.Show("Error Exporting Settings!", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Error Exporting Settings!", "Error");
            }
        }

        private void settings_import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "JSON File (.json)|*.json"; // Filter files by extension

                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string filename = dialog.FileName;

                    string jsonString2 = File.ReadAllText(filename);

                    File.WriteAllText(profile_path, jsonString2);

                    var full_profile = JsonSerializer.Deserialize<Settings>(jsonString2);

                    success_webhook.Text = full_profile.success_webhook;
                    decline_webhook.Text = full_profile.decline_webhook;
                    error_delay.Text = full_profile.error_delay.ToString();
                    monitor_delay.Text = full_profile.monitor_delay.ToString();
                    _3rdparty_solver.Text = full_profile.primary_solvers;
                    cap_key.Text = full_profile.primary_solver_key;
                    text_cap_solver.Text = full_profile.text_cap_solvers;
                    cap_key_text.Text = full_profile.text_cap_solver_key;
                    domains_box.Text = full_profile.domains;
                }
                else
                {
                    MessageBox.Show("Error Importing Settings!", "Error");
                    return;
                }

                MessageBox.Show("Settings Imported Successfully!", "Success");
            }
            catch
            {
                MessageBox.Show("Error Importing Settings!", "Error");
            }
        }

        private void settings_webhook_test_Click(object sender, RoutedEventArgs e)
        {
            if (success_webhook.Text == "")
            {
                MessageBox.Show("No Success Webhook Found!", "Error");
                return;
            }
            else if (decline_webhook.Text == "")
            {
                MessageBox.Show("No Decline Webhook Found!", "Error");
                return;
            }
            else
            {
                try
                {
                    DiscordMessage message = new DiscordMessage();
                    message.Username = "SoledOut";
                    message.AvatarUrl = "https://live.staticflickr.com/65535/51249460236_3b1a97d786_o_d.png";

                    DiscordWebhook hook = new DiscordWebhook();
                    hook.Url = success_webhook.Text;
                    DiscordEmbed embed = new DiscordEmbed();
                    embed.Title = "Success Test";
                    embed.Description = "Test Success";
                    embed.Timestamp = DateTime.Now;
                    embed.Color = System.Drawing.Color.Green;
                    message.Embeds = new List<DiscordEmbed>();
                    message.Embeds.Add(embed);
                    hook.Send(message);

                    DiscordMessage message2 = new DiscordMessage();

                    message2.Username = "SoledOut";
                    message2.AvatarUrl = "https://live.staticflickr.com/65535/51249460236_3b1a97d786_o_d.png";

                    DiscordWebhook hook1 = new DiscordWebhook();
                    hook1.Url = decline_webhook.Text;
                    DiscordEmbed embed2 = new DiscordEmbed();
                    embed2.Title = "Decline Test";
                    embed2.Description = "Test Success";
                    embed2.Timestamp = DateTime.Now;
                    embed2.Color = System.Drawing.Color.Red;
                    message2.Embeds = new List<DiscordEmbed>();
                    message2.Embeds.Add(embed2);
                    hook1.Send(message2);

                    MessageBox.Show("Webhook Test Success!", "Successs");
                }
                catch
                {
                    MessageBox.Show("Webhook Test Failed!", "Error");
                }
            }



        }

        public class key_resp
        {
            public bool? success { get; set; }

        }

        public class key_
        {
            public string key { get; set; }

        }

        private key_ No_key()
        {
            var setting = new key_
            {
                key = "",
            };

            return setting;
        }

        private readonly string key_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Key.json");
        private void settings_deactivate_key_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jsonString = File.ReadAllText(key_path);

                var full_profile = JsonSerializer.Deserialize<key_>(jsonString);

                string _key = full_profile.key;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("" + _key + "/reset");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + "");
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonSerializer.Serialize(new { });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var response = JsonSerializer.Deserialize<key_resp>(result);
                    if (response.success == true)
                    {
                        MessageBox.Show("Key Reset Successfully", "Success");
                        string Key = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Key.json");
                        if (!File.Exists(Key))
                        {
                            using (StreamWriter sw = File.CreateText(Key))
                            {
                                sw.WriteLine("{}");
                            }
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error Reseting Key" + result, "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Reseting Key" + ex, "Error");
            }

        }

        private void Setting_Grid_Initialized()
        {
            string jsonString = File.ReadAllText(settings_path);

            var full_profile = JsonSerializer.Deserialize<Settings>(jsonString);

            if (full_profile.success_webhook != null)
            {
                success_webhook.Text = full_profile.success_webhook;
                decline_webhook.Text = full_profile.decline_webhook;
                error_delay.Text = full_profile.error_delay.ToString();
                monitor_delay.Text = full_profile.monitor_delay.ToString();
                _3rdparty_solver.Text = full_profile.primary_solvers;
                cap_key.Text = full_profile.primary_solver_key;
                domains_box.Text = full_profile.domains.Replace(",", "\r\n");
                text_cap_solver.Text = full_profile.text_cap_solvers;
                cap_key_text.Text = full_profile.text_cap_solver_key;

            }

        }
        public class checkout_details
        {
            public string name { get; set; }
            public string site { get; set; }
            public string size { get; set; }
            public float total { get; set; }
            public string sku { get; set; }
            public bool? success { get; set; }
            public Int32 time_stamp { get; set; }

        }

        private readonly string checkout_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\checkout_data.json");

        private void start_tasks_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:/Users/dwij0/OneDrive/Desktop/FTL BETA - Copy/Main_bot/UI/SoledoutUI/test.py";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;
            Process process = Process.Start(start);
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
            public string task_id { get; set; }
            public string schedular { get; set; }
            public string monitor_proxy_group { get; set; }
            public string task_name { get; set; }
        }

        private readonly string task_path = Environment.ExpandEnvironmentVariables("%AppData%\\SoledOutAIO\\Task.json");
        private void tasks_box_Initialized(object sender, EventArgs e)
        {
            //string jsonString = File.ReadAllText(task_path);

            //using var doc = JsonDocument.Parse(jsonString);

            //JsonElement root = doc.RootElement;

            //var users = root.EnumerateArray();


            //while (users.MoveNext())
            //{
            //    var user = users.Current;

            //    var proxy = JsonSerializer.Deserialize<Tasks>(user);

            //    if (proxy.task_id != null)
            //    {
            //        StackPanel stackPanel = new StackPanel
            //        {
            //            Orientation = Orientation.Horizontal,
            //        };
            //        TextBlock textBlock6 = new TextBlock();
            //        {
            //            textBlock6.Text = proxy.task_id;
            //            textBlock6.TextWrapping = TextWrapping.Wrap;
            //            textBlock6.TextAlignment = TextAlignment.Center;
            //            textBlock6.Width = 60;
            //        }
            //        TextBlock textBlock = new TextBlock();
            //        {
            //            textBlock.Text = proxy.site;
            //            textBlock.TextWrapping = TextWrapping.Wrap;
            //            textBlock.TextAlignment = TextAlignment.Center;
            //            textBlock.Width = 227;
            //        }
            //        TextBlock textBlock1 = new TextBlock();
            //        {
            //            textBlock1.Text = proxy.sku;
            //            textBlock1.TextWrapping = TextWrapping.Wrap;
            //            textBlock1.TextAlignment = TextAlignment.Center;
            //            textBlock1.Width = 227;
            //        }
            //        TextBlock textBlock2 = new TextBlock();
            //        {
            //            textBlock2.Text = proxy.main_mode;
            //            textBlock2.TextWrapping = TextWrapping.Wrap;
            //            textBlock2.TextAlignment = TextAlignment.Center;
            //            textBlock2.Width = 227;
            //        }
            //        TextBlock textBlock3 = new TextBlock();
            //        {
            //            textBlock3.Text = proxy.task_mode;
            //            textBlock3.TextWrapping = TextWrapping.Wrap;
            //            textBlock3.TextAlignment = TextAlignment.Center;
            //            textBlock3.Width = 227;
            //        }
            //        TextBlock textBlock4 = new TextBlock();
            //        {
            //            textBlock4.Text = proxy.proxy_group;
            //            textBlock4.TextWrapping = TextWrapping.Wrap;
            //            textBlock4.TextAlignment = TextAlignment.Center;
            //            textBlock4.Width = 227;
            //        }
            //        TextBlock textBlock5 = new TextBlock();
            //        {
            //            textBlock5.Text = proxy.amount.ToString();
            //            textBlock5.TextWrapping = TextWrapping.Wrap;
            //            textBlock5.TextAlignment = TextAlignment.Center;
            //            textBlock5.Width = 227;
            //        }

            //        stackPanel.Children.Add(textBlock6);
            //        stackPanel.Children.Add(textBlock);
            //        stackPanel.Children.Add(textBlock1);
            //        stackPanel.Children.Add(textBlock2);
            //        stackPanel.Children.Add(textBlock3);
            //        stackPanel.Children.Add(textBlock4);
            //        stackPanel.Children.Add(textBlock5);

            //        tasks_box.Items.Add(stackPanel);
            //    }
            //}
        }

        private void redo_tasks()
        {
            tasks_box.Items.Clear();

            string jsonString = File.ReadAllText(task_path);

            using var doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            int i = 0;

            while (users.MoveNext())
            {
                i++;
                var user = users.Current;

                var proxy = JsonSerializer.Deserialize<Tasks>(user);

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Margin = new Thickness(-4);

                TextBlock textBlock = new TextBlock();
                textBlock.Width = 104;
                textBlock.Margin = new Thickness(5, 0, 0, 0);
                textBlock.Foreground = Brushes.White;
                textBlock.FontSize = 16;
                textBlock.IsEnabled = false;
                textBlock.Text = proxy.task_id;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.TextAlignment = TextAlignment.Left;
                textBlock.Padding = new Thickness(5, 0, 0, 0);
                textBlock.MinWidth = 104;
                textBlock.MaxWidth = 104;

                TextBlock textBlock1 = new TextBlock();
                textBlock1.Width = 160;
                textBlock1.Margin = new Thickness(5, 0, 0, 0);
                textBlock1.Foreground = Brushes.White;
                textBlock1.FontSize = 16;
                textBlock1.IsEnabled = false;
                textBlock1.Text = proxy.site;
                textBlock1.VerticalAlignment = VerticalAlignment.Center;
                textBlock1.TextWrapping = TextWrapping.Wrap;
                textBlock1.TextAlignment = TextAlignment.Left;
                textBlock1.MinWidth = 160;
                textBlock1.MaxWidth = 160;

                TextBlock textBlock2 = new TextBlock();
                textBlock2.Width = 181;
                textBlock2.Margin = new Thickness(3, 0, 0, 0);
                textBlock2.Foreground = Brushes.White;
                textBlock2.FontSize = 16;
                textBlock2.IsEnabled = false;
                if (proxy.size == "RANDOM")
                {
                    textBlock2.Text = proxy.size;
                }
                else
                {
                    textBlock2.Text = "Multiple Sizes";
                }
                textBlock2.VerticalAlignment = VerticalAlignment.Center;
                textBlock2.TextWrapping = TextWrapping.Wrap;
                textBlock2.TextAlignment = TextAlignment.Left;
                textBlock2.MinWidth = 181;
                textBlock2.MaxWidth = 181;

                TextBlock textBlock3 = new TextBlock();
                textBlock3.Width = 200;
                textBlock3.Margin = new Thickness(5, 0, 0, 0);
                textBlock3.Foreground = Brushes.White;
                textBlock3.FontSize = 16;
                textBlock3.IsEnabled = false;
                textBlock3.Text = proxy.sku;
                textBlock3.VerticalAlignment = VerticalAlignment.Center;
                textBlock3.TextWrapping = TextWrapping.Wrap;
                textBlock3.TextAlignment = TextAlignment.Left;
                textBlock3.MinWidth = 200;
                textBlock3.MaxWidth = 200;

                TextBlock textBlock4 = new TextBlock();
                textBlock4.Width = 200;
                textBlock4.Margin = new Thickness(5, 0, 0, 0);
                textBlock4.Foreground = Brushes.White;
                textBlock4.FontSize = 16;
                textBlock4.IsEnabled = false;
                textBlock4.Text = proxy.profiile_name.Split(',').Length.ToString()+ " Profiles Selected";
                textBlock4.VerticalAlignment = VerticalAlignment.Center;
                textBlock4.TextWrapping = TextWrapping.Wrap;
                textBlock4.TextAlignment = TextAlignment.Left;
                textBlock4.MinWidth = 200;
                textBlock4.MaxWidth = 200;

                TextBlock textBlock5 = new TextBlock();
                textBlock5.Width = 177;
                textBlock5.Margin = new Thickness(5, 0, 0, 0);
                textBlock5.Foreground = Brushes.White;
                textBlock5.FontSize = 16;
                textBlock5.IsEnabled = false;
                textBlock5.Text = proxy.proxy_group;
                textBlock5.VerticalAlignment = VerticalAlignment.Center;
                textBlock5.TextWrapping = TextWrapping.Wrap;
                textBlock5.TextAlignment = TextAlignment.Left;
                textBlock5.MinWidth = 177;
                textBlock5.MaxWidth = 177;

                TextBlock textBlock6 = new TextBlock();
                textBlock6.Width = 132;
                textBlock6.Margin = new Thickness(5, 0, 0, 0);
                textBlock6.Foreground = Brushes.White;
                textBlock6.FontSize = 16;
                textBlock6.IsEnabled = false;
                textBlock6.Text = proxy.amount.ToString();
                textBlock6.VerticalAlignment = VerticalAlignment.Center;
                textBlock6.TextWrapping = TextWrapping.Wrap;
                textBlock6.TextAlignment = TextAlignment.Left;
                textBlock6.MinWidth = 132;
                textBlock6.MaxWidth = 132;

                TextBlock textBlock7 = new TextBlock();
                textBlock7.Width = 68;
                textBlock7.Margin = new Thickness(5, 0, 0, 0);
                textBlock7.Foreground = Brushes.White;
                textBlock7.FontSize = 16;
                textBlock7.IsEnabled = false;
                if (proxy.schedular != "None")
                {
                    textBlock7.Text = "True";
                }
                else
                {
                    textBlock7.Text = "False";
                }
                textBlock7.VerticalAlignment = VerticalAlignment.Center;
                textBlock7.TextWrapping = TextWrapping.Wrap;
                textBlock7.TextAlignment = TextAlignment.Left;
                textBlock7.MinWidth = 68;
                textBlock7.MaxWidth = 68;

                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(textBlock1);
                stackPanel.Children.Add(textBlock2);
                stackPanel.Children.Add(textBlock3);
                stackPanel.Children.Add(textBlock4);
                stackPanel.Children.Add(textBlock5);
                stackPanel.Children.Add(textBlock6);
                stackPanel.Children.Add(textBlock7);

                LinearGradientBrush border_color = new LinearGradientBrush();
                border_color.StartPoint = new Point(0.5, 0);
                border_color.EndPoint = new Point(0.5, 1);

                GradientStop stop2 = new GradientStop();
                stop2.Color = (Color)ColorConverter.ConvertFromString("#FF4B1930");
                stop2.Offset = 1;
                border_color.GradientStops.Add(stop2);

                GradientStop stop1 = new GradientStop();
                stop1.Color = (Color)ColorConverter.ConvertFromString("#FF641E3A");
                stop1.Offset = 0;
                border_color.GradientStops.Add(stop1);

                Border profile_border = new Border();
                profile_border.Width = 1271;
                profile_border.Height = 38;
                profile_border.CornerRadius = new CornerRadius(12, 12, 12, 12);
                profile_border.Padding = new Thickness(4);
                profile_border.Effect = new System.Windows.Media.Effects.DropShadowEffect();
                profile_border.Child = stackPanel;
                profile_border.Background = border_color;

                tasks_box.Items.Add(profile_border);
            }
        }



        private void open_cli_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();

            var currentDirectory = Directory.GetCurrentDirectory();

            string file_string = null;

            foreach (var f in Directory.GetFiles(currentDirectory, "SoledOut_AIO_GUI*.exe"))
            {
                file_string = f.ToString();
                break;
            }
            start.FileName = file_string;
            start.UseShellExecute = true;// Do not use OS shell
            start.CreateNoWindow = false; // We don't need new window
            start.RedirectStandardOutput = false;// Any output, generated by application will be redirected back
            start.RedirectStandardError = false; // Any error in standard output will be redirected back (for example exceptions)
            Process process = Process.Start(start);
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var selected_tasks = tasks_box.SelectedItem;
            if (selected_tasks == null)
            {
                MessageBox.Show("Select Tasks To Delete!", "Error");
                return;
            }
            List<string> selectedtasks = new List<string>();
            foreach (var item in tasks_box.SelectedItems)
            {
                StackPanel sp = item as StackPanel;

                string taskId = ((sp.Children[0] as TextBlock).Text);

                selectedtasks.Add(taskId);
            }

            string jsonString = File.ReadAllText(task_path);

            var all_profiles = JsonSerializer.Deserialize<List<Tasks>>(jsonString);

            foreach (var taskId in string.Join(',', selectedtasks).Split(','))
            {
                foreach (var profile in all_profiles)
                {
                    var proxy = profile;

                    if (proxy.task_id == taskId)
                    {
                        all_profiles.Remove(proxy);
                        break;
                    }
                }
            }
            string json = JsonSerializer.Serialize(all_profiles);

            File.WriteAllText(task_path, json);

            Task_redo();

            MessageBox.Show("Task Deleted Successfully!", "Success");
        }

        private void export_tasks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "JSON File (.json)|*.json"; // Filter files by extension

                // Show save file dialog box
                bool? result = dialog.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dialog.FileName;

                    string jsonString = File.ReadAllText(task_path);

                    var all_profiles = JsonSerializer.Deserialize<List<Tasks>>(jsonString);

                    string json = JsonSerializer.Serialize(all_profiles);

                    File.WriteAllText(filename, json);

                    MessageBox.Show("Task(s) Exported Successfully!", "Success");

                }
                else
                {
                    MessageBox.Show("Error Exporting Tasks!", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Error Exporting Tasks!", "Error");
            }
        }

        private void import_tasks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "JSON File (.json)|*.json"; // Filter files by extension

                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string filename = dialog.FileName;

                    string jsonString = File.ReadAllText(task_path);

                    var all_profiles = JsonSerializer.Deserialize<List<Tasks>>(jsonString);

                    string jsonString2 = File.ReadAllText(filename);

                    using var doc = JsonDocument.Parse(jsonString2);
                    JsonElement root = doc.RootElement;

                    var users = root.EnumerateArray();

                    while (users.MoveNext())
                    {
                        var user = users.Current;

                        var full_profile = JsonSerializer.Deserialize<Tasks>(user);

                        all_profiles.Add(full_profile);
                    }

                    string json = JsonSerializer.Serialize(all_profiles);

                    File.WriteAllText(task_path, json);

                }
                else
                {
                    MessageBox.Show("Error Importing Tasks!", "Error");
                    return;
                }

                MessageBox.Show("Task(s) Imported Successfully!", "Success");

                Task_redo();
            }
            catch
            {
                MessageBox.Show("Error Importing Tasks!", "Error");
            }
        }

        private void proxies_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void today_checkout_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(checkout_path);

            var doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            int checkouts_today = 0;

            int declines_today = 0;

            float spents_today = 0;

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<checkout_details>(user);

                if (full_profile.success == true)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 86400)
                    {
                        checkouts_today++;
                        spents_today += full_profile.total;
                    }
                }
                else
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 86400)
                    {
                        declines_today++;
                    }
                }

                checkout_today.Text = checkouts_today.ToString();
                checkout_today_label.Content = "Checkouts Today";
                decline_today.Text = declines_today.ToString();
                decline_today_label.Content = "Declines Today";
                spent_today.Text = "$" + spents_today.ToString();
                spent_today_label.Content = "Spent Today";
            }
        }

        private void yesterday_checkout_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(checkout_path);

            var doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            int checkouts_today = 0;

            int declines_today = 0;

            float spents_today = 0;

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<checkout_details>(user);

                if (full_profile.success == true)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 172800)
                    {
                        checkouts_today++;
                        spents_today += full_profile.total;
                    }
                }
                else
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 172800)
                    {
                        declines_today++;
                    }
                }

                checkout_today.Text = checkouts_today.ToString();
                checkout_today_label.Content = "Checkouts Since Yesterday";
                decline_today.Text = declines_today.ToString();
                decline_today_label.Content = "Declines Since Yesterday";
                spent_today.Text = "$" + spents_today.ToString();
                spent_today_label.Content = "Spent Since Yesterday";
            }
        }

        private void week_checkout_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(checkout_path);

            var doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            int checkouts_today = 0;

            int declines_today = 0;

            float spents_today = 0;

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<checkout_details>(user);

                if (full_profile.success == true)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 604800)
                    {
                        checkouts_today++;
                        spents_today += full_profile.total;
                    }
                }
                else
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 604800)
                    {
                        declines_today++;
                    }
                }

                checkout_today.Text = checkouts_today.ToString();
                checkout_today_label.Content = "Checkouts This Week";
                decline_today.Text = declines_today.ToString();
                decline_today_label.Content = "Declines This Week";
                spent_today.Text = "$" + spents_today.ToString();
                spent_today_label.Content = "Spent This Week";
            }
        }

        private void month_checkout_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(checkout_path);

            var doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            int checkouts_today = 0;

            int declines_today = 0;

            float spents_today = 0;

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<checkout_details>(user);

                if (full_profile.success == true)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 2592000)
                    {
                        checkouts_today++;
                        spents_today += full_profile.total;
                    }
                }
                else
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 2592000)
                    {
                        declines_today++;
                    }
                }

                checkout_today.Text = checkouts_today.ToString();
                checkout_today_label.Content = "Checkouts This Month";
                decline_today.Text = declines_today.ToString();
                decline_today_label.Content = "Declines This Month";
                spent_today.Text = "$" + spents_today.ToString();
                spent_today_label.Content = "Spent This Month";
            }
        }

        private void year_checkout_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(checkout_path);

            var doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;

            var users = root.EnumerateArray();

            int checkouts_today = 0;

            int declines_today = 0;

            float spents_today = 0;

            while (users.MoveNext())
            {
                var user = users.Current;

                var full_profile = JsonSerializer.Deserialize<checkout_details>(user);

                if (full_profile.success == true)
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 31536000)
                    {
                        checkouts_today++;
                        spents_today += full_profile.total;
                    }
                }
                else
                {
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile.time_stamp < 31536000)
                    {
                        declines_today++;
                    }
                }

                checkout_today.Text = checkouts_today.ToString();
                checkout_today_label.Content = "Checkouts Till Year";
                decline_today.Text = declines_today.ToString();
                decline_today_label.Content = "Declines Till Year";
                spent_today.Text = "$" + spents_today.ToString();
                spent_today_label.Content = "Spent Till Year";
            }
        }

        private void dashboard_button_Click(object sender, RoutedEventArgs e)
        {
            Task_grid.Visibility = Visibility.Hidden;
            Proxies_grid.Visibility = Visibility.Hidden;
            Profile_grid.Visibility = Visibility.Hidden;
            Settings_grid.Visibility = Visibility.Hidden;
            Dash_grid.Visibility = Visibility.Visible;
        }

        private void tasks_button_Click(object sender, RoutedEventArgs e)
        {
            Task_grid.Visibility = Visibility.Visible;
            Proxies_grid.Visibility = Visibility.Hidden;
            Profile_grid.Visibility = Visibility.Hidden;
            Settings_grid.Visibility = Visibility.Hidden;
            Dash_grid.Visibility = Visibility.Hidden;
        }

        private void profiles_button_Click(object sender, RoutedEventArgs e)
        {
            Task_grid.Visibility = Visibility.Hidden;
            Proxies_grid.Visibility = Visibility.Hidden;
            Profile_grid.Visibility = Visibility.Visible;
            Settings_grid.Visibility = Visibility.Hidden;
            Dash_grid.Visibility = Visibility.Hidden;
        }

        private void peoxies_button_Click(object sender, RoutedEventArgs e)
        {
            Task_grid.Visibility = Visibility.Hidden;
            Proxies_grid.Visibility = Visibility.Visible;
            Profile_grid.Visibility = Visibility.Hidden;
            Settings_grid.Visibility = Visibility.Hidden;
            Dash_grid.Visibility = Visibility.Hidden;
        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {
            Task_grid.Visibility = Visibility.Hidden;
            Proxies_grid.Visibility = Visibility.Hidden;
            Profile_grid.Visibility = Visibility.Hidden;
            Settings_grid.Visibility = Visibility.Visible;
            Dash_grid.Visibility = Visibility.Hidden;
        }

        private void BCountry_DropDownClosed(object sender, EventArgs e)
        {
        if (BCountry.Text == "United States")
        {
            BState_US.Visibility = Visibility.Visible;
            BState_CA.Visibility = Visibility.Hidden;
        }
        else
        {
            BState_US.Visibility = Visibility.Hidden;
            BState_CA.Visibility = Visibility.Visible;
        }
    }

        private void Profile_grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Task_grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Dash_grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Settings_grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Proxies_grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close_window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_window_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void cap_key_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cap_key.Text == "Key Here")
            {
                cap_key.Text = "";
            }
        }

        private void cap_key_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cap_key.Text == "")
            {
                cap_key.Text = "Key Here";
            }
        }

        private void cap_key_text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cap_key_text.Text == "Key Here")
            {
                cap_key_text.Text = "";
            }
        }

        private void cap_key_text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cap_key_text.Text == "")
            {
                cap_key_text.Text = "Key Here";
            }
        }

        private void _3rdparty_solver_DropDownClosed(object sender, EventArgs e)
        {
            if (_3rdparty_solver.Text != "")
            {
                cap_key.IsEnabled = true;
            }
            else
            {
                cap_key.IsEnabled = false;
            }
            
        }

        private void proxy_box_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (proxy_box.SelectedItem == null || proxy_box.SelectedIndex == -1)
                {
                    return;
                }
                string jsonString = File.ReadAllText(proxies_path);

                using var doc = JsonDocument.Parse(jsonString);

                JsonElement root = doc.RootElement;

                var users = root.EnumerateArray();

                while (users.MoveNext())
                {
                    var user = users.Current;

                    var full_profile = JsonSerializer.Deserialize<Proxies>(user);

                    if (proxy_box.Text == full_profile.name)
                    {
                        proxy_group_name.Text = full_profile.name;
                        string str_proxies = full_profile.proxies.Replace(",", "\r\n");
                        proxies.Text = str_proxies;
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed To Load Proxy Group", "Error");
            }
        }

        private void profiel_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (profiel_box.SelectedItem == null)
                {
                    return;
                }

                string jsonString = File.ReadAllText(profile_path);

                using var doc = JsonDocument.Parse(jsonString);
                JsonElement root = doc.RootElement;

                var full_profile = JsonSerializer.Deserialize<List<Profile>>(doc);

                profile_name_text.Text = full_profile[profiel_box.SelectedIndex].name;

                email.Text = full_profile[profiel_box.SelectedIndex].email;
                phonenumber.Text = full_profile[profiel_box.SelectedIndex].phone;
                Fname.Text = full_profile[profiel_box.SelectedIndex].delivery.firstName;
                lname.Text = full_profile[profiel_box.SelectedIndex].delivery.lastName;
                addy1.Text = full_profile[profiel_box.SelectedIndex].delivery.address1;
                addy2.Text = full_profile[profiel_box.SelectedIndex].delivery.address2;
                city.Text = full_profile[profiel_box.SelectedIndex].delivery.city;
                zip.Text = full_profile[profiel_box.SelectedIndex].delivery.zip;
                Country.Text = full_profile[profiel_box.SelectedIndex].delivery.country;
                if (full_profile[profiel_box.SelectedIndex].delivery.country == "United States")
                {
                    State_US.Visibility = Visibility.Visible;
                    State_CA.Visibility = Visibility.Hidden;
                    State_US.Text = full_profile[profiel_box.SelectedIndex].delivery.state;
                }
                else
                {
                    State_US.Visibility = Visibility.Hidden;
                    State_CA.Visibility = Visibility.Visible;
                    State_CA.Text = full_profile[profiel_box.SelectedIndex].delivery.state;
                }


                if (full_profile[profiel_box.SelectedIndex].billingDifferent == true)
                {
                    samebillship.IsChecked = false;
                    BFname.Text = full_profile[profiel_box.SelectedIndex].billing.firstName;
                    Blname.Text = full_profile[profiel_box.SelectedIndex].billing.lastName;
                    Baddy1.Text = full_profile[profiel_box.SelectedIndex].billing.address1;
                    Baddy2.Text = full_profile[profiel_box.SelectedIndex].billing.address2;
                    Bcity.Text = full_profile[profiel_box.SelectedIndex].billing.city;
                    Bzip.Text = full_profile[profiel_box.SelectedIndex].billing.zip;
                    BCountry.SelectedItem = full_profile[profiel_box.SelectedIndex].billing.country;
                    if (full_profile[profiel_box.SelectedIndex].billing.country == "United States")
                    {
                        BState_US.Visibility = Visibility.Visible;
                        BState_CA.Visibility = Visibility.Hidden;
                        BState_US.Text = full_profile[profiel_box.SelectedIndex].billing.state;
                    }
                    else
                    {
                        BState_US.Visibility = Visibility.Hidden;
                        BState_CA.Visibility = Visibility.Visible;
                        BState_US.Text = full_profile[profiel_box.SelectedIndex].billing.state;
                    }
                }
                else
                {
                    samebillship.IsChecked = true;
                }
                ccnum1.Text = full_profile[profiel_box.SelectedIndex].card.number;
                ccmonth.Text = full_profile[profiel_box.SelectedIndex].card.expMonth;
                ccyear.Text = full_profile[profiel_box.SelectedIndex].card.expYear;
                cvv.Text = full_profile[profiel_box.SelectedIndex].card.cvv;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Load Profile!" + ex, "Error");
                return;
            }
        }

        public class CMyData

        {

            public string ProfileName { get; set; }
            public string ProfileCC { get; set; }
            public string ProfileEmail { get; set; }

        }

        private void profiel_box_Initialized()
        {
            List<CMyData> arrayCity = new List<CMyData>();

            string jsonString = File.ReadAllText(profile_path);

            using var doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            var full_profile = JsonSerializer.Deserialize<List<Profile>>(doc);

            for (int i = 0; i < full_profile.Count; i++)
            {
                arrayCity.Add(new CMyData() { ProfileName = full_profile[i].name, ProfileCC = full_profile[i].card.number.ToString().Substring(full_profile[i].card.number.ToString().Length - 4), ProfileEmail = full_profile[i].email });

                //StackPanel main_stack = new StackPanel();
                //main_stack.Orientation = Orientation.Vertical;
                //main_stack.Margin = new Thickness(-4, -4, -4, -4);


                //Image image = new Image();
                //image.Height = 29;
                //image.Width = 27;
                //BitmapImage logo = new BitmapImage();
                //logo.BeginInit();
                //logo.UriSource = new Uri("pack://application:,,,/delete.png");
                //logo.EndInit();
                //image.Source = logo;

                //StackPanel image_stack = new StackPanel();
                //image_stack.Orientation = Orientation.Horizontal;
                //image_stack.Children.Add(image);

                //Button del_button = new Button();
                //del_button.Height = 44;
                //del_button.Width = 41;
                //del_button.Background = Brushes.Transparent;
                //del_button.BorderBrush = Brushes.Transparent;
                //del_button.Content = image_stack;
                //del_button.Click += new RoutedEventHandler(profile_delete_Click_1);

                //StackPanel second_stack_button = new StackPanel();
                //second_stack_button.Orientation = Orientation.Horizontal;
                //second_stack_button.Height = 42;
                //second_stack_button.HorizontalAlignment = HorizontalAlignment.Right;
                //second_stack_button.Children.Add(del_button);

                //Label pro_name = new Label();
                //pro_name.HorizontalContentAlignment = HorizontalAlignment.Center;
                //pro_name.VerticalContentAlignment = VerticalAlignment.Center;
                //pro_name.Content = full_profile[i].name; // add profile name
                //pro_name.FontSize = 18;
                //pro_name.Height = 77;
                //pro_name.Foreground = Brushes.White;

                //Image cc_image = new Image();
                //cc_image.Height = 17;
                //cc_image.Width = 18;
                //BitmapImage cc_logo = new BitmapImage();
                //cc_logo.BeginInit();
                //cc_logo.UriSource = new Uri("pack://application:,,,/credit-card.png");
                //cc_logo.EndInit();
                //cc_image.Source = cc_logo;

                //TextBlock cc_text = new TextBlock();
                //cc_text.Text = full_profile[i].card.number.ToString().Substring(full_profile[i].card.number.ToString().Length - 4); ;
                //cc_text.Margin = new Thickness(5, 0, 0, 0);
                //cc_text.Foreground = Brushes.White;

                //StackPanel cc_stack = new StackPanel();
                //cc_stack.Orientation = Orientation.Horizontal;
                //cc_stack.Children.Add(cc_image);
                //cc_stack.Children.Add(cc_text);

                //Label cc_tex = new Label();
                //cc_tex.HorizontalContentAlignment = HorizontalAlignment.Center;
                //cc_tex.VerticalContentAlignment = VerticalAlignment.Center;
                //cc_tex.Content = cc_stack;

                //Image email_image = new Image();
                //email_image.Height = 17;
                //email_image.Width = 18;
                //BitmapImage email_logo = new BitmapImage();
                //email_logo.BeginInit();
                //email_logo.UriSource = new Uri("pack://application:,,,/email.png");
                //email_logo.EndInit();
                //email_image.Source = email_logo;

                //TextBlock email_text = new TextBlock();
                //email_text.Text = full_profile[i].email;
                //email_text.Margin = new Thickness(5, 0, 0, 0);
                //email_text.Foreground = Brushes.White;

                //StackPanel email_stack = new StackPanel();
                //email_stack.Orientation = Orientation.Horizontal;
                //email_stack.Children.Add(email_image);
                //email_stack.Children.Add(email_text);

                //Label email_tex = new Label();
                //email_tex.HorizontalContentAlignment = HorizontalAlignment.Center;
                //email_tex.VerticalContentAlignment = VerticalAlignment.Center;
                //email_tex.Content = email_stack;

                //main_stack.Children.Add(second_stack_button);
                //main_stack.Children.Add(pro_name);
                //main_stack.Children.Add(cc_tex);
                //main_stack.Children.Add(email_tex);

                //LinearGradientBrush border_color = new LinearGradientBrush();
                //border_color.StartPoint = new Point(0.5, 0);
                //border_color.EndPoint = new Point(0.5, 1);

                //GradientStop stop1 = new GradientStop();
                //stop1.Color = (Color)ColorConverter.ConvertFromString("#FFA5305B");
                //stop1.Offset = 0.4;
                //border_color.GradientStops.Add(stop1);

                //GradientStop stop2 = new GradientStop();
                //stop2.Color = (Color)ColorConverter.ConvertFromString("#994B1930");
                //stop2.Offset = 1;
                //border_color.GradientStops.Add(stop2);

                //Border profile_border = new Border();
                //profile_border.CornerRadius = new CornerRadius(12, 12, 12, 12);
                //profile_border.Padding = new Thickness(4);
                //profile_border.Width = 204;
                //profile_border.Height = 185;
                //profile_border.Effect = new System.Windows.Media.Effects.DropShadowEffect();
                //profile_border.Child = main_stack;
                //profile_border.Background = border_color;

                //profiel_box.Items.Add(profile_border);
                
            }
            profiel_box.ItemsSource = arrayCity;
        }

        private void Dash_setup()
        {
            string jsonString = File.ReadAllText(checkout_path);

            using var doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            var full_profile = JsonSerializer.Deserialize<List<checkout_details>>(doc);

            int total_checkouts = 0;

            int total_declines = 0;

            float total_spents = 0;

            int checkouts_today = 0;

            int declines_today = 0;

            float spents_today = 0;

            int ys_1 = 0;

            int ys_2 = 0;

            int ys_3 = 0;

            int ys_4 = 0;

            int ss_1 = 0;

            int ss_2 = 0;

            int ss_3 = 0;

            int ss_4 = 0;

            int ft_1 = 0;

            int ft_2 = 0;

            int ft_3 = 0;

            int ft_4 = 0;

            for (int i = full_profile.Count - 1; i >= 0; i--)
            {
                List<string> Valid_Months = new List<string>();

                Dictionary<int, string> Months = Enumerable.Range(1, 12).Select(i => new KeyValuePair<int, string>(i, System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i))).ToDictionary(x => x.Key, x => x.Value);

                var current_month = int.Parse(DateTime.Now.ToString("MM"));

                if (full_profile[i].success == true)
                {
                    total_checkouts++;
                    total_spents += full_profile[i].total;
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile[i].time_stamp < 86400)
                    {
                        checkouts_today++;
                        spents_today += full_profile[i].total;
                    }

                    StackPanel main_stack = new StackPanel();
                    main_stack.Orientation = Orientation.Horizontal;
                    main_stack.Width = 782;
                    main_stack.Height = 69;
                    main_stack.IsEnabled = false;


                    Image image = new Image();
                    image.Height = 68;
                    image.Width = 84;
                    image.Margin = new Thickness(3, 0, 0, 0);
                    //image.Stretch = Stretch.Fill;
                    //image.StretchDirection = StretchDirection.Both;
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(full_profile[i].sku);
                    logo.EndInit();
                    image.Source = logo;

                    StackPanel second_stack = new StackPanel();
                    second_stack.VerticalAlignment = VerticalAlignment.Top;
                    second_stack.Width = 408;
                    second_stack.Height = 69;
                    second_stack.MaxWidth = 408;
                    second_stack.MinWidth = 408;
                    second_stack.Margin = new Thickness(5, 0, 0, 0);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = full_profile[i].name;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    textBlock.IsEnabled = false;
                    textBlock.FontSize = 16;
                    textBlock.Foreground = Brushes.White;
                    textBlock.TextAlignment = TextAlignment.Left;
                    textBlock.Margin = new Thickness(5, 0, 0, 0);
                    textBlock.Width = 394;

                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    DateTime dateTime1 = dateTime.AddSeconds(full_profile[i].time_stamp).ToLocalTime();

                    TextBlock textblock4 = new TextBlock();
                    //datetime datetime = new datetime(1970, 1, 1, 0, 0, 0, 0, datetimekind.utc);
                    //datetime datetime1 = datetime.addseconds(full_profile[i].time_stamp).tolocaltime();
                    textblock4.Text = dateTime1.ToString();
                    textblock4.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock4.FontSize = 16;
                    textblock4.Foreground = Brushes.Gray;
                    textblock4.Margin = new Thickness(3, 0, 0, 0);
                    textblock4.Width = 394;
                    textblock4.TextAlignment = TextAlignment.Left;
                    textblock4.Opacity = 0.5;
                    textblock4.Height = 24;

                    second_stack.Children.Add(textblock4);
                    second_stack.Children.Add(textBlock);

                    string site_text3 = "N/A";

                    if (full_profile[i].site == "Foots")
                    {
                        site_text3 = "FootSites";
                    }
                    else if (full_profile[i].site == "Ssense")
                    {
                        site_text3 = "Ssense";
                    }
                    else if (full_profile[i].site == "YS")
                    {
                        site_text3 = "Yeezy Supply";
                    }
                    TextBlock textBlock3 = new TextBlock();
                    textBlock3.Text = site_text3;
                    textBlock3.VerticalAlignment = VerticalAlignment.Center;
                    textBlock3.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock3.FontSize = 16;
                    textBlock3.Foreground = Brushes.White;
                    textBlock3.Margin = new Thickness(5, 0, 0, 0);
                    textBlock3.Width = 96;
                    textBlock3.TextAlignment = TextAlignment.Center;
                    textBlock3.MaxWidth = 96;
                    textBlock3.MinWidth = 96;

                    TextBlock textBlock2 = new TextBlock();
                    textBlock2.Text = "$" + full_profile[i].total.ToString();
                    textBlock2.VerticalAlignment = VerticalAlignment.Center;
                    textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock2.FontSize = 16;
                    textBlock2.Foreground = Brushes.White;
                    textBlock2.Margin = new Thickness(5, 0, 0, 0);
                    textBlock2.Width = 83;
                    textBlock2.MaxWidth = 83;
                    textBlock2.MinWidth = 83;
                    textBlock2.TextAlignment = TextAlignment.Left;

                    TextBlock textBlock1 = new TextBlock();
                    textBlock1.Text = "Size " + full_profile[i].size;
                    textBlock1.VerticalAlignment = VerticalAlignment.Center;
                    textBlock1.FontSize = 16;
                    textBlock1.Foreground = Brushes.White;
                    textBlock1.Margin = new Thickness(3, 0, 0, 0);
                    textBlock1.TextAlignment = TextAlignment.Center;


                    if (full_profile[i].site == "Foots")
                    {
                        if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month)
                        {
                            ft_1 += 1;
                        }else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 1)
                        {
                            ft_2 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 2)
                        {
                            ft_3 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 3)
                        {
                            ft_4 += 1;
                        }
                    }else if (full_profile[i].site == "Ssense")
                    {
                        if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month)
                        {
                            ss_1 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 1)
                        {
                            ss_2 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 2)
                        {
                            ss_3 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 3)
                        {
                            ss_4 += 1;
                        }
                    }
                    else if (full_profile[i].site == "YS")
                    {
                        if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month)
                        {
                            ys_1 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 1)
                        {
                            ys_2 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 2)
                        {
                            ys_3 += 1;
                        }
                        else if (int.Parse(dateTime1.ToString().Split(' ')[0].Split('/')[1]) == current_month - 3)
                        {
                            ys_4 += 1;
                        }
                    }

                    main_stack.Children.Add(image);
                    main_stack.Children.Add(second_stack);
                    main_stack.Children.Add(textBlock3);
                    main_stack.Children.Add(textBlock2);
                    main_stack.Children.Add(textBlock1);

                    LinearGradientBrush border_color = new LinearGradientBrush();
                    border_color.StartPoint = new Point(0.5, 0);
                    border_color.EndPoint = new Point(0.5, 1);

                    GradientStop stop1 = new GradientStop();
                    stop1.Color = (Color)ColorConverter.ConvertFromString("#FF641E3A");
                    stop1.Offset = 0.4;
                    border_color.GradientStops.Add(stop1);

                    GradientStop stop2 = new GradientStop();
                    stop2.Color = (Color)ColorConverter.ConvertFromString("#FF4B1930");
                    stop2.Offset = 1;
                    border_color.GradientStops.Add(stop2);

                    Border profile_border = new Border();
                    profile_border.CornerRadius = new CornerRadius(12, 12, 12, 12);
                    profile_border.Padding = new Thickness(4);
                    profile_border.Effect = new System.Windows.Media.Effects.DropShadowEffect();
                    profile_border.Child = main_stack;
                    profile_border.Background = border_color;

                    recent_checkouts.Items.Add(profile_border);
                }
                else
                {
                    total_declines++;
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    if (unixTimestamp - full_profile[i].time_stamp < 86400)
                    {
                        declines_today++;
                    }
                }
                total_checkout.Text = total_checkouts.ToString();
                total_decline.Text = total_declines.ToString();
                total_spent.Text = "$" + total_spents.ToString();
                checkout_today.Text = checkouts_today.ToString();
                decline_today.Text = declines_today.ToString();
                spent_today.Text = "$" + spents_today.ToString();


                

                if (current_month >= 04)
                {
                    Labels = new[] { Months[current_month - 3], Months[current_month - 2], Months[current_month - 1], Months[current_month] };
                    Valid_Months.Add(current_month.ToString());
                    Valid_Months.Add((current_month - 1).ToString());
                    Valid_Months.Add((current_month - 2).ToString());
                    Valid_Months.Add((current_month - 3).ToString());
                }
                else if (current_month == 03)
                {
                    Labels = new[] { Months[12], Months[current_month - 2], Months[current_month - 1], Months[current_month] };
                    Valid_Months.Add(current_month.ToString());
                    Valid_Months.Add((current_month - 1).ToString());
                    Valid_Months.Add((current_month - 2).ToString());
                    Valid_Months.Add("12");
                }
                else if (current_month == 02)
                {
                    Labels = new[] { Months[11], Months[12], Months[current_month - 1], Months[current_month] };
                    Valid_Months.Add(current_month.ToString());
                    Valid_Months.Add((current_month - 1).ToString());
                    Valid_Months.Add("12");
                    Valid_Months.Add("11");
                }
                else if (current_month == 01)
                {
                    Labels = new[] { Months[10], Months[11], Months[12], Months[current_month] };
                    Valid_Months.Add(current_month.ToString());
                    Valid_Months.Add("12");
                    Valid_Months.Add("11");
                    Valid_Months.Add("10");
                }

                
            }
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "FootSites",
                    Values = new ChartValues<double> { ft_4, ft_3, ft_2, ft_1 },
                },
                new LineSeries
                {
                    Title = "Yeezy Supply",
                    Values = new ChartValues<double> { ys_4,ys_3,ys_2,ys_1  },
                },
                new LineSeries
                {
                    Title = "Ssense",
                    Values = new ChartValues<double> { ss_4,ss_3,ss_2,ss_1 },
                }
            };
            if (ft_4 > 0 || ft_3 > 0 || ft_2 > 0 || ft_1 > 0 || ys_4 > 0 || ys_3 > 0 || ys_2 > 0 || ys_1 > 0 || ss_4 > 0 || ss_3 > 0 || ss_2 > 0 || ss_1 > 0)
            {
            }
            else
            {
                MessageBox.Show("Mac Val Set");
                axisy_val.MaxValue = 7;
            }

            YFormatter = value => value.ToString();

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void Profile_Export_Initialized(object sender, EventArgs e)
        {
            profiel_box_Initialized();
        }

        private void Grid_Initialized_1(object sender, EventArgs e)
        {
            Dash_setup();
        }

        private void settings_deactivate_key_Initialized(object sender, EventArgs e)
        {
            Setting_Grid_Initialized();
        }

        public class CMyData1

        {

            public string taskID { get; set; }
            public string Site { get; set; }
            public string Sizes { get; set; }
            public string SKU { get; set; }
            public string TaskGroupName { get; set; }
            public string ProxyGroup { get; set; }
            public string TaskAmount { get; set; }
            public string Scheduled { get; set; }

        }

        private void Task_redo()
        {
            try
            {
                List<CMyData1> arrayCity = new List<CMyData1>();

                string jsonString = File.ReadAllText(task_path);

                using var doc = JsonDocument.Parse(jsonString);

                JsonElement root = doc.RootElement;

                var users = root.EnumerateArray();

                int i = 0;

                while (users.MoveNext())
                {
                    i++;
                    var user = users.Current;

                    var proxy = JsonSerializer.Deserialize<Tasks>(user);

                    var sizes_text = "";

                    if (proxy.size == "RANDOM")
                    {
                        sizes_text = proxy.size;
                    }
                    else
                    {
                        sizes_text = "Multiple Sizes";
                    }

                    var scheduled = "";

                    if (proxy.schedular != "None")
                    {
                        scheduled = "True";
                    }
                    else
                    {
                        scheduled = "False";
                    }

                    arrayCity.Add(new CMyData1() { taskID = proxy.task_id, Site = proxy.site, Sizes = sizes_text, SKU = proxy.sku, TaskGroupName = proxy.task_name, ProxyGroup = proxy.proxy_group, TaskAmount = proxy.amount.ToString(), Scheduled = scheduled });
                }

                tasks_box.ItemsSource = arrayCity;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void Label_Initialized(object sender, EventArgs e)
        {
            Task_redo();

            //string jsonString = File.ReadAllText(task_path);

            //using var doc = JsonDocument.Parse(jsonString);

            //JsonElement root = doc.RootElement;

            //var users = root.EnumerateArray();

            //int i = 0;

            //while (users.MoveNext())
            //{
            //    i++;
            //    var user = users.Current;

            //    var proxy = JsonSerializer.Deserialize<Tasks>(user);

            //    StackPanel stackPanel = new StackPanel();
            //    stackPanel.Orientation = Orientation.Horizontal;
            //    stackPanel.Margin = new Thickness(-4);

            //    TextBlock textBlock = new TextBlock();
            //    textBlock.Width = 104;
            //    textBlock.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock.Foreground = Brushes.White;
            //    textBlock.FontSize = 16;
            //    textBlock.IsEnabled = false;
            //    textBlock.Text = proxy.task_id;
            //    textBlock.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock.TextWrapping = TextWrapping.Wrap;
            //    textBlock.TextAlignment = TextAlignment.Left;
            //    textBlock.Padding = new Thickness(5, 0, 0, 0);
            //    textBlock.MinWidth = 104;
            //    textBlock.MaxWidth = 104;

            //    TextBlock textBlock1 = new TextBlock();
            //    textBlock1.Width = 160;
            //    textBlock1.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock1.Foreground = Brushes.White;
            //    textBlock1.FontSize = 16;
            //    textBlock1.IsEnabled = false;
            //    textBlock1.Text = proxy.site;
            //    textBlock1.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock1.TextWrapping = TextWrapping.Wrap;
            //    textBlock1.TextAlignment = TextAlignment.Left;
            //    textBlock1.MinWidth = 160;
            //    textBlock1.MaxWidth = 160;

            //    TextBlock textBlock2 = new TextBlock();
            //    textBlock2.Width = 181;
            //    textBlock2.Margin = new Thickness(3, 0, 0, 0);
            //    textBlock2.Foreground = Brushes.White;
            //    textBlock2.FontSize = 16;
            //    textBlock2.IsEnabled = false;
            //    if (proxy.size == "RANDOM")
            //    {
            //        textBlock2.Text = proxy.size;
            //    }
            //    else
            //    {
            //        textBlock2.Text = "Multiple Sizes";
            //    }
            //    textBlock2.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock2.TextWrapping = TextWrapping.Wrap;
            //    textBlock2.TextAlignment = TextAlignment.Left;
            //    textBlock2.MinWidth = 181;
            //    textBlock2.MaxWidth = 181;

            //    TextBlock textBlock3 = new TextBlock();
            //    textBlock3.Width = 200;
            //    textBlock3.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock3.Foreground = Brushes.White;
            //    textBlock3.FontSize = 16;
            //    textBlock3.IsEnabled = false;
            //    textBlock3.Text = proxy.sku;
            //    textBlock3.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock3.TextWrapping = TextWrapping.Wrap;
            //    textBlock3.TextAlignment = TextAlignment.Left;
            //    textBlock3.MinWidth = 200;
            //    textBlock3.MaxWidth = 200;

            //    TextBlock textBlock4 = new TextBlock();
            //    textBlock4.Width = 200;
            //    textBlock4.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock4.Foreground = Brushes.White;
            //    textBlock4.FontSize = 16;
            //    textBlock4.IsEnabled = false;
            //    textBlock4.Text = proxy.profiile_name.Split(',').Length.ToString() + " Profiles Selected";
            //    textBlock4.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock4.TextWrapping = TextWrapping.Wrap;
            //    textBlock4.TextAlignment = TextAlignment.Left;
            //    textBlock4.MinWidth = 200;
            //    textBlock4.MaxWidth = 200;

            //    TextBlock textBlock5 = new TextBlock();
            //    textBlock5.Width = 177;
            //    textBlock5.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock5.Foreground = Brushes.White;
            //    textBlock5.FontSize = 16;
            //    textBlock5.IsEnabled = false;
            //    textBlock5.Text = proxy.proxy_group;
            //    textBlock5.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock5.TextWrapping = TextWrapping.Wrap;
            //    textBlock5.TextAlignment = TextAlignment.Left;
            //    textBlock5.MinWidth = 177;
            //    textBlock5.MaxWidth = 177;

            //    TextBlock textBlock6 = new TextBlock();
            //    textBlock6.Width = 132;
            //    textBlock6.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock6.Foreground = Brushes.White;
            //    textBlock6.FontSize = 16;
            //    textBlock6.IsEnabled = false;
            //    textBlock6.Text = proxy.amount.ToString();
            //    textBlock6.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock6.TextWrapping = TextWrapping.Wrap;
            //    textBlock6.TextAlignment = TextAlignment.Left;
            //    textBlock6.MinWidth = 132;
            //    textBlock6.MaxWidth = 132;

            //    TextBlock textBlock7 = new TextBlock();
            //    textBlock7.Width = 68;
            //    textBlock7.Margin = new Thickness(5, 0, 0, 0);
            //    textBlock7.Foreground = Brushes.White;
            //    textBlock7.FontSize = 16;
            //    textBlock7.IsEnabled = false;
            //    if (proxy.schedular != "None")
            //    {
            //        textBlock7.Text = "True";
            //    }
            //    else
            //    {
            //        textBlock7.Text = "False";
            //    }
            //    textBlock7.VerticalAlignment = VerticalAlignment.Center;
            //    textBlock7.TextWrapping = TextWrapping.Wrap;
            //    textBlock7.TextAlignment = TextAlignment.Left;
            //    textBlock7.MinWidth = 68;
            //    textBlock7.MaxWidth = 68;

            //    stackPanel.Children.Add(textBlock);
            //    stackPanel.Children.Add(textBlock1);
            //    stackPanel.Children.Add(textBlock2);
            //    stackPanel.Children.Add(textBlock3);
            //    stackPanel.Children.Add(textBlock4);
            //    stackPanel.Children.Add(textBlock5);
            //    stackPanel.Children.Add(textBlock6);
            //    stackPanel.Children.Add(textBlock7);

            //    LinearGradientBrush border_color = new LinearGradientBrush();
            //    border_color.StartPoint = new Point(0.5, 0);
            //    border_color.EndPoint = new Point(0.5, 1);

            //    GradientStop stop2 = new GradientStop();
            //    stop2.Color = (Color)ColorConverter.ConvertFromString("#FF4B1930");
            //    stop2.Offset = 1;
            //    border_color.GradientStops.Add(stop2);

            //    GradientStop stop1 = new GradientStop();
            //    stop1.Color = (Color)ColorConverter.ConvertFromString("#FF641E3A");
            //    stop1.Offset = 0;
            //    border_color.GradientStops.Add(stop1);


            //    Border profile_border = new Border();
            //    profile_border.Width = 1271;
            //    profile_border.Height = 38;
            //    profile_border.CornerRadius = new CornerRadius(12, 12, 12, 12);
            //    profile_border.Padding = new Thickness(4);
            //    profile_border.Effect = new System.Windows.Media.Effects.DropShadowEffect();
            //    profile_border.Child = stackPanel;
            //    profile_border.Background = border_color;

            //    tasks_box.Items.Add(profile_border);
            //}
        }

        public class resps
        {
            public string CLI { get; set; }

            public string GUI { get; set; }
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

        bool updateavail = false;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
            if (updateavail_GUI == false && updateavail == false)
            {
                MessageBox.Show("You Are On The Latest Version!!", "Success");
            }
        }

        private void delete_button_Click_1(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Delete All Tasks?", "SoledOut Tasks", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                File.WriteAllText(task_path, "[]");
                //tasks_box.Items.Clear();
            }

            Task_redo();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                foreach (object o in tasks_box.SelectedItems)
                {
                    var profile_to_del = tasks_box.Items.IndexOf(o);

                    string jsonString = File.ReadAllText(task_path);

                    var doc = JsonDocument.Parse(jsonString);

                    var proxy = JsonSerializer.Deserialize<List<Tasks>>(doc);

                    proxy.RemoveAt(profile_to_del-i);

                    string json = JsonSerializer.Serialize(proxy);

                    File.WriteAllText(task_path, json);

                    i++;
                }
                Task_redo();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Delete Selected Task\n"+ex.ToString(), "Error");
            }
            

        }

        private void duplicate_menu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                foreach (object o in tasks_box.SelectedItems)
                {
                    var rand = new Random();

                    var profile_to_dup = tasks_box.Items.IndexOf(o);

                    string jsonString = File.ReadAllText(task_path);

                    var doc = JsonDocument.Parse(jsonString);

                    List<Tasks> proxy = JsonSerializer.Deserialize<List<Tasks>>(doc);

                    List<Tasks> proxy2 = JsonSerializer.Deserialize<List<Tasks>>(doc);

                    int profile_to_dupe = int.Parse(profile_to_dup.ToString());

                    var new_id = proxy2[profile_to_dupe];

                    new_id.task_id = rand.Next(00000, 99999).ToString();

                    proxy.Add(new_id);

                    string json = JsonSerializer.Serialize(proxy);

                    File.WriteAllText(task_path, json);
                }

                Task_redo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Delete Selected Task\n" + ex.ToString(), "Error");
            }
        }

        private void edit_menu_Click(object sender, RoutedEventArgs e)
        {
            var selected_tasks = tasks_box.SelectedItem;

            Window2 win2 = new Window2();
            win2.Owner = this;

            if (selected_tasks == null)
            {
                MessageBox.Show("Select Tasks To Edit!", "Error");
                return;
            }
            
            List<string> selectedtasks = new List<string>();
            foreach (object o in tasks_box.SelectedItems)
            {

                var profile_to_del = tasks_box.Items.IndexOf(o);

                selectedtasks.Add(profile_to_del.ToString());
            }
            this.Effect = new System.Windows.Media.Effects.BlurEffect();
            
            win2.ShowDialog(string.Join(',', selectedtasks));
            this.Effect = null;
            Task_redo();
        }

        private void profile_delete_Click_1(object sender, RoutedEventArgs e)
        {
            e.Handled = false;

            try
            {
                MessageBox.Show(profiel_box.SelectedIndex.ToString());

                var itemToRemove = profiel_box.SelectedIndex;

                string jsonString = File.ReadAllText(profile_path);

                var all_profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString);

                all_profiles.RemoveAt(itemToRemove);

                string json = JsonSerializer.Serialize(all_profiles);

                File.WriteAllText(profile_path, json);

                //profiel_box.Items.Clear();

                Window1 _window1 = new Window1();

                _window1.create_profiles.Items.Clear();

                string jsonString2 = File.ReadAllText(profile_path);

                using var doc = JsonDocument.Parse(jsonString2);
                JsonElement root = doc.RootElement;

                var users = root.EnumerateArray();

                while (users.MoveNext())
                {
                    var user = users.Current;

                    var full_profile = JsonSerializer.Deserialize<Profile>(user);

                    _window1.create_profiles.Items.Add(full_profile.name);
                }

                profiel_box_Initialized();

                MessageBox.Show("Profile Deleted Successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Delete the Profile!" + ex.ToString(), "Error");
            }
        }

        private string GetParents(Object element, int parentLevel)
        {
            string returnValue = String.Format("[{0}] {1}", parentLevel, element.GetType());
            if (element is FrameworkElement)
            {
                if (((FrameworkElement)element).Parent != null)
                    returnValue += String.Format("{0}{1}",
                        Environment.NewLine, GetParents(((FrameworkElement)element).Parent, parentLevel + 1));
            }
            return returnValue;
        }
    }
        
}
