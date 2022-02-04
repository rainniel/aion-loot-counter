using AionLootCounter.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AionLootCounter.Controls
{
    public partial class PlayerLoot : UserControl
    {
        public event EventHandler<PlayerLootField> EnterPressed;
        public event EventHandler ValueChanged;

        private readonly Dictionary<string, int> loots = new Dictionary<string, int>();

        private bool countBag = true;
        private bool countMythic = false;

        public PlayerLoot()
        {
            InitializeComponent();

            loots.Add(TbxBag.Name, 0);
            loots.Add(TbxGold.Name, 0);
            loots.Add(TbxEternal.Name, 0);
            loots.Add(TbxMythic.Name, 0);
        }

        #region UI Events

        private void TbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxName.Text))
            {
                TbxBag.IsEnabled = false;
                TbxGold.IsEnabled = false;
                TbxEternal.IsEnabled = false;
                TbxMythic.IsEnabled = false;
            }
            else
            {
                TbxBag.IsEnabled = true;
                TbxGold.IsEnabled = true;
                TbxEternal.IsEnabled = true;
                TbxMythic.IsEnabled = true;
            }
        }

        private void TbxName_LostFocus(object sender, RoutedEventArgs e)
        {
            TbxName.Text = TbxName.Text.ToTitleCase();
        }

        private void Loot_ValueChanged(object sender, EventArgs e)
        {
            LootTextBox tbx = (LootTextBox)sender;
            loots[tbx.Name] = tbx.Value;
            UpdateNameFont();
        }

        private void TbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) EnterPressed?.Invoke(this, PlayerLootField.Name);
        }

        private void TbxBag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) EnterPressed?.Invoke(this, PlayerLootField.Bag);
        }

        private void TbxGold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) EnterPressed?.Invoke(this, PlayerLootField.Gold);
        }

        private void TbxEternal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) EnterPressed?.Invoke(this, PlayerLootField.Eternal);
        }

        private void TbxMythic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) EnterPressed?.Invoke(this, PlayerLootField.Mythic);
        }

        #endregion

        #region Properties

        public string PlayerName
        {
            get => TbxName.Text.ToTitleCase();
            set => TbxName.Text = value.ToTitleCase();
        }

        public bool ShowBag
        {
            get => TbxBag.Visibility == Visibility.Visible;
            set => TbxBag.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public bool CountBag
        {
            get => ShowBag & countBag;
            set
            {
                countBag = value;
                TbxBag.Background = value ? Brushes.White : Brushes.Gainsboro;
            }
        }

        public bool ShowMythic
        {
            get => TbxMythic.Visibility == Visibility.Visible;
            set => TbxMythic.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public bool CountMythic
        {
            get => ShowMythic & countMythic;
            set
            {
                countMythic = value;
                TbxMythic.Background = value ? Brushes.White : Brushes.Gainsboro;
            }
        }

        public int Bag
        {
            get => TbxBag.Value;
            set => TbxBag.Value = value;
        }

        public int Gold
        {
            get => TbxGold.Value;
            set => TbxGold.Value = value;
        }

        public int Eternal
        {
            get => TbxEternal.Value;
            set => TbxEternal.Value = value;
        }

        public int Mythic
        {
            get => TbxMythic.Value;
            set => TbxMythic.Value = value;
        }

        public bool Include
        {
            get => Visibility == Visibility.Visible & !string.IsNullOrWhiteSpace(TbxName.Text);
        }

        public bool HasLoot
        {
            get
            {
                int loots = Gold + Eternal;
                if (CountBag) loots += Bag;
                if (CountMythic) loots += Mythic;
                return loots > 0;
            }
        }

        public string LootText
        {
            get
            {
                string output = string.Format("[{0}] ", PlayerName);
                if (HasLoot)
                {
                    List<int> loots = new List<int>();
                    if (CountBag) loots.Add(Bag);
                    loots.Add(Gold);
                    loots.Add(Eternal);
                    if (CountMythic) loots.Add(Mythic);
                    output += string.Join("/", loots);
                }
                else output += "none";
                return output;
            }
        }

        #endregion

        #region "Misc"

        public void Clear()
        {
            TbxName.Clear();
            TbxBag.Clear();
            TbxGold.Clear();
            TbxEternal.Clear();
            TbxMythic.Clear();
        }

        public void Focus(PlayerLootField fieldType)
        {
            switch (fieldType)
            {
                case PlayerLootField.Name:
                    TbxName.SelectionStart = TbxName.Text.Length;
                    TbxName.Focus();
                    break;
                case PlayerLootField.Bag:
                    TbxBag.Focus();
                    break;
                case PlayerLootField.Gold:
                    TbxGold.Focus();
                    break;
                case PlayerLootField.Eternal:
                    TbxEternal.Focus();
                    break;
                case PlayerLootField.Mythic:
                    TbxMythic.Focus();
                    break;
            }
        }

        private void UpdateNameFont()
        {
            TbxName.FontWeight = HasLoot ? FontWeights.Bold : FontWeights.Normal;
            ValueChanged?.Invoke(this, null);
        }

        #endregion

    }

    public enum PlayerLootField
    {
        Name,
        Bag,
        Gold,
        Eternal,
        Mythic
    }
}