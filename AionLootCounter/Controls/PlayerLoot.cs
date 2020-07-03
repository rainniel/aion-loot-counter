using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AionLootCounter.Controls
{
    public partial class PlayerLoot : UserControl
    {

        private readonly Color BagColor = Color.FromArgb(76, 207, 255);
        private readonly Color YellowColor = Color.FromArgb(240, 183, 28);
        private readonly Color EternalColor = Color.FromArgb(240, 128, 51);
        private readonly Color MythicColor = Color.FromArgb(143, 57, 206);
        private bool _countMythic = false;

        public event EventHandler ValueChanged;

        public PlayerLoot()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        [Category("Data")]
        public bool CountMythic
        {
            get { return _countMythic; }
            set { _countMythic = value; }
        }

        [Category("Data")]
        public string PlayerName
        {
            get { return TextName.Text.Trim(); }
            set { TextName.Text = value.Trim(); }
        }

        public int Bag
        {
            get { return (int)NumBag.Value; }
            set { NumBag.Value = value; }
        }

        public int Yellow
        {
            get { return (int)NumYellow.Value; }
            set { NumYellow.Value = value; }
        }

        public int Eternal
        {
            get { return (int)NumEternal.Value; }
            set { NumEternal.Value = value; }
        }

        public int Mythic
        {
            get { return (int)NumMythic.Value; }
            set { NumMythic.Value = value; }
        }

        public bool HasName
        {
            get
            {
                return !string.IsNullOrWhiteSpace(TextName.Text);
            }
        }

        public bool HasLoot
        {
            get
            {
                int loots = Bag + Yellow + Eternal;
                if (_countMythic) loots += Mythic;
                return loots > 0;
            }
        }

        public string GetText()
        {
            string output = string.Format("[{0}]", PlayerName);

            if (HasLoot)
            {
                output += string.Format(" {0}/{1}/{2}", Bag, Yellow, Eternal);
                if (_countMythic) output += "/" + Mythic;
            }
            else
            {
                output += " none";
            }

            return output;
        }

        public void Clear()
        {
            TextName.Clear();
            NumBag.Value = 0;
            NumYellow.Value = 0;
            NumEternal.Value = 0;
            NumMythic.Value = 0;
        }

        private void NumBag_ValueChanged(object sender, System.EventArgs e)
        {
            NumBag.ForeColor = NumBag.Value > 0 ? BagColor : NumBag.BackColor;
            UpdateNameFont();
        }

        private void NumYellow_ValueChanged(object sender, System.EventArgs e)
        {
            NumYellow.ForeColor = NumYellow.Value > 0 ? YellowColor : NumYellow.BackColor;
            UpdateNameFont();
        }

        private void NumEternal_ValueChanged(object sender, System.EventArgs e)
        {
            NumEternal.ForeColor = NumEternal.Value > 0 ? EternalColor : NumEternal.BackColor;
            UpdateNameFont();
        }

        private void NumMythic_ValueChanged(object sender, System.EventArgs e)
        {
            NumMythic.ForeColor = NumMythic.Value > 0 ? MythicColor : NumMythic.BackColor;
            UpdateNameFont();
        }

        private void UpdateNameFont()
        {
            TextName.Font = new Font(TextName.Font, HasLoot ? FontStyle.Bold : FontStyle.Regular);
            ValueChanged(this, null);
        }

    }

}