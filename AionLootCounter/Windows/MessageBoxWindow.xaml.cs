﻿using System.Windows;
using System.Windows.Input;

namespace AionLootCounter.Windows
{
    public partial class MessageBoxWindow : Window
    {

        public MessageBoxWindow(Window parent, string messageBoxText, string caption, MessageBoxButton button)
        {
            InitializeComponent();

            Owner = GetWindow(parent);
            TbkMessage.Text = messageBoxText;
            LblCaption.Content = caption;

            switch (button)
            {
                case MessageBoxButton.OK:
                    DplOk.Visibility = Visibility.Visible;
                    break;

                case MessageBoxButton.YesNo:
                    DplYesNo.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            else if (e.Key == Key.Enter)
            {
                DialogResult = true;
                Close();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }

}