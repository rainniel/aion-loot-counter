using AionLootCounter.Utils;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AionLootCounter.Windows
{
    public partial class SettingsWindow : Window
    {
        private readonly int originalGroupMembers;
        public AppSettings Settings;

        public SettingsWindow(AppSettings settings)
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            LblAppNameVersion.Content = string.Format("{0} v{1}", fvi.ProductName, fvi.ProductVersion);

            if (settings == null) settings = new AppSettings();

            ChkShowBag.IsChecked = settings.ShowBag;
            ChkCopyBag.IsChecked = settings.CopyBag;
            ChkShowMythic.IsChecked = settings.ShowMythic;
            ChkCopyMythic.IsChecked = settings.CopyMythic;
            ChkCopyBag.IsEnabled = settings.ShowBag;
            ChkCopyMythic.IsEnabled = settings.ShowMythic;

            originalGroupMembers = settings.GroupMembers;
            TbxGroupMembers.Value = settings.GroupMembers;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
            else if (e.Key == Key.Enter) BtnSave_Click(sender, e);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void ChkShowBag_Click(object sender, RoutedEventArgs e)
        {
            ChkCopyBag.IsEnabled = (bool)ChkShowBag.IsChecked;
        }

        private void ChkShowMythic_Click(object sender, RoutedEventArgs e)
        {
            ChkCopyMythic.IsEnabled = (bool)ChkShowMythic.IsChecked;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var tmpGroupMembers = (byte)TbxGroupMembers.Value;
            if (tmpGroupMembers < 2)
            {
                new MessageBoxWindow(this, "The minimum group members is 2.", "Input Error", MessageBoxButton.OK).ShowDialog();
                return;
            }
            if (tmpGroupMembers > 6)
            {
                new MessageBoxWindow(this, "The maximum group members is 6.", "Input Error", MessageBoxButton.OK).ShowDialog();
                return;
            }

            if (tmpGroupMembers < originalGroupMembers)
            {
                if (new MessageBoxWindow(this, "Your input group members is lower than the original, the last name row(s) will be removed, do you want to continue?", "", MessageBoxButton.YesNo).ShowDialog() != true)
                    return;
            }

            Settings = new AppSettings
            {
                ShowBag = (bool)ChkShowBag.IsChecked,
                CopyBag = (bool)ChkCopyBag.IsChecked,
                ShowMythic = (bool)ChkShowMythic.IsChecked,
                CopyMythic = (bool)ChkCopyMythic.IsChecked,
                GroupMembers = tmpGroupMembers
            };

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}