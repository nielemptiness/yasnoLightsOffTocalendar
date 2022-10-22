namespace scheduleOff.Domain;

public sealed record TimeSchedule
{
    public List<string[]> Group_1 { get; set; }
    public List<string[]> Group_2 { get; set; }
    public List<string[]> Group_3 { get; set; }

    public List<string[]> MatchGroup(int group)
    {
        return group switch
        {
            1 => Group_1,
            2 => Group_2,
            3 => Group_3,
            _ => throw new ArgumentException(nameof(group))
        };
    }
}