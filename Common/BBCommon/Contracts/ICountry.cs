namespace BBCommon.Contracts
{
    public interface ICountry
    {
        string Name { get; set; }
        int Id { get; set; }
        DayOfWeek StartDay { get; set; }
        DayOfWeek EndDay { get; set; }

    }
}
