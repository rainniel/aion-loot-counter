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

        public bool countBag = true;
        public bool countMythic = false;

        public event EventHandler ValueChanged;
        public event EventHandler EnterPressed;

        public PlayerLootControl()
        {
            InitializeComponent();
            itemValues.Add(TbxBag.Name, 0);
            itemValues.Add(TbxYellow.Name, 0);
            itemValues.Add(TbxEternal.Name, 0);
            itemValues.Add(TbxMythic.Name, 0);
        }

        #region "UI Events"

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
                int.TryParse(tbx.Text, out int val);
                itemValues[tbx.Name] = val;
                UpdateNameFont();
            }
        }

        private void TbxItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                TextBox tbx = (TextBox)sender;
                int val = itemValues[tbx.Name];

                if (e.Key == Key.Up) val++;
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

        public string PlayerName
        {
            get { return TbxName.Text.Trim(); }
            set { TbxName.Text = value.Trim(); }
        }

        public bool CountBag
        {
            get { return countBag; }
            set
            {
                countBag = value;
                TbxBag.Background = value ? Brushes.White : Brushes.Gainsboro;
            }
        }

        public bool CountMythic
        {
            get { return countMythic; }
            set
            {
                countMythic = value;
                TbxMythic.Background = value ? Brushes.White : Brushes.Gainsboro;
            }
        }

        public int Bag
        {
            get { return Helper.GetInt(TbxBag.Text); }
            set { TbxBag.Text = value.ToString(); ; }
        }

        public int Yellow
        {
            get { return Helper.GetInt(TbxYellow.Text); }
            set { TbxYellow.Text = value.ToString(); ; }
        }

        public int Eternal
        {
            get { return Helper.GetInt(TbxEternal.Text); }
            set { TbxEternal.Text = value.ToString(); ; }
        }

        public int Mythic
        {
            get { return Helper.GetInt(TbxMythic.Text); }
            set { TbxMythic.Text = value.ToString(); ; }
        }

        public bool HasName
        {
            get
            {
                return !string.IsNullOrWhiteSpace(TbxName.Text);
            }
        }

        public bool HasLoot
        {
            get
            {
                int loots = Yellow + Eternal;
                if (countBag) loots += Bag;
                if (countMythic) loots += Mythic;
                return loots > 0;
            }
        }

        public string GetText()
        {
            string output = string.Format("[{0}] ", PlayerName);
            if (HasLoot)
            {
                List<int> loots = new List<int>();
                if (countBag) loots.Add(Bag);
                loots.Add(Yellow);
                loots.Add(Eternal);
                if (countMythic) loots.Add(Mythic);
                output += string.Join("/", loots);
            }
            else output += "none";
            return output;
        }

        public void Clear()
        {
            TbxName.Clear();
            TbxBag.Clear();
            TbxYellow.Clear();
            TbxEternal.Clear();
            TbxMythic.Clear();
        }

        #endregion

    }

}
