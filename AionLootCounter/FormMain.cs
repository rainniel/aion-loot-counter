using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AionLootCounter.Classes;

namespace AionLootCounter
{
    public partial class FormMain : Form
    {

        private readonly bool CountMythic = false;

        public FormMain()
        {
            InitializeComponent();

            Player1.CountMythic = CountMythic;
            Player2.CountMythic = CountMythic;
            Player3.CountMythic = CountMythic;
            Player4.CountMythic = CountMythic;
            Player5.CountMythic = CountMythic;
            Player6.CountMythic = CountMythic;

            Player6.PlayerName = "ME";
            Player1.ValueChanged += ValueChanged;
            Player2.ValueChanged += ValueChanged;
            Player3.ValueChanged += ValueChanged;
            Player4.ValueChanged += ValueChanged;
            Player5.ValueChanged += ValueChanged;
            Player6.ValueChanged += ValueChanged;

        }

        private void ValueChanged(object sender, EventArgs e)
        {
            int totalBag = Player1.Bag + Player2.Bag + Player3.Bag + Player4.Bag + Player5.Bag + Player6.Bag;
            int totalYellow = Player1.Yellow + Player2.Yellow + Player3.Yellow + Player4.Yellow + Player5.Yellow + Player6.Yellow;
            int totalEternal = Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal;
            int totalMythic = Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic;
            LabelTotalBag.Text = totalBag > 0 ? totalBag.ToString() : "";
            LabelTotalYellow.Text = totalYellow > 0 ? totalYellow.ToString() : "";
            LabelTotalEternal.Text = totalEternal > 0 ? totalEternal.ToString() : "";
            LabelTotalMythic.Text = totalMythic > 0 ? totalMythic.ToString() : "";
        }

        private void ButtonCopyText_Click(object sender, EventArgs e)
        {

            List<string> playerLoots = new List<string>();

            if (Player1.HasName) playerLoots.Add(Player1.GetText());
            if (Player2.HasName) playerLoots.Add(Player2.GetText());
            if (Player3.HasName) playerLoots.Add(Player3.GetText());
            if (Player4.HasName) playerLoots.Add(Player4.GetText());
            if (Player5.HasName) playerLoots.Add(Player5.GetText());
            if (Player6.HasName) playerLoots.Add(Player6.GetText());

            int totalBag = Player1.Bag + Player2.Bag + Player3.Bag + Player4.Bag + Player5.Bag + Player6.Bag;
            int totalYellow = Player1.Yellow + Player2.Yellow + Player3.Yellow + Player4.Yellow + Player5.Yellow + Player6.Yellow;
            int totalEternal = Player1.Eternal + Player2.Eternal + Player3.Eternal + Player4.Eternal + Player5.Eternal + Player6.Eternal;
            int totalMythic = Player1.Mythic + Player2.Mythic + Player3.Mythic + Player4.Mythic + Player5.Mythic + Player6.Mythic;

            string output = "Loots Bag/Yellow/Eternal";
            if (CountMythic) output += "/Mythic";
            output += ": " + string.Join(", ", playerLoots);

            output += string.Format(", All loots {0}/{1}/{2}", totalBag, totalYellow, totalEternal);
            if (CountMythic) output += "/" + totalMythic;

            while (output.Contains("  "))
            {
                output = output.Replace("  ", " ");
            }

            Clipboard.Clear();
            Clipboard.SetText(output.Trim());

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(this, "Clear all values?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Player1.Clear();
                Player2.Clear();
                Player3.Clear();
                Player4.Clear();
                Player5.Clear();
                Player6.Clear();
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }

}