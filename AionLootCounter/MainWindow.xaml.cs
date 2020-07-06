using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AionLootCounter
{

    public partial class MainWindow : Window
    {

        private bool lockOpacity = false;

        private bool CountBag = true;
        private bool CountMythic = false;

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

            Player6.PlayerName = "ME";

        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Topmost) Opacity = 1;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Topmost && !lockOpacity) Opacity = 0.5;
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
            int totalYellow = Player1.Yellow + Player2.Yellow + Player3.Yellow + Player4.Yellow + Player5.Yellow + Player6.Yellow;
            int totalEternal = Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal;
            int totalMythic = Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic;
            LblTotalBag.Content = totalBag > 0 ? totalBag.ToString() : "";
            LblTotalYellow.Content = totalYellow > 0 ? totalYellow.ToString() : "";
            LblTotalEternal.Content = totalEternal > 0 ? totalEternal.ToString() : "";
            LblTotalMythic.Content = totalMythic > 0 ? totalMythic.ToString() : "";
        }

        private void BtnCopyText_Click(object sender, RoutedEventArgs e)
        {

            List<string> lootNames = new List<string>();
            if (CountBag) lootNames.Add("Bag");
            lootNames.Add("Yellow");
            lootNames.Add("Eternal");
            if (CountMythic) lootNames.Add("Mythic");

            List<string> playerLoots = new List<string>();
            if (Player1.HasName) playerLoots.Add(Player1.GetText());
            if (Player2.HasName) playerLoots.Add(Player2.GetText());
            if (Player3.HasName) playerLoots.Add(Player3.GetText());
            if (Player4.HasName) playerLoots.Add(Player4.GetText());
            if (Player5.HasName) playerLoots.Add(Player5.GetText());
            if (Player6.HasName) playerLoots.Add(Player6.GetText());

            List<int> totalLoots = new List<int>();
            if (CountBag) totalLoots.Add(Player1.Bag + Player2.Bag + Player3.Bag + Player4.Bag + Player5.Bag + Player6.Bag);
            totalLoots.Add(Player1.Yellow + Player2.Yellow + Player3.Yellow + Player4.Yellow + Player5.Yellow + Player6.Yellow);
            totalLoots.Add(Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal);
            if (CountMythic) totalLoots.Add(Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic);
            playerLoots.Add("All loots " + string.Join("/", totalLoots));

            Clipboard.Clear();
            Clipboard.SetText(string.Format("Loots {0}: {1}", string.Join("/", lootNames), string.Join(", ", playerLoots)));

        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            lockOpacity = true;
            if (MessageBoxEx.Show(this, "Clear all values?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Player1.Clear();
                Player2.Clear();
                Player3.Clear();
                Player4.Clear();
                Player5.Clear();
                Player6.Clear();
                Player6.PlayerName = "ME";
            }
            lockOpacity = false;
        }

    }

}
