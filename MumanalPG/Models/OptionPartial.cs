namespace MumanalPG.Models
{
    public class OptionPartial
    {
        public object Id { get; set; }
        public string IntroMsgEdit { get; set; }
        public string IntroMsgDetails { get; set; }
        public string IntroMsgDelete { get; set; }
        public bool ShowIntroMessages { get; set; }
        public string CustomBtn { get; set; }

        public bool CanPrint { get; set; }
        public string UrlPrint { get; set; }

        public bool CanResetPassword { get; set; }
    }
}