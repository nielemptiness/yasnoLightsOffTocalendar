namespace scheduleOff.Domain
{
    public sealed record StreetResponse
    {
        public string District { get; set; }
        public int Group { get; set; }
        public string House { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
    }
}