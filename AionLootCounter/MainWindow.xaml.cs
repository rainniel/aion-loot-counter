using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using AionLootCounter.Windows;

namespace AionLootCounter
{

    public partial class MainWindow : Window
    {

        private bool lockOpacity = false;

        private AppSettings settings = new AppSettings();

        public MainWindow()
        {
            InitializeComponent();

            Player1.ValueChanged += ValueChanged;
            Player2.ValueChanged += ValueChanged;
            Player3.ValueChanged += ValueChanged;
            Player4.ValueChanged += ValueChanged;
            Player5.ValueChanged += ValueChanged;
            Player6.ValueChanged += ValueChanged;
            Player1.EnterPressed += Player1_EnterPressed;
            Player2.EnterPressed += Player2_EnterPressed;
            Player3.EnterPressed += Player3_EnterPressed;
            Player4.EnterPressed += Player4_EnterPressed;
            Player5.EnterPressed += Player5_EnterPressed;
            Player6.EnterPressed += Player6_EnterPressed;

            ApplySettings();
            ShowMe();

        }

        private void ApplySettings()
        {

            Player3.Visibility = settings.GroupMembers >= 3 ? Visibility.Visible : Visibility.Collapsed;
            Player4.Visibility = settings.GroupMembers >= 4 ? Visibility.Visible : Visibility.Collapsed;
            Player5.Visibility = settings.GroupMembers >= 5 ? Visibility.Visible : Visibility.Collapsed;
            Player6.Visibility = settings.GroupMembers >= 6 ? Visibility.Visible : Visibility.Collapsed;

            if (Player3.Visibility != Visibility.Visible) Player3.Clear();
            if (Player4.Visibility != Visibility.Visible) Player4.Clear();
            if (Player5.Visibility != Visibility.Visible) Player5.Clear();
            if (Player6.Visibility != Visibility.Visible) Player6.Clear();

            string playerNames = Player1.PlayerName + Player2.PlayerName + Player3.PlayerName + Player4.PlayerName + Player5.PlayerName + Player6.PlayerName;

            if (string.IsNullOrEmpty(playerNames)) ShowMe();
            else if (playerNames.Equals("ME", StringComparison.OrdinalIgnoreCase))
            {
                Player1.Clear();
                Player2.Clear();
                Player3.Clear();
                Player4.Clear();
                Player5.Clear();
                Player6.Clear();
                ShowMe();
            }

            Player1.ShowBag = settings.ShowBag;
            Player2.ShowBag = settings.ShowBag;
            Player3.ShowBag = settings.ShowBag;
            Player4.ShowBag = settings.ShowBag;
            Player5.ShowBag = settings.ShowBag;
            Player6.ShowBag = settings.ShowBag;
            Player1.ShowMythic = settings.ShowMythic;
            Player2.ShowMythic = settings.ShowMythic;
            Player3.ShowMythic = settings.ShowMythic;
            Player4.ShowMythic = settings.ShowMythic;
            Player5.ShowMythic = settings.ShowMythic;
            Player6.ShowMythic = settings.ShowMythic;

            Player1.CountBag = settings.CopyBag;
            Player2.CountBag = settings.CopyBag;
            Player3.CountBag = settings.CopyBag;
            Player4.CountBag = settings.CopyBag;
            Player5.CountBag = settings.CopyBag;
            Player6.CountBag = settings.CopyBag;
            Player1.CountMythic = settings.CopyMythic;
            Player2.CountMythic = settings.CopyMythic;
            Player3.CountMythic = settings.CopyMythic;
            Player4.CountMythic = settings.CopyMythic;
            Player5.CountMythic = settings.CopyMythic;
            Player6.CountMythic = settings.CopyMythic;

            LblBag.Visibility = settings.ShowBag ? Visibility.Visible : Visibility.Collapsed;
            LblMythic.Visibility = settings.ShowMythic ? Visibility.Visible : Visibility.Collapsed;
            LblTotalBag.Visibility = settings.ShowBag ? Visibility.Visible : Visibility.Collapsed;
            LblTotalMythic.Visibility = settings.ShowMythic ? Visibility.Visible : Visibility.Collapsed;

            int width = 310;
            int height = 285;

            if (!settings.ShowBag) width -= 45;
            if (!settings.ShowMythic) width -= 45;

            int hiddenPlayer = 6 - settings.GroupMembers;
            if (hiddenPlayer > 0) height -= (30 * hiddenPlayer);

            Width = width;
            Height = height;

        }

        private void ShowMe()
        {
            switch (settings.GroupMembers)
            {
                case 2: Player2.PlayerName = "ME"; break;
                case 3: Player3.PlayerName = "ME"; break;
                case 4: Player4.PlayerName = "ME"; break;
                case 5: Player5.PlayerName = "ME"; break;
                case 6: Player6.PlayerName = "ME"; break;
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Topmost) Opacity = 1;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Topmost & lockOpacity == false) Opacity = 0.5;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void BtnPin_Click(object sender, RoutedEventArgs e)
        {
            if (!Topmost)
            {
                PthPin.Data = (Geometry)FindResource("UnpinGeometry");
                PthPin.Margin = new Thickness(2, 3, 3, 3);
                Topmost = true;
            }
            else
            {
                PthPin.Data = (Geometry)FindResource("PinGeometry");
                PthPin.Margin = new Thickness(4, 3, 4, 3);
                Topmost = false;
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Player1_EnterPressed(object sender, EventArgs e)
        {
            Player2.FocusName();
        }

        private void Player2_EnterPressed(object sender, EventArgs e)
        {
            Player3.FocusName();
        }

        private void Player3_EnterPressed(object sender, EventArgs e)
        {
            Player4.FocusName();
        }

        private void Player4_EnterPressed(object sender, EventArgs e)
        {
            Player5.FocusName();
        }

        private void Player5_EnterPressed(object sender, EventArgs e)
        {
            Player6.FocusName();
        }

        private void Player6_EnterPressed(object sender, EventArgs e)
        {
            Player1.FocusName();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            int totalBag = Player1.Bag + Player2.Bag + Player3.Bag + Player4.Bag + Player5.Bag + Player6.Bag;
            int totalGold = Player1.Gold + Player2.Gold + Player3.Gold + Player4.Gold + Player5.Gold + Player6.Gold;
            int totalEternal = Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal;
            int totalMythic = Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic;
            LblTotalBag.Content = totalBag > 0 ? totalBag.ToString() : "";
            LblTotalGold.Content = totalGold > 0 ? totalGold.ToString() : "";
            LblTotalEternal.Content = totalEternal > 0 ? totalEternal.ToString() : "";
            LblTotalMythic.Content = totalMythic > 0 ? totalMythic.ToString() : "";
        }

        private void BtnCopyText_Click(object sender, RoutedEventArgs e)
        {

            List<string> lootNames = new List<string>();
            if (settings.ShowBag & settings.CopyBag) lootNames.Add("Bag");
            lootNames.Add("Gold");
            lootNames.Add("Eternal");
            if (settings.ShowMythic & settings.CopyMythic) lootNames.Add("Mythic");

            List<string> playerLoots = new List<string>();
            if (Player1.Include) playerLoots.Add(Player1.GetText());
            if (Player2.Include) playerLoots.Add(Player2.GetText());
            if (Player3.Include) playerLoots.Add(Player3.GetText());
            if (Player4.Include) playerLoots.Add(Player4.GetText());
            if (Player5.Include) playerLoots.Add(Player5.GetText());
            if (Player6.Include) playerLoots.Add(Player6.GetText());

            List<int> totalLoots = new List<int>();
            if (settings.ShowBag & settings.CopyBag) totalLoots.Add(Player1.Bag + Player2.Bag + Player3.Bag + Player4.Bag + Player5.Bag + Player6.Bag);
            totalLoots.Add(Player1.Gold + Player2.Gold + Player3.Gold + Player4.Gold + Player5.Gold + Player6.Gold);
            totalLoots.Add(Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal);
            if (settings.ShowMythic & settings.CopyMythic) totalLoots.Add(Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic);
            playerLoots.Add("All loots " + string.Join("/", totalLoots));

            Clipboard.Clear();
            Clipboard.SetText(string.Format("Loots {0}: {1}", string.Join("/", lootNames), string.Join(", ", playerLoots)));

        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {

            lockOpacity = true;
            if (new MessageBoxWindow(this, "Clear all values?", "", MessageBoxButton.YesNo).ShowDialog() == true)
            {
                Player1.Clear();
                Player2.Clear();
                Player3.Clear();
                Player4.Clear();
                Player5.Clear();
                Player6.Clear();
                ShowMe();
            }
            lockOpacity = false;

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {

            SettingsWindow settingsWindow = new SettingsWindow(settings);
            settingsWindow.Owner = GetWindow(this);

            lockOpacity = true;
            if (settingsWindow.ShowDialog() == true)
            {
                if (settingsWindow.Settings != null)
                {
                    settings = settingsWindow.Settings;
                    ApplySettings();
                }
            }
            lockOpacity = false;

        }

    }

}
