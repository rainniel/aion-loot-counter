using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AionLootCounter.Windows
{

    public partial class SettingsWindow : Window
    {

        private bool updating;
        private int groupMembers;
        private int originalGroupMembers;

        public AppSettings Settings;

        public SettingsWindow(AppSettings settings)
        {

            InitializeComponent();
            if (settings == null) settings = new AppSettings();

            ChkShowBag.IsChecked = settings.ShowBag;
            ChkCopyBag.IsChecked = settings.CopyBag;
            ChkShowMythic.IsChecked = settings.ShowMythic;
            ChkCopyMythic.IsChecked = settings.CopyMythic;
            ChkCopyBag.IsEnabled = settings.ShowBag;
            ChkCopyMythic.IsEnabled = settings.ShowMythic;

            originalGroupMembers = settings.GroupMembers;

            TbxGroupMembers.Text = settings.GroupMembers.ToString();
            groupMembers = settings.GroupMembers;

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            else if (e.Key == Key.Enter)
            {
                BtnSave_Click(sender, e);
            }
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TbxGroupMembers_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
                e.Handled = true;
        }

        private void TbxGroupMembers_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                TextBox tbx = (TextBox)sender;
                int val = groupMembers;

                if (e.Key == Key.Up) val++;
                else val--;

                if (val < 2) val = 2;
                if (val > 6) val = 6;
                groupMembers = val;

                updating = true;
                if (val > 0)
                {
                    tbx.Text = val.ToString();
                    tbx.SelectionStart = tbx.Text.Length;
                }
                else tbx.Clear();
                updating = false;
            }
        }

        private void TbxGroupMembers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!updating)
            {
                TextBox tbx = (TextBox)sender;
                int.TryParse(tbx.Text, out int val);
                groupMembers = val;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            int tmpGroupMembers = Helper.GetInt(TbxGroupMembers.Text);
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

            Settings = new AppSettings();
            Settings.ShowBag = (bool)ChkShowBag.IsChecked;
            Settings.CopyBag = (bool)ChkCopyBag.IsChecked;
            Settings.ShowMythic = (bool)ChkShowMythic.IsChecked;
            Settings.CopyMythic = (bool)ChkCopyMythic.IsChecked;
            Settings.GroupMembers = tmpGroupMembers;

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}