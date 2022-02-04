using AionLootCounter.Utils;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AionLootCounter.Controls
{
    public partial class LootTextBox : UserControl
    {
        private bool textUpdating;
        private int min = 0;
        private int max = 99;

        public new event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler ValueChanged;
        private const string NumberRegex = "[^0-9]+";

        public LootTextBox()
        {
            InitializeComponent();
            TbxNumber.MaxLength = 2;
        }

        #region "UI Events"

        private void TbxNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.W || e.Key == Key.S)
            {
                var num = TbxNumber.Text.ToInt();

                if (e.Key == Key.Up || e.Key == Key.W) num++;
                else num--;

                if (num < min) num = min;
                if (num > max) num = max;

                textUpdating = true;
                if (num > 0)
                {
                    TbxNumber.Text = num.ToString();
                    TbxNumber.SelectionStart = TbxNumber.Text.Length;
                }
                else TbxNumber.Clear();
                textUpdating = false;
            }
        }

        private void TbxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(NumberRegex);
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TbxNumber_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
                e.Handled = true;
        }

        private void TbxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(this, e);
        }

        private void TbxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textUpdating) return;

            var num = TbxNumber.Text.ToInt();

            if (num < Minimum) num = Minimum;
            if (num > Maximum) num = Maximum;

            textUpdating = true;
            if (num > 0)
            {
                TbxNumber.Text = num.ToString();
                TbxNumber.SelectionStart = TbxNumber.Text.Length;
            }
            else TbxNumber.Clear();
            textUpdating = false;

            ValueChanged?.Invoke(this, e);
        }

        #endregion

        #region Properties

        public int Minimum
        {
            get => min;
            set => min = value > 0 ? value : 0;
        }

        public int Maximum
        {
            get => max;
            set
            {
                max = value > min ? value : min;
                TbxNumber.MaxLength = max.ToString().Length;
            }
        }

        public int Value
        {
            get => TbxNumber.Text.ToInt();
            set
            {
                if (value > 0) TbxNumber.Text = value.ToString();
            }
        }

        public Brush Color
        {
            get => (Brush)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(LootTextBox), new PropertyMetadata(null, ColorPropertyChanged));

        private static void ColorPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (LootTextBox)obj;
            userControl.TbxNumber.Foreground = (Brush)e.NewValue;
        }

        public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(LootTextBox), new PropertyMetadata(null, BackgroundPropertyChanged));

        private static void BackgroundPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (LootTextBox)obj;
            userControl.TbxNumber.Background = (Brush)e.NewValue;
        }

        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        #endregion

        #region "Misc"

        public new void Focus()
        {
            TbxNumber.SelectionStart = TbxNumber.Text.Length;
            TbxNumber.Focus();
        }

        public void Clear()
        {
            TbxNumber.Clear();
        }

        #endregion

    }
}