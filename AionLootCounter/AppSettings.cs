namespace AionLootCounter
{
    public class AppSettings
    {

        public AppSettings()
        {
            ShowBag = true;
            CopyBag = true;
            ShowMythic = true;
            CopyMythic = false;
            GroupMembers = 6;
        }

        public bool ShowBag { get; set; }
        public bool CopyBag { get; set; }
        public bool ShowMythic { get; set; }
        public bool CopyMythic { get; set; }
        public int GroupMembers { get; set; }

    }

}