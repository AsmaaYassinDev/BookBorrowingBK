namespace BBCommon.Contracts
{
    public interface ICountry
    {
        string Name { get; set; }
        int Id { get; set; }
        IWeekendConfiguration Weekend { get; set; }

    }
}
