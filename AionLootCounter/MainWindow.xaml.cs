using AionLootCounter.Controls;
using AionLootCounter.Utils;
using AionLootCounter.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AionLootCounter
{
    public partial class MainWindow : Window
    {
        private bool lockOpacity = false;
        private AppSettings settings = new AppSettings();
        private readonly List<PlayerLoot> playerLootControlList;

        public MainWindow()
        {
            InitializeComponent();

            playerLootControlList = new List<PlayerLoot>
            { Player1, Player2, Player3, Player4, Player5, Player6 };

            ApplySettings();
            ShowMe();
        }

        #region UI Events

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

        private void Window_Deactivated(object sender, EventArgs e)
        {
            LblWindowTitle.Focusable = true;
            LblWindowTitle.Focus();
            LblWindowTitle.Focusable = false;
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

        private void PlayerLoot_EnterPressed(object sender, PlayerLootField e)
        {
            var currentControl = (PlayerLoot)sender;
            var setFocus = false;

            for (var i = 0; i < playerLootControlList.Count; i++)
            {
                if (setFocus)
                {
                    if ((playerLootControlList[i].Visibility == Visibility.Visible && !string.IsNullOrWhiteSpace(playerLootControlList[i].PlayerName)) || e == PlayerLootField.Name)
                    {
                        playerLootControlList[i].Focus(e);
                        break;
                    }
                }
                else
                {
                    if (playerLootControlList[i] == currentControl)
                    {
                        setFocus = true;
                        if (i == settings.GroupMembers - 1) i = -1;
                    }
                }
            }
        }

        private void PlayerLoot_ValueChanged(object sender, EventArgs e)
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

        private void BtnCopyLoot_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(GetAllLoots());
        }

        private void BtnCopyRoll_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(GetNextRoll());
        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            lockOpacity = true;
            if (this.MessageBox("Clear all values?", MessageBoxButton.YesNo))
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
            SettingsWindow settingsWindow = new SettingsWindow(settings) { Owner = GetWindow(this) };

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

        #endregion

        #region Misc

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

            ShowMe();

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
        }

        private void ShowMe()
        {
            for (var i = 0; i < playerLootControlList.Count; i++)
            {
                if (playerLootControlList[i].Visibility != Visibility.Visible)
                {
                    i--;
                    if (string.IsNullOrWhiteSpace(playerLootControlList[i].PlayerName))
                    {
                        playerLootControlList[i].PlayerName = "Me";
                    }
                    break;
                }
                else if (playerLootControlList[i].PlayerName.Equals("Me", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else if (i == playerLootControlList.Count - 1)
                {
                    if (string.IsNullOrWhiteSpace(playerLootControlList[i].PlayerName))
                    {
                        playerLootControlList[i].PlayerName = "Me";
                    }
                }
            }
        }

        private string GetAllLoots()
        {
            List<string> lootNames = new List<string>();
            if (settings.ShowBag & settings.CopyBag) lootNames.Add("Bag");
            lootNames.Add("Gold");
            lootNames.Add("Eternal");
            if (settings.ShowMythic & settings.CopyMythic) lootNames.Add("Mythic");

            List<string> playerLoots = new List<string>();
            if (Player1.Include) playerLoots.Add(Player1.LootText);
            if (Player2.Include) playerLoots.Add(Player2.LootText);
            if (Player3.Include) playerLoots.Add(Player3.LootText);
            if (Player4.Include) playerLoots.Add(Player4.LootText);
            if (Player5.Include) playerLoots.Add(Player5.LootText);
            if (Player6.Include) playerLoots.Add(Player6.LootText);

            List<int> totalLoots = new List<int>();
            if (settings.ShowBag & settings.CopyBag) totalLoots.Add(Player1.Bag + Player2.Bag + Player3.Bag + Player4.Bag + Player5.Bag + Player6.Bag);
            totalLoots.Add(Player1.Gold + Player2.Gold + Player3.Gold + Player4.Gold + Player5.Gold + Player6.Gold);
            totalLoots.Add(Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal);
            if (settings.ShowMythic & settings.CopyMythic) totalLoots.Add(Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic);
            playerLoots.Add("All loots " + string.Join("/", totalLoots));

            return string.Format("Loots [where:{0}]: {1}", string.Join("/", lootNames), string.Join(", ", playerLoots));
        }

        private string GetNextRoll()
        {
            var rollList = new List<string>();
            List<Tuple<int, string>> playerLoots;

            if (settings.ShowBag & settings.CopyBag)
            {
                playerLoots = new List<Tuple<int, string>>();
                if (Player1.Include) playerLoots.Add(new Tuple<int, string>(Player1.Bag, Player1.PlayerName));
                if (Player2.Include) playerLoots.Add(new Tuple<int, string>(Player2.Bag, Player2.PlayerName));
                if (Player3.Include) playerLoots.Add(new Tuple<int, string>(Player3.Bag, Player3.PlayerName));
                if (Player4.Include) playerLoots.Add(new Tuple<int, string>(Player4.Bag, Player4.PlayerName));
                if (Player5.Include) playerLoots.Add(new Tuple<int, string>(Player5.Bag, Player5.PlayerName));
                if (Player6.Include) playerLoots.Add(new Tuple<int, string>(Player6.Bag, Player6.PlayerName));
                rollList.Add(string.Format("[where:Bag] {0}", NextLoot(playerLoots)));
            }

            playerLoots = new List<Tuple<int, string>>();
            if (Player1.Include) playerLoots.Add(new Tuple<int, string>(Player1.Gold, Player1.PlayerName));
            if (Player2.Include) playerLoots.Add(new Tuple<int, string>(Player2.Gold, Player2.PlayerName));
            if (Player3.Include) playerLoots.Add(new Tuple<int, string>(Player3.Gold, Player3.PlayerName));
            if (Player4.Include) playerLoots.Add(new Tuple<int, string>(Player4.Gold, Player4.PlayerName));
            if (Player5.Include) playerLoots.Add(new Tuple<int, string>(Player5.Gold, Player5.PlayerName));
            if (Player6.Include) playerLoots.Add(new Tuple<int, string>(Player6.Gold, Player6.PlayerName));
            rollList.Add(string.Format("[where:Gold] {0}", NextLoot(playerLoots)));

            playerLoots = new List<Tuple<int, string>>();
            if (Player1.Include) playerLoots.Add(new Tuple<int, string>(Player1.Eternal, Player1.PlayerName));
            if (Player2.Include) playerLoots.Add(new Tuple<int, string>(Player2.Eternal, Player2.PlayerName));
            if (Player3.Include) playerLoots.Add(new Tuple<int, string>(Player3.Eternal, Player3.PlayerName));
            if (Player4.Include) playerLoots.Add(new Tuple<int, string>(Player4.Eternal, Player4.PlayerName));
            if (Player5.Include) playerLoots.Add(new Tuple<int, string>(Player5.Eternal, Player5.PlayerName));
            if (Player6.Include) playerLoots.Add(new Tuple<int, string>(Player6.Eternal, Player6.PlayerName));
            rollList.Add(string.Format("[where:Eternal] {0}", NextLoot(playerLoots)));

            if (settings.ShowMythic & settings.CopyMythic)
            {
                playerLoots = new List<Tuple<int, string>>();
                if (Player1.Include) playerLoots.Add(new Tuple<int, string>(Player1.Mythic, Player1.PlayerName));
                if (Player2.Include) playerLoots.Add(new Tuple<int, string>(Player2.Mythic, Player2.PlayerName));
                if (Player3.Include) playerLoots.Add(new Tuple<int, string>(Player3.Mythic, Player3.PlayerName));
                if (Player4.Include) playerLoots.Add(new Tuple<int, string>(Player4.Mythic, Player4.PlayerName));
                if (Player5.Include) playerLoots.Add(new Tuple<int, string>(Player5.Mythic, Player5.PlayerName));
                if (Player6.Include) playerLoots.Add(new Tuple<int, string>(Player6.Mythic, Player6.PlayerName));
                rollList.Add(string.Format("[where:Mythic] {0}", NextLoot(playerLoots)));
            }

            return string.Format("Next Roll: {0}", string.Join(", ", rollList));
        }

        private string NextLoot(List<Tuple<int, string>> items)
        {
            if (items.Count > 1)
            {
                if (items.Sum(i => i.Item1) > 0)
                {
                    var allEqual = true;
                    for (var i = 1; i < items.Count; i++)
                    {
                        if (items[i - 1].Item1 != items[i].Item1)
                        {
                            allEqual = false;
                            break;
                        }
                    }

                    if (!allEqual)
                    {
                        items = items.OrderByDescending(i => i.Item1).ToList();

                        var eliminate = true;

                        var oopsLoops = 0;
                        while (eliminate)
                        {
                            if (items.Count > 1)
                            {
                                allEqual = true;
                                for (var i = 1; i < items.Count; i++)
                                {
                                    if (items[i - 1].Item1 != items[i].Item1)
                                    {
                                        allEqual = false;
                                        items.RemoveAt(i - 1);
                                        break;
                                    }
                                }

                                if (allEqual) eliminate = false;
                            }
                            else eliminate = false;

                            oopsLoops++;
                            if (oopsLoops >= 100) break;
                        }

                        var names = items.Select(i => i.Item2).ToList();
                        for (var i = 0; i < names.Count(); i++)
                        {
                            names[i] = string.Format("[kvalue:1;{0};str]", names[i]);
                        }
                        return string.Join(" ", names);
                    }
                }
            }
            return "[kvalue:1;All;str]";
        }

        #endregion

    }
}