using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AionLootCounter
{
    public partial class PlayerLootControl : UserControl
    {

        private Dictionary<string, int> itemValues = new Dictionary<string, int>();
        private bool updating = false;

        private bool countBag = true;
        private bool countMythic = false;

        public event EventHandler ValueChanged;
        public event EventHandler EnterPressed;

        public PlayerLootControl()
        {
            InitializeComponent();
            itemValues.Add(TbxBag.Name, 0);
            itemValues.Add(TbxGold.Name, 0);
            itemValues.Add(TbxEternal.Name, 0);
            itemValues.Add(TbxMythic.Name, 0);
        }

        #region "UI Events"

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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ItemTextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
                e.Handled = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) EnterPressed?.Invoke(this, null);
        }

        private void TbxItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!updating)
            {
                TextBox tbx = (TextBox)sender;
                itemValues[tbx.Name] = Helper.GetInt(tbx.Text);
                UpdateNameFont();
            }
        }

        private void TbxItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.W || e.Key == Key.S)
            {

                TextBox tbx = (TextBox)sender;
                int val = itemValues[tbx.Name];

                if (e.Key == Key.Up || e.Key == Key.W) val++;
                else val--;

                if (val < 0) val = 0;
                if (val > 99) val = 99;
                itemValues[tbx.Name] = val;

                updating = true;
                if (val > 0)
                {
                    tbx.Text = val.ToString();
                    tbx.SelectionStart = tbx.Text.Length;
                }
                else tbx.Clear();
                updating = false;
                UpdateNameFont();

            }

        }

        private void UpdateNameFont()
        {
            TbxName.FontWeight = HasLoot ? FontWeights.Bold : FontWeights.Normal;
            ValueChanged?.Invoke(this, null);
        }

        public void FocusName()
        {
            TbxName.Focus();
        }

        #endregion

        #region "Misc"

        private void UpdateWidth()
        {
            int width = 286;
            if (ShowBag == false) width -= 45;
            if (ShowMythic == false) width -= 45;
            Width = width;
        }

        public string PlayerName
        {
            get { return TbxName.Text.Trim(); }
            set { TbxName.Text = value.Trim(); }
        }

        public bool ShowBag
        {
            get { return TbxBag.Visibility == Visibility.Visible; }
            set
            {
                if (value) TbxBag.Visibility = Visibility.Visible;
                else TbxBag.Visibility = Visibility.Collapsed;
                UpdateWidth();
            }
        }

        public bool CountBag
        {
            get { return ShowBag & countBag; }
            set
            {
                countBag = value;
                TbxBag.Background = value ? Brushes.White : Brushes.Gainsboro;
            }
        }

        public bool ShowMythic
        {
            get { return TbxMythic.Visibility == Visibility.Visible; }
            set
            {
                if (value) TbxMythic.Visibility = Visibility.Visible;
                else TbxMythic.Visibility = Visibility.Collapsed;
                UpdateWidth();
            }
        }

        public bool CountMythic
        {
            get { return ShowMythic & countMythic; }
            set
            {
                countMythic = value;
                TbxMythic.Background = value ? Brushes.White : Brushes.Gainsboro;
            }
        }

        public int Bag
        {
            get { return Helper.GetInt(TbxBag.Text); }
            set { TbxBag.Text = value.ToString(); }
        }

        public int Gold
        {
            get { return Helper.GetInt(TbxGold.Text); }
            set { TbxGold.Text = value.ToString(); }
        }

        public int Eternal
        {
            get { return Helper.GetInt(TbxEternal.Text); }
            set { TbxEternal.Text = value.ToString(); }
        }

        public int Mythic
        {
            get { return Helper.GetInt(TbxMythic.Text); }
            set { TbxMythic.Text = value.ToString(); }
        }

        public bool Include
        {
            get
            {
                return Visibility == Visibility.Visible & string.IsNullOrWhiteSpace(TbxName.Text) == false;
            }
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

        public string GetText()
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

        public void Clear()
        {
            TbxName.Clear();
            TbxBag.Clear();
            TbxGold.Clear();
            TbxEternal.Clear();
            TbxMythic.Clear();
        }

        #endregion

    }

}