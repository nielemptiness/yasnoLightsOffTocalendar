namespace scheduleOff.Domain
{
    public struct Links
    {
        public const string Host = "kyiv.yasno.com.ua";
        public const string Referrer = $"https://{Host}";
        public const string YasnoKyiv = $"{Referrer}/api/v1/electricity-outages-schedule";
    }
}